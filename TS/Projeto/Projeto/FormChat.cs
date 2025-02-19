using EI.SI;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Projeto
{
	public partial class FormChat : Form
	{
		//Criar variaveis para uso em transmissão de dados
		private const int PORTO = 10000;
		private NetworkStream networkStream;
		private TcpClient cliente;
		IPEndPoint endPoint;
		//Criar variaveis para criptação e desencriptação
		private ProtocolSI protocoloSI;
		private RSACryptoServiceProvider rsa;
		private AesCryptoServiceProvider aes;
		//Criar variável para uso de assinatura digital
		private RSACryptoServiceProvider rsaVerify;



		//Desabilita as funcionalidades de chat ao iniciar a aplicação (à espera do login)
		private void FormChat_Load(object sender, EventArgs e)
		{
			textBoxMensagem.Enabled = false;
			btnEnviar.Enabled = false;
			listBoxMensagens.Enabled = false;
		}

        //Construtor do cliente, inicializa as varíaveis necessárias e as threads.
        public FormChat()
        {
            try
            {
                endPoint = new IPEndPoint(IPAddress.Loopback, PORTO);
                cliente = new TcpClient();
                cliente.Connect(endPoint);
                networkStream = cliente.GetStream();
                protocoloSI = new ProtocolSI();

                if (Ligacao(protocoloSI) == true)
                {
                    InitializeComponent();
                    Thread thread = new Thread(threadClient);
                    thread.Start(cliente);
                }
                else
                {
                    InitializeComponent();

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Erro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Função que verifica se o programa está conectado com o servidor
        private bool Ligacao(ProtocolSI protocol)
        {
            try
            {
                while (protocol.GetCmdType() != ProtocolSICmdType.ACK)
                {
                    networkStream.Read(protocol.Buffer, 0, protocol.Buffer.Length);
                    if (protocol.GetCmdType() == ProtocolSICmdType.EOT)
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Erro na comunicacao com o servidor.", "Erro Servidor", MessageBoxButtons.OK);
                return false;
            }
        }

        //Recebe nos dados (Username e palavra passe), junta e envia para o servidor
        private void btnEntrar_Click(object sender, EventArgs e)
		{
			string pass = tbPassword.Text;
			string user = tbUtilizador.Text;

			if (user == "" || pass == "")
			{
				MessageBox.Show("Caixa de texto vazia", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				var enctypted = Juntar(pass, user);
				EnviarLogin(enctypted);
			}
		}

		//Função que junta a palavra pass e o username juntos
		public string Juntar(string pass, string user)
		{

			string encrypted = (user + "+" + pass);

			return encrypted;
		}

		//Função que envia o login encriptado para o servidor via ProtocoloSI e verifica se é válido
		private void EnviarLogin(string encrypted)
		{
			try
			{
				byte[] passBytes = protocoloSI.Make(ProtocolSICmdType.USER_OPTION_1, encrypted);

				networkStream.Write(passBytes, 0, passBytes.Length);

				while (protocoloSI.GetCmdType() != ProtocolSICmdType.EOT)
				{

                    // int bytesRead = networkStream.Read(protocoloSI.Buffer, 0, protocoloSI.Buffer.Length);

                    MessageBox.Show("Login recebido");

                    switch (protocoloSI.GetCmdType())
					{

						case ProtocolSICmdType.USER_OPTION_3:
							var msg = protocoloSI.GetStringFromData();
							var login = Convert.ToBoolean(msg);

							if (login == true)
							{
								MessageBox.Show("Login com Sucesso!");
								tbUtilizador.Clear();
								tbPassword.Clear();
								textBoxMensagem.Enabled = true;
								btnEnviar.Enabled = true;
							}
							else if (login == false)
							{
								MessageBox.Show("Credenciais inválidas!");
							}
							break;
						default:
							MessageBox.Show("Clique novamente no botão Entrar para efetuar a ação pretendida!");
							break;

					}
					return;
				}
				networkStream.Close();
				cliente.Close();
			} 
			catch (Exception)
			{
                MessageBox.Show("Erro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

		//Recebe nos dados (Username e palavra passe), junta e envia para o servidor
		private void btnRegistar_Click(object sender, EventArgs e)
		{
			string pass = tbPassword.Text;
			string user = tbUtilizador.Text;

			if (user == "" || pass == "")
			{
                MessageBox.Show("Caixa de texto vazia", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
			{
				var enctypted = Juntar(pass, user);

				RegistarLogin(enctypted);
			}

		}

		//Envia dados para o servidor e recebe se é válido ou não, utiliza o ProtocoloSI
		private void RegistarLogin(string encrypted)
		{
			try
			{
				byte[] passBytes = protocoloSI.Make(ProtocolSICmdType.USER_OPTION_2, encrypted);

				networkStream.Write(passBytes, 0, passBytes.Length);

               while (protocoloSI.GetCmdType() != ProtocolSICmdType.EOT)
               {

					//int bytesRead = networkStream.Read(protocoloSI.Buffer, 0, protocoloSI.Buffer.Length);

                    MessageBox.Show("Registo recebido");

                    switch (protocoloSI.GetCmdType())
					{

						case ProtocolSICmdType.USER_OPTION_4:
							var msg = protocoloSI.GetStringFromData();
							var registar = Convert.ToBoolean(msg);
				
							if (registar == true)
							{
								MessageBox.Show("Registo com Sucesso");
                                tbUtilizador.Clear();
                                tbPassword.Clear();
                            }
                            else if (registar == false)
							{
								MessageBox.Show("Erro no registo!");
							}
							break;
					default:
						MessageBox.Show("Clique novamente no botão Registar para efetuar a ação pretendida!");
						break;

					}
					return;
				}
				networkStream.Close();
				cliente.Close();
			}
			catch(Exception)
			{
                MessageBox.Show("Erro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

		
		//A Thread para Client-Side. Tem a função de colocar as mensagens de chat na listbox: listBoxMensagens.
		private void threadClient(object obj)
		{
			byte[] ack;

			try
			{
				while (protocoloSI.GetCmdType() != ProtocolSICmdType.EOT)
				{
					int bytesread = networkStream.Read(protocoloSI.Buffer, 0, protocoloSI.Buffer.Length);


					switch (protocoloSI.GetCmdType())
					{

						case ProtocolSICmdType.MODE:
							byte[] decryptedByte = protocoloSI.GetData();
							string decryptedStr = Encoding.UTF8.GetString(decryptedByte);

							this.Invoke((MethodInvoker)delegate
							{
								listBoxMensagens.Items.Add(decryptedStr);
							});

							break;
					}
				}
			}
			catch (Exception)
			{
				//MessageBox.Show("Erro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		//Gera chave privada (aes) para uso na cifragem
		private string GerarChavePrivada()
		{

				string pass = "topicos";
				byte[] salt = new byte[] { 0, 1, 0, 8, 2, 9, 9, 7 };
				Rfc2898DeriveBytes pwGen = new Rfc2898DeriveBytes(pass, salt, 1000);
				byte[] key = pwGen.GetBytes(16);
				string passB64 = Convert.ToBase64String(key);
				return passB64;
        }

		//Gere o IV para uso em cifragem
		private string GerarIV()
		{
			string pass = "topicos";
			byte[] salt = new byte[] { 7, 8, 7, 8, 2, 5, 9, 5 };
			Rfc2898DeriveBytes pwGen = new Rfc2898DeriveBytes(pass, salt, 1000);
			byte[] iv = pwGen.GetBytes(16);
			string ivB64 = Convert.ToBase64String(iv);
			return ivB64;
		}

		//Encripta o texto com uso do aes
		private string CifrarTexto(string txt)
		{
			byte[] txtDecifrado = Encoding.UTF8.GetBytes(txt);
			byte[] txtCifrado;

			using (MemoryStream ms = new MemoryStream())
			{
				using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
				{
					cs.Write(txtDecifrado, 0, txtDecifrado.Length);
				}
				txtCifrado = ms.ToArray();
			}

			string txtCifradoB64 = Convert.ToBase64String(txtCifrado);
			return txtCifradoB64;
		}

		//Instancia as variáveis para encriptação, cria caminhos para utilizar os ficheiros de chaves de encriptação e assinaturas digitais,adiciona assinatura digital e envia-a para o servidor
		private void btnEnviar_Click(object sender, EventArgs e)
		{
			rsa = new RSACryptoServiceProvider();
			aes = new AesCryptoServiceProvider();
			rsaVerify = new RSACryptoServiceProvider();

			string privateKeyFilePath = "../../../privatekeyaes.txt";
			string ivFilePath = "../../../IV.txt";
			string filePath3 = "../../../publickeyrsa.txt";
			string filePath4 = "../../../bothkeys.txt";
			string hashFile = "../../../hash.txt";
			string signatureFile = "../../../signature.txt";

			byte[] dados;
			byte[] hash;


			string publicKey = rsa.ToXmlString(false);
			File.WriteAllText(filePath3, publicKey);

			string bothKeys = rsa.ToXmlString(true);
			File.WriteAllText(filePath4, bothKeys);

			string chaveprivadaaes = GerarChavePrivada();
			string iv = GerarIV();
			File.WriteAllText(privateKeyFilePath, chaveprivadaaes);
			File.WriteAllText(ivFilePath, iv);

			byte[] aesKey = Convert.FromBase64String(chaveprivadaaes);
			aes.Key = aesKey;


			byte[] aesIV = Convert.FromBase64String(iv);
			aes.IV = aesIV;

			string mensagem = textBoxMensagem.Text;
			rsaVerify.FromXmlString(publicKey);


			if (mensagem == "")
			{
				MessageBox.Show("Caixa de texto vazia", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				textBoxMensagem.Clear();

				string mensagemEnc = CifrarTexto(mensagem);
				byte[] mensagemEncByte = Convert.FromBase64String(mensagemEnc);

				using (SHA1 sha1 = SHA1.Create())
				{
					dados = Encoding.UTF8.GetBytes(mensagem);

					//MÉTODO COMPUTEHASH CALCULA O VALOR DE HASH
					//SOBRE OS DADOS E DEVOLVE NUM VETOR DE BYTES
					hash = sha1.ComputeHash(dados);
				}
				File.WriteAllBytes(hashFile, hash);

				byte[] signature = rsa.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));
				File.WriteAllBytes(signatureFile, signature);
				byte[] encryptedData = rsa.Encrypt(mensagemEncByte, RSAEncryptionPadding.Pkcs1);

				byte[] packet = protocoloSI.Make(ProtocolSICmdType.DATA, encryptedData);
				networkStream.Write(packet, 0, packet.Length);
			}
		}

		// Método para fechar o Cliente 
		private void CloseClient()
		{
			byte[] eot = protocoloSI.Make(ProtocolSICmdType.EOT);
			networkStream.Write(eot, 0, eot.Length);
			networkStream.Read(protocoloSI.Buffer, 0, protocoloSI.Buffer.Length);
			networkStream.Close();
			cliente.Close();
		}

		//Método para o botão Sair
		private void btnSair_Click(object sender, EventArgs e)
		{

			CloseClient();
			Close();
		}
	}
}

