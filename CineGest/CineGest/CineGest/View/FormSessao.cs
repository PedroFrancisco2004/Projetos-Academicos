using CineGest.Controller;
using CineGest.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CineGest.View
{
    public partial class FormSessao : Form
    {

        //armazenar o identificador da sessão
        private int identificador_sessao = 0;

        public FormSessao()
        {
            InitializeComponent();
        }

        private void FormSessao_Load(object sender, EventArgs e)
        {
			try
			{
				//atualizar DataGridView
				LoadSessoes();

				//obter os dados vindo dos controladores para serem mostrados para seleção
				comboBoxFilmes.DataSource = FormSessaoController.GetFilmes();
				comboBoxSalas.DataSource = FormSessaoController.GetSalas();
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

        private void LoadSessoes()
        {
			try
			{
				//apagar conteúdo
				dataViewSessao.DataSource = null;

				//atualizar a DataGirdView pelos dados da base dados
				dataViewSessao.DataSource = FormSessaoController.GetSessoes();
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

        private void buttonCriarSessao_Click(object sender, EventArgs e)
        {
			try
			{
				//verificar se os campos estão vazios
				if (String.IsNullOrEmpty(textBoxHora.Text))
				{
					MessageBox.Show("O campo de hora está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (String.IsNullOrEmpty(textBoxMinuto.Text))
				{
					MessageBox.Show("O campo de minuto está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (String.IsNullOrEmpty(textBoxPreco.Text))
				{
					MessageBox.Show("O campo de preço está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (String.IsNullOrEmpty(comboBoxFilmes.Text))
				{
					MessageBox.Show("Precisa de selecionar um filme!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (String.IsNullOrEmpty(comboBoxSalas.Text))
				{
					MessageBox.Show("Precisa de selecionar uma sala!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (monthCalendarSessao.SelectionRange.Start == DateTime.MinValue || monthCalendarSessao.SelectionRange.End == DateTime.MinValue)
				{
					MessageBox.Show("Nenhuma data foi selecionada!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				//verificar os dados inseridos
				else if (int.Parse(textBoxHora.Text) > 24 || int.Parse(textBoxHora.Text) < 0)
				{
					MessageBox.Show("O dado hora está incorreto!", "Campo Incorreto", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (int.Parse(textBoxMinuto.Text) > 60 || int.Parse(textBoxMinuto.Text) < 0)
				{
					MessageBox.Show("O dado minuto está incorreto!", "Campo Incorreto", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				//caso contrário, se correr tudo bem
				else
				{
					//verifica se a data selecionada é igual ou maior que a atual
					if (monthCalendarSessao.SelectionStart >= DateTime.Today)
					{
						//Apresentar os filmes para seleção
						Filme f = (Filme)comboBoxFilmes.SelectedItem;

						//Apresentar as salas para seleção
						Sala s = (Sala)comboBoxSalas.SelectedItem;

						//chamada do controlador
						//criar um novo Filme
						FormSessaoController.addSessao(int.Parse(textBoxHora.Text), int.Parse(textBoxMinuto.Text), float.Parse(textBoxPreco.Text), monthCalendarSessao.SelectionRange.Start, f, s);

						//apagar conteudo das textbox´s
						textBoxHora.Clear();
						textBoxMinuto.Clear();
						textBoxPreco.Clear();

						//atualizar DataGridView
						LoadSessoes();
					}
				}
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

        private void buttonEditarSessao_Click(object sender, EventArgs e)
        {
            try
            {
				//verificar se os campos estão vazios
				if (dataViewSessao.SelectedRows.Count == 0)
				{
					MessageBox.Show("Sessão não selecionada!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (String.IsNullOrEmpty(textBoxHora.Text))
				{
					MessageBox.Show("O campo de hora está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (String.IsNullOrEmpty(textBoxMinuto.Text))
				{
					MessageBox.Show("O campo de minuto está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (String.IsNullOrEmpty(textBoxPreco.Text))
				{
					MessageBox.Show("O campo de preço está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (String.IsNullOrEmpty(comboBoxFilmes.Text))
				{
					MessageBox.Show("Precisa de selecionar um filme!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (String.IsNullOrEmpty(comboBoxSalas.Text))
				{
					MessageBox.Show("Precisa de selecionar uma sala!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (monthCalendarSessao.SelectionRange.Start == DateTime.MinValue || monthCalendarSessao.SelectionRange.End == DateTime.MinValue)
				{
					MessageBox.Show("Nenhuma data foi selecionada!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				//verificar os dados inseridos
				else if (int.Parse(textBoxHora.Text) > 24 || int.Parse(textBoxHora.Text) < 0)
				{
					MessageBox.Show("O dado hora está incorreto!", "Campo Incorreto", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (int.Parse(textBoxMinuto.Text) > 60 || int.Parse(textBoxMinuto.Text) < 0)
				{
					MessageBox.Show("O dado minuto está incorreto!", "Campo Incorreto", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				//caso contrário, se correr tudo bem
				else
				{
					//verifica se a data selecionada é igual ou maior que a atual
					if (monthCalendarSessao.SelectionStart >= DateTime.Today)
					{
						//Apresentar os filmes para seleção
						Filme f = (Filme)comboBoxFilmes.SelectedItem;

						//Apresentar as salas para seleção
						Sala s = (Sala)comboBoxSalas.SelectedItem;

						//criar um novo Filme
						FormSessaoController.alterSessao(identificador_sessao, int.Parse(textBoxHora.Text), int.Parse(textBoxMinuto.Text), float.Parse(textBoxPreco.Text), monthCalendarSessao.SelectionRange.Start, f, s);

						//apagar conteudo das textbox´s
						textBoxHora.Clear();
						textBoxMinuto.Clear();
						textBoxPreco.Clear();

						//atualizar DataGridView
						LoadSessoes();
					}
				}
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

        private void dataViewSessao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
				//permitir a seleção de registos
				dataViewSessao.CurrentRow.Selected = true;

				//guardar em variaveis e serem apresentados os dados selecionados na DataGridView
				identificador_sessao = int.Parse(dataViewSessao.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString());
				textBoxHora.Text = dataViewSessao.Rows[e.RowIndex].Cells["hora"].FormattedValue.ToString();
				textBoxMinuto.Text = dataViewSessao.Rows[e.RowIndex].Cells["minuto"].FormattedValue.ToString();
				textBoxPreco.Text = dataViewSessao.Rows[e.RowIndex].Cells["Preco"].FormattedValue.ToString();
				comboBoxFilmes.Text = dataViewSessao.Rows[e.RowIndex].Cells["Filme"].FormattedValue.ToString();
				comboBoxSalas.Text = dataViewSessao.Rows[e.RowIndex].Cells["Sala"].FormattedValue.ToString();
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        private void buttonRemoverSessao_Click(object sender, EventArgs e)
        {
            try
            {
				//verificar se não existe um registo selecionado
				if (dataViewSessao.SelectedRows.Count == 0)
				{
					MessageBox.Show("Selecione uma sessão!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				//caso contrário, se correr tudo bem
				else
				{
					//apagar a categoria
					FormSessaoController.apagarSessao(identificador_sessao);

					//apagar conteudo das textbox´s
					textBoxHora.Clear();
					textBoxMinuto.Clear();
					textBoxPreco.Clear();

					//atualizar DataGridView
					LoadSessoes();
				}
			}
            catch (Exception)
            {
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            //abrir uma nova Janela (FormPrincipal)
            FormPrincipal formprincipal = new FormPrincipal();
            formprincipal.Show();
            this.Hide();
        }


        private void textBoxPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            //chamada do método do programa.cs para apenas inserção de digitos
            Program.Digitos(e);
        }

        private void textBoxHora_KeyPress(object sender, KeyPressEventArgs e)
		{
			//chamada do método do programa.cs para apenas inserção de digitos
			Program.Digitos(e);
		}

		private void textBoxMinuto_KeyPress(object sender, KeyPressEventArgs e)
		{
			//chamada do método do programa.cs para apenas inserção de digitos
			Program.Digitos(e);
		}

		private void textBoxPreco_KeyPress_1(object sender, KeyPressEventArgs e)
		{
			//chamada do método do programa.cs para apenas inserção de digitos em float
			Program.DigitosFloat(e);
		}

		private void monthCalendarSessao_DateSelected(object sender, DateRangeEventArgs e)
		{
			//se a data escolhida for antiga
			if (monthCalendarSessao.SelectionStart < DateTime.Today)
			{
				MessageBox.Show("A data é antiga!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        private void FormSessao_FormClosed(object sender, FormClosedEventArgs e)
        {
            //ao ser efetuado o encerramento programa, aplicar o encerramento total da aplicação
            Application.Exit();
        }
    }
}
