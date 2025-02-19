using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading;
using EI.SI;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;

namespace Server
{
    class Program
    {
        //Cria variáveis para uso de transmissão de dados
        private const int PORT = 10000;
        private static bool user1disconnected = false;
        private static bool user2disconnected = false;

        private static List<TcpClient> tcpClientsList = new List<TcpClient>();

        private static int contador_clientes = 0;

        //Criar Variável para o uso do protocoloSI

        private static ProtocolSI protocolSI = new ProtocolSI();

        //Método Main: Inicializa o Servidor e Cria um cliente
        static void Main(string[] args)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, PORT);
            TcpListener listener = new TcpListener(endPoint);

            listener.Start();
            Console.WriteLine("Servidor ligado");

		    tcpClientsList.Clear();

			while (true)
			{
	    		TcpClient cliente = listener.AcceptTcpClient();

				contador_clientes++;

				Console.WriteLine("Cliente {0} conectado", contador_clientes);

				ClientHandler clientHandler = new ClientHandler(cliente, contador_clientes);
				clientHandler.Handle();
			}
        }

        //Gere a quantidade e o estado do cliente (Se está conectado ou não)
        class ClientHandler
        {
            private TcpClient client;
            private int clientID;
            public RSACryptoServiceProvider rsa;
            public AesCryptoServiceProvider aes;
            public RSACryptoServiceProvider rsaVerify;
            private const int NUMBER_OF_ITERATIONS = 1000;
            private const int SALTSIZE = 8;

            //Trata dos clientes
            public ClientHandler(TcpClient client, int clientID)
            {
                //Em caso do primeiro utilizador estar logado irá atribuir o seu o id
                if (user1disconnected == true)
                {
                    this.client = client;
                    this.clientID = 1;
                    user1disconnected = false;
                }
                else
                {
                    this.client = client;
                    this.clientID = clientID;

                }
            }
            //Método para decifrar o texto recorrendo ao AES
            private string DecifrarTexto(byte[] txt)
            {

                //Reservar memória para colocar lá o texto e decifra-lo
                MemoryStream ms = new MemoryStream(txt);
                //Iniciar o sistema de cifragem em modo READ
                CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read);
                //Variável para guardar o texto decifrado
                byte[] txtDecifrado = new byte[ms.Length];
                //Variável para ter o número de bytes decifrados
                //DECIFRAR os DADOS
                int byteslidos = 0;
                byteslidos = cs.Read(txtDecifrado, 0, txtDecifrado.Length);

                cs.Close();
                ms.Close();
                //Converter para texto
                string textoDecifrado = Encoding.UTF8.GetString(txtDecifrado, 0, byteslidos);

                //Devolver o texto decifrado

                return textoDecifrado;
            }

            //Inicializa uma nova thread
            public void Handle()
            {
                Thread thread = new Thread(threadHandler);
                thread.Start();
            }

            //Envia os dados decifrados para a lista tcpClientsList para uso no programa 
            public static void Broadcast(string msg, NetworkStream networkstream)
            {
                try
                {
                    string dadoscifrados = "";

                    if (user1disconnected == false)
                    {
                        dadoscifrados = msg;
                        networkstream = tcpClientsList[0].GetStream();
                        byte[] ack = protocolSI.Make(ProtocolSICmdType.MODE, dadoscifrados);
                        networkstream.Write(ack, 0, ack.Length);
                    }
                    if (user2disconnected == true)
                    {
                        dadoscifrados = msg;
                        networkstream = tcpClientsList[1].GetStream();
                        byte[] ack = protocolSI.Make(ProtocolSICmdType.MODE, dadoscifrados);
                        networkstream.Write(ack, 0, ack.Length);
                    }
                }
                catch(Exception e) 
                {
                    Console.WriteLine("Ocorreu um erro: " + e.Message);
                }
            }

            //Verifica a quantidade de users no chat, inicializa variáveis para uso de decriptação, lê as chaves disponíveis por ficheiros, verifica a assinatura digital, e se for veridica é realizado o envio da mensagem para a base de dados e a decriptação da mesma
            private void threadHandler()
            {
                try
                {
                    NetworkStream networkStream = this.client.GetStream();
                    byte[] ack;

                    if (clientID == 1)
                    {
                        tcpClientsList.Insert(0, client);
                        user1disconnected = false;
                    }
                    else if (clientID == 2)
                    {
                        tcpClientsList.Insert(1, client);
                        user2disconnected = true;
                    }

                    ProtocolSI protocoloSI = new ProtocolSI();
                    rsa = new RSACryptoServiceProvider();
                    aes = new AesCryptoServiceProvider();
                    rsaVerify = new RSACryptoServiceProvider();

                    string privateKeyFilePath = "../../../privatekeyaes.txt";
                    string ivFilePath = "../../../IV.txt";
                    string filePath3 = "../../../publickeyrsa.txt";
                    string filePath4 = "../../../bothkeys.txt";
                    string hashFile = "../../../hash.txt";
                    string signatureFile = "../../../signature.txt";

                    ack = protocoloSI.Make(ProtocolSICmdType.ACK, contador_clientes);
                    networkStream.Write(ack, 0, ack.Length);

                    while (protocoloSI.GetCmdType() != ProtocolSICmdType.EOT)
                    {
                        int bytesRead = networkStream.Read(protocoloSI.Buffer, 0, protocoloSI.Buffer.Length);
                        byte[] ack2;
                        byte[] hash;

                        string publicKey = File.ReadAllText(filePath3);
                        string bothKeys = File.ReadAllText(filePath4);

                        rsa.FromXmlString(bothKeys);

                        string privateKey64 = File.ReadAllText(privateKeyFilePath);
                        byte[] privateKey = Convert.FromBase64String(privateKey64);
                        aes.Key = privateKey;

                        string ivBase64 = File.ReadAllText(ivFilePath);
                        byte[] iv = Convert.FromBase64String(ivBase64);
                        aes.IV = iv;

                        rsaVerify.FromXmlString(publicKey);

                        switch (protocoloSI.GetCmdType())
                        {
                            //Receber a mensagem, valida a assinatura digital e se for válido volta enviar a mensagem para o cliente
                            case ProtocolSICmdType.DATA:

                                byte[] encryptedData = protocoloSI.GetData();
                                hash = File.ReadAllBytes(hashFile);
                                byte[] signature = File.ReadAllBytes(signatureFile);
                                bool verify = rsaVerify.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA1"), signature);
                                if (verify)
                                {

                                    byte[] rsaDecrypted = rsa.Decrypt(encryptedData, RSAEncryptionPadding.Pkcs1);

                                    string decryptedText = DecifrarTexto(rsaDecrypted);

                                    Broadcast(decryptedText, networkStream);
                                    ack2 = protocoloSI.Make(ProtocolSICmdType.ACK);
                                    networkStream.Write(ack2, 0, ack2.Length);
                                    RegistarMensagem(rsaDecrypted, clientID);
                                }
                                else
                                    Console.WriteLine("Erro!");
                                break;

                            //Final de transmissão, trata no que acontece caso o cliente desconecte
                            case ProtocolSICmdType.EOT:
                                Console.WriteLine("Terminar a thread do cliente {0}", clientID);
                                ack2 = protocoloSI.Make(ProtocolSICmdType.ACK);
                                networkStream.Write(ack2, 0, ack2.Length);
                                break;

                            //Receber o Login e verificar o Login
                            case ProtocolSICmdType.USER_OPTION_1:
                                var userPass = protocoloSI.GetData();
                                string combinado = Encoding.UTF8.GetString(userPass);
                                string[] separar = combinado.Split('+');
                                string username = "nada";
                                string password = "nada";
                                if (separar.Length == 2)
                                {
                                    username = separar[0];
                                    password = separar[1];
                                }

                                var login = VerifyLogin(username, password);
                                var loginString = Convert.ToString(login);

                                ack2 = protocoloSI.Make(ProtocolSICmdType.USER_OPTION_3, loginString);
                                networkStream.Write(ack2, 0, ack2.Length);
                                break;

                            //Receber os dados para o registo do cliente
                            case ProtocolSICmdType.USER_OPTION_2:
                                var userReg = protocoloSI.GetData();
                                string cambinada = Encoding.UTF8.GetString(userReg);
                                string[] separarReg = cambinada.Split('+');
                                string usernameReg = "nada";
                                string passwordReg = "nada";
                                if (separarReg.Length == 2)

                                {
                                    usernameReg = separarReg[0];
                                    passwordReg = separarReg[1];
                                }

                                byte[] salt = GenerateSalt(SALTSIZE);
                                byte[] hashregisto = GenerateSaltedHash(passwordReg, salt);

                                var registar = Register(usernameReg, hashregisto, salt);
                                var registarstring = Convert.ToString(registar);

                                ack2 = protocoloSI.Make(ProtocolSICmdType.USER_OPTION_4, registarstring);
                                networkStream.Write(ack2, 0, ack2.Length);

                                break;
                        }
                    }
                    networkStream.Close();
                    client.Close();
                }
                catch(Exception e) 
                {
                    Console.WriteLine("Ocorreu um erro: " + e.Message);
                }

            }

            //Função para verificar se os dados recebidos pelo programa para login são válidos
            private bool VerifyLogin(string username, string password)
            {
                SqlConnection conn = null;
                try
                {
                    // Configurar ligação à Base de Dados
                    conn = new SqlConnection();
                    conn.ConnectionString = String.Format(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\tsc20\OneDrive\Documents\IPL\Tópicos de Segurança\Projeto\Projeto\Projeto.mdf';Integrated Security=True");

                    // Abrir ligação à Base de Dados
                    conn.Open();

                    // Declaração do comando SQL
                    String sql = "SELECT * FROM Users WHERE Username = @username";
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = sql;

                    // Declaração dos parâmetros do comando SQL
                    SqlParameter param = new SqlParameter("@username", username);

                    // Introduzir valor ao parâmentro registado no comando SQL
                    cmd.Parameters.Add(param);

                    // Associar ligação à Base de Dados ao comando a ser executado
                    cmd.Connection = conn;

                    // Executar comando SQL
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        throw new Exception("Erro ao verificar utilizador no login!");
                    }

                    // Ler resultado da pesquisa
                    reader.Read();

                    // Obter Hash (password + salt)
                    byte[] saltedPasswordHashStored = (byte[])reader["SaltedPasswordHash"];

                    // Obter salt
                    byte[] saltStored = (byte[])reader["Salt"];

                    conn.Close();

                    //TODO: verificar se a password na base de dados 
                    byte[] hash = GenerateSaltedHash(password, saltStored);

                    return saltedPasswordHashStored.SequenceEqual(hash);

                    //throw new NotImplementedException();

                }
                catch (Exception e)
                {
                    Console.WriteLine("Ocorreu um erro: " + e.Message);
                    return false;
                }

            }
            //Regista as mensagens encriptadas na base de dados
            private bool RegistarMensagem(byte[] mensagem, int clienteid)
            {

                SqlConnection conn = null;
                try
                {
                    // Configurar ligação à Base de Dados
                    conn = new SqlConnection();
                    conn.ConnectionString = String.Format(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\tsc20\OneDrive\Documents\IPL\Tópicos de Segurança\Projeto\Projeto\Projeto.mdf';Integrated Security=True");

                    // Abrir ligação à Base de Dados
                    conn.Open();

                    // Declaração dos parâmetros do comando SQL
                    SqlParameter paramMensagem = new SqlParameter("@mensagem", mensagem);
                    SqlParameter paramClienteid = new SqlParameter("@clienteid", clienteid);


                    // Declaração do comando SQL
                    String sql = "INSERT INTO Mensagens (Mensagem, ClienteID) VALUES (@mensagem,@clienteid)";

                    // Prepara comando SQL para ser executado na Base de Dados
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Introduzir valores aos parâmentros registados no comando SQL
                    cmd.Parameters.Add(paramMensagem);
                    cmd.Parameters.Add(paramClienteid);

                    // Executar comando SQL
                    int lines = cmd.ExecuteNonQuery();

                    // Fechar ligação
                    conn.Close();

                    return true;

                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao registar:" + e.Message);

                }
            }

            //Função para registar um novo utilizador na base de dados
            private bool Register(string username, byte[] saltedPasswordHash, byte[] salt)
            {

                SqlConnection conn = null;
                try
                {
                    // Configurar ligação à Base de Dados
                    conn = new SqlConnection();
                    conn.ConnectionString = String.Format(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\tsc20\OneDrive\Documents\IPL\Tópicos de Segurança\Projeto\Projeto\Projeto.mdf';Integrated Security=True");

                    // Abrir ligação à Base de Dados
                    conn.Open();

                    // Declaração dos parâmetros do comando SQL
                    SqlParameter paramUsername = new SqlParameter("@username", username);
                    SqlParameter paramPassHash = new SqlParameter("@saltedPasswordHash", saltedPasswordHash);
                    SqlParameter paramSalt = new SqlParameter("@salt", salt);


                    // Declaração do comando SQL
                    String sql = "INSERT INTO Users (Username, SaltedPasswordHash, Salt) VALUES (@username,@saltedPasswordHash,@salt)";

                    // Prepara comando SQL para ser executado na Base de Dados
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Introduzir valores aos parâmentros registados no comando SQL
                    cmd.Parameters.Add(paramUsername);
                    cmd.Parameters.Add(paramPassHash);
                    cmd.Parameters.Add(paramSalt);

                    // Executar comando SQL
                    int lines = cmd.ExecuteNonQuery();

                    // Fechar ligação
                    conn.Close();

                    return true;

                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao registar um utilizador:" + e.Message);
                }
            }

            //Gere o SALT, que é utilizado para uso do sistema de login
            public static byte[] GenerateSalt(int size)
            {
                //Generate a cryptographic random number.
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                byte[] buff = new byte[size];
                rng.GetBytes(buff);
                return buff;
            }

            //Gere o HASH, que é utilizado para uso do sistema de login
            public static byte[] GenerateSaltedHash(string plainText, byte[] salt)
            {
                Rfc2898DeriveBytes rfc2898 = new Rfc2898DeriveBytes(plainText, salt, NUMBER_OF_ITERATIONS);//repete 1000x
                return rfc2898.GetBytes(32);
            }
        }
    }
}