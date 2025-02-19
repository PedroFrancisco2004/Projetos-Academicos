using CineGest.Controller;
using CineGest.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace CineGest.View
{
    public partial class FormAtendimento : Form
    {
        //variaveis Locais 
        private int identificador_cliente = 0;
        private int identificador_bilhete = 0;
		private int sessao = 0;
        private string nomeCliente;
		Button botaoClicado = new Button();
        private int contadorCadeiras = 0;
        List<string> cadeirasArray = new List<string>();
		private int valorRecebido;

		//COMENTADO PORQUE ESTA VARIAVEL É CHAMADA EM CÓDIGO QUE NÃO CONSEGUIMOS COLOCAR A 100% FUNCIONAL
		//private string textoLinha = null;


        //passar o id da sessão chamado no form Principal
		public FormAtendimento(int valor)
        {
            try
            {
				InitializeComponent();

				//guardar id sessão recebido
				valorRecebido = valor;
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
        private void FormAtendimento_Load(object sender, EventArgs e)
        {
            try
            {
				btnEditarBilhete.Enabled = false;
				checkBoxEstado.Enabled = false;
				btnCancelar.Visible = false;

				//atualizar DataGridView
				LoadClientes();
				LoadBilhetes();

				//atualizar conteúdo das combobox's
				comboBoxSessaoCinema.DataSource = FormSalasCinemaController.Sessoes();
				comboBoxSessaoCinema.Text = valorRecebido.ToString();
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

        private void LoadClientes()
        {
            try
            {
				//apagar dados
				dataViewAtendeClientes.DataSource = null;

				//atualizar a DataGridView pelos dados da base dados
				dataViewAtendeClientes.DataSource = FormClienteController.GetClientes();
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

        private void LoadBilhetes()
        {
			try
			{
				//apagar dados
				dataViewBilhetes.DataSource = null;

				//atualizar a DataGridView pelos dados da base dados
				dataViewBilhetes.DataSource = FormAtendimentoController.GetBilhetes();
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

        private void dataViewClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
			try
			{
				//permitir a seleção do registo pretendido e obter dados dos seus campos
				dataViewAtendeClientes.CurrentRow.Selected = true;

				//guardar e apresentar os dados selecionados na DataGridView
				identificador_cliente = int.Parse(dataViewAtendeClientes.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString());
				textBoxNome.Text = dataViewAtendeClientes.Rows[e.RowIndex].Cells["Nome"].FormattedValue.ToString();
				textBoxMorada.Text = dataViewAtendeClientes.Rows[e.RowIndex].Cells["Morada"].FormattedValue.ToString();
				textBoxNumFiscal.Text = dataViewAtendeClientes.Rows[e.RowIndex].Cells["numFiscal"].FormattedValue.ToString();
				nomeCliente = dataViewAtendeClientes.Rows[e.RowIndex].Cells["Nome"].FormattedValue.ToString();
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        private void buttonAdicionarClientes_Click(object sender, EventArgs e)
        {
			try
			{
				//verificar se os campos estão vazios
				if (String.IsNullOrEmpty(textBoxNome.Text))
				{
					MessageBox.Show("O campo nome está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);

				}
				else if (String.IsNullOrEmpty(textBoxMorada.Text))
				{
					MessageBox.Show("O campo morada está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (String.IsNullOrEmpty(textBoxNumFiscal.Text))
				{
					MessageBox.Show("O campo NIF está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				//caso contrário, se correr tudo bem
				else
				{
					//criar um novo cliente
					FormClienteController.cliente(textBoxNome.Text.ToString(), textBoxMorada.Text.ToString(), int.Parse(textBoxNumFiscal.Text));

					//apagar conteúdo das textbox´s
					textBoxNome.Clear();
					textBoxMorada.Clear();
					textBoxNumFiscal.Clear();

					//atualizar DataGridView
					LoadClientes();
				}
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

		private void comboBoxSessaoCinema_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				//criar variaveis globais para armazenar a sessão selecionada e outros dados
				var valorSelecionado = comboBoxSessaoCinema.SelectedItem.ToString();
				int valorSelecionadoInt = int.Parse(valorSelecionado);
				int numLugares = FormSalasCinemaController.calcularLugares(valorSelecionadoInt);

				//limpar painel das cadeiras
				PanelSala.Controls.Clear();

				//Gerar as cadeiras
				for (int i = 0; i < numLugares; i++)
				{
					//criar o evento das cadeiras
					Button botao = new Button();

					//atribuição de número do lugar
					botao.Name = "Cadeira " + (i + 1);

					//atribuição de imagem ilustrativa à cadeira
					botao.BackgroundImage = Image.FromFile("../../img/cadeira.png");
					botao.BackgroundImageLayout = ImageLayout.Zoom;

					//atribuir o evento da cadeira
					botao.Click += Cadeira_Click;

					//inserir as cadeiras no painel
					PanelSala.Controls.Add(botao);
				}
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		//criar ação das cadeiras
		private void Cadeira_Click(object sender, EventArgs e)
		{
			try
			{
				//ESTE CÓDIGO COMENTADO É PARA CARREGAR OS LUGARES OCUPADOS QUANDO DÁ CLIQUE NA CADEIRA PRETENDIDA, MAS NÃO ESTÁ 100% IMPLEMENTADO

				//caminho de localização do ficheiro
				/*string caminhoBilhete = "../../Bilhetes/Bilhete.txt";


				 //procurar o conteúdo do lugar no ficheiro
				string textoDesejado = "Lugar:"; // Texto inicial desejado

				string line = string.Empty;
				bool cadeiraJaSelecionada = false;

				//verificar se o ficheiro existe
				if (File.Exists(caminhoBilhete))
				{
					//usa as propriedades para ler o ficheiro completo
					using (StreamReader reader = new StreamReader(caminhoBilhete))
					{
						//enquanto existir linhas para leitura
						while (((line = reader.ReadLine()) != null))
						{
							//se contem o valor desejado
							if (line.StartsWith(textoDesejado))
							{
								//indicar a posição e tamanho da palavra a ser encontrada
								int startIndex = 6; // posição inicial do texto desejado na linha
								int length = 10; // comprimento do texto desejado

								//procura na posição a palavra a encontrar
								textoLinha = line.Substring(startIndex, length);

								//chamar o evento
								botaoClicado = (Button)sender;

								//armazenar o id da sessão selecionada
								int sessao = int.Parse(comboBoxSessaoCinema.Text);

								//verificar se a cadeira selecionada já existe no ficheiro
								if (botaoClicado.Name.Trim() == textoLinha.Trim())
								{
									cadeiraJaSelecionada = true;
									break; // Sai do loop pois a cadeira já está selecionada
								}
							}
						}
					}
				}
				//se a cadeira selecionada existir no ficheiro
				if (cadeiraJaSelecionada)
				{
					MessageBox.Show("Cadeira já selecionada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}*/



				//incrementar o número de cadeiras
				contadorCadeiras++;

				//chamar o evento
				botaoClicado = (Button)sender;

				MessageBox.Show("Botão clicado: " + botaoClicado.Name);

				//se a cadeira já foi selecionada
				if (cadeirasArray.Contains(botaoClicado.Name))
				{
					MessageBox.Show("Lugar: " + botaoClicado.Name + " já foi selecionado!", "Valor Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				//caso contrário
				else
				{
					//adicionar uma nova cadeira ao array
					cadeirasArray.Add(botaoClicado.Name);
				}
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnCriarBilhete_Click(object sender, EventArgs e)
		{
			try
			{
                //verificar se os campos estão vazios
                if (dataViewAtendeClientes.SelectedRows.Count == 0)
				{
					MessageBox.Show("Cliente não selecionada!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (botaoClicado.Name == "")
				{
					MessageBox.Show("Nenhum lugar foi selecionado!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					//armazenar os dados selecionados da DataGridView
					sessao = int.Parse(comboBoxSessaoCinema.Text);
				    string sala = FormSalasCinemaController.Sala(int.Parse(comboBoxSessaoCinema.Text));
					string Filme_Nome = FormSalasCinemaController.NomeFilme(int.Parse(comboBoxSessaoCinema.Text));
					DateTime dataBilhete = FormSalasCinemaController.Data(int.Parse(comboBoxSessaoCinema.Text));
					int horaBilhete = FormSalasCinemaController.Hora(int.Parse(comboBoxSessaoCinema.Text));
					int minutoBilhete = FormSalasCinemaController.Minuto(int.Parse(comboBoxSessaoCinema.Text));
					float preco = FormSalasCinemaController.Preco(int.Parse(comboBoxSessaoCinema.Text));

					
					//chamadas do controlador
					//gerar um novo bilhete
					FormSalasCinemaController.GerarBilhete(sessao, sala, Filme_Nome, dataBilhete, horaBilhete, minutoBilhete, nomeCliente, cadeirasArray.ToArray(), preco, contadorCadeiras);

					//criar um novo bilhete na base dados
					FormSalasCinemaController.CriarBilhete(preco, checkBoxEstado.Checked, identificador_cliente, contadorCadeiras, sessao);

					MessageBox.Show("O bilhete foi emitido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

					//limpar array
					cadeirasArray.Clear();

					//limpar contador
					contadorCadeiras = 0;

					//atualizar DataGridView
					LoadBilhetes();
				}
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

        private void dataViewBilhetes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
			try
			{
				//permitir a seleção do registo pretendido e obter dados dos seus campos
				dataViewBilhetes.CurrentRow.Selected = true;

				//guardar em variaveis e apresentar os dados selecionados da DataGridView
				identificador_bilhete = int.Parse(dataViewBilhetes.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString());
				checkBoxEstado.Checked = bool.Parse(dataViewBilhetes.Rows[e.RowIndex].Cells["Estado"].FormattedValue.ToString());

				//bloquear ações:
				groupBoxInserirCliente.Enabled = false;
				buttonAdicionarClientes.Enabled = false;
				dataViewAtendeClientes.Enabled = false;
				PanelSala.Enabled = false;
				comboBoxSessaoCinema.Enabled = false;
				btnCriarBilhete.Enabled = false;
				btnCancelar.Visible = true;
				btnEditarBilhete.Enabled = true;
				checkBoxEstado.Enabled = true;
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

        private void btnEditarBilhete_Click(object sender, EventArgs e)
        {
			try
			{

				//verificar se contem dados por selecionar
				if (dataViewBilhetes.SelectedRows.Count == 0)
				{
					MessageBox.Show("Bilhete não selecionado!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (!checkBoxEstado.Checked)
				{
					MessageBox.Show("Opção 'Usado' não está selecionada!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				// se tudo correr bem
				else
				{
					//chamada do controlador
					//alterar dados do Cliente
					FormAtendimentoController.alterBilhete(identificador_bilhete, checkBoxEstado.Checked);

					//reativar ações:
					groupBoxInserirCliente.Enabled = true;
					buttonAdicionarClientes.Enabled = true;
					dataViewAtendeClientes.Enabled = true;
					PanelSala.Enabled = true;
					comboBoxSessaoCinema.Enabled = true;
					btnCriarBilhete.Enabled = true;
					btnCancelar.Visible = false;
					checkBoxEstado.Checked = false;
					checkBoxEstado.Enabled = false;

					//atualizar DataGridView
					LoadBilhetes();
				}
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			//ativar ações:
			groupBoxInserirCliente.Enabled = true;
			buttonAdicionarClientes.Enabled = true;
			dataViewAtendeClientes.Enabled = true;
			PanelSala.Enabled = true;
			comboBoxSessaoCinema.Enabled = true;
			btnCriarBilhete.Enabled = true;
			btnCancelar.Visible = false;
			btnEditarBilhete.Enabled = false;
			checkBoxEstado.Checked = false;
			checkBoxEstado.Enabled = false;
		}

        private void textBoxNumFiscal_KeyPress(object sender, KeyPressEventArgs e)
        {
            //chamada do método do programa.cs para apenas inserção de digitos
            Program.Digitos(e);
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            //abrir uma nova Janela (FormPrincipal)
            FormPrincipal formprincipal = new FormPrincipal();
            formprincipal.Show();
            this.Hide();

        }

        private void FormAtendimento_FormClosed(object sender, FormClosedEventArgs e)
        {
            //ao ser efetuado o encerramento do programa, efetuar o fecho total
            Application.Exit();
        }
    }
}
