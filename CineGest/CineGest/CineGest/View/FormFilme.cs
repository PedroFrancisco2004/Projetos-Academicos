using CineGest.Controller;
using CineGest.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CineGest.View
{
    public partial class FormFilme : Form
    {
        //armazenar o identificador do Filme
        private int identificador = 0;
		private string nomeFilme = string.Empty;


		public FormFilme()
        {
            InitializeComponent();
        }

        private void FormFilme_Load(object sender, EventArgs e)
        {
            try
            {
                //atualizar DataGridView
                LoadFilmes();
                comboBoxCategoria.DataSource = FormFilmeController.CategoriasTrue();
            }
            catch (Exception)
            {
                //caso ocorra um erro geral na aplicação
                MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFilmes()
        {
            try
            {
				//atualizar a DataGirdView pelos dados da base dados
				dataViewFilmes.DataSource = null;

				//atualizar dados
				dataViewFilmes.DataSource = FormFilmeController.GetFilmes();
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

        private void buttonCategorias_Click(object sender, EventArgs e)
        {
            //abrir uma nova Janela (FormCategorias)
            FormCategorias formcategoria = new FormCategorias();
            formcategoria.Show();
            this.Hide();
        }

        private void dataViewFilmes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
				//permitir a seleção do registo pretendido e obter dados dos seus campos
				dataViewFilmes.CurrentRow.Selected = true;

				//guardar em variaveis e apresentar os dados selecionados na DataGridView
				identificador = int.Parse(dataViewFilmes.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString());
				textBoxNomeFilme.Text = dataViewFilmes.Rows[e.RowIndex].Cells["NomeFilme"].FormattedValue.ToString();
				textBoxTempoFilme.Text = dataViewFilmes.Rows[e.RowIndex].Cells["Duracao"].FormattedValue.ToString();
				checkBoxAtivo.Checked = bool.Parse(dataViewFilmes.Rows[e.RowIndex].Cells["Activo"].FormattedValue.ToString());
				nomeFilme = dataViewFilmes.Rows[e.RowIndex].Cells["NomeFilme"].FormattedValue.ToString();
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        private void btnCriarFilme_Click(object sender, EventArgs e)
        {
            try
            {
				//verificar se os campos estão vazios
				if (String.IsNullOrEmpty(textBoxNomeFilme.Text))
				{
					MessageBox.Show("O campo identificação do filme está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);

				}
				else if (String.IsNullOrEmpty(textBoxTempoFilme.Text))
				{
					MessageBox.Show("O campo de tempo do filme está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (String.IsNullOrEmpty(comboBoxCategoria.Text))
				{
					MessageBox.Show("O campo da categoria está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				//caso contrário, se correr tudo bem
				else
				{
					//Apresentar as categorias para seleção
					Categoria c = (Categoria)comboBoxCategoria.SelectedItem;

					//chamada do controlador
					//criar um novo Filme
					FormFilmeController.addFilme(textBoxNomeFilme.Text, textBoxTempoFilme.Text, checkBoxAtivo.Checked, c);

					//apagar conteúdo das textbox´s
					textBoxNomeFilme.Clear();
					textBoxTempoFilme.Clear();
					//remover o visto da checkbox
					checkBoxAtivo.Checked = false;

					//atualizar DataGridView
					LoadFilmes();
				}
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

        private void buttonEditarFilme_Click(object sender, EventArgs e)
        {
            try
            {
				//verificar se os campos estão vazios
				if (dataViewFilmes.SelectedRows.Count == 0)
				{
					MessageBox.Show("Filme não selecionado!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (String.IsNullOrEmpty(textBoxNomeFilme.Text))
				{
					MessageBox.Show("O campo identificação do filme está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (String.IsNullOrEmpty(textBoxTempoFilme.Text))
				{
					MessageBox.Show("O campo de tempo do filme está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (String.IsNullOrEmpty(comboBoxCategoria.Text))
				{
					MessageBox.Show("O campo da categoria está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				//se correr tudo bem, editar o Filme
				else
				{
					//selecionar na base dados consoante o selecionado na combobox
					Categoria c = (Categoria)comboBoxCategoria.SelectedItem;

					//alterar filme
					FormFilmeController.alterFilme(identificador, textBoxNomeFilme.Text, textBoxTempoFilme.Text, checkBoxAtivo.Checked, c);

					//apagar conteúdo das textbox´s
					textBoxNomeFilme.Clear();
					textBoxTempoFilme.Clear();
					//remover o visto da checkbox
					checkBoxAtivo.Checked = false;

					//atualizar DataGridView
					LoadFilmes();
				}
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

        private void buttonApagarFilme_Click(object sender, EventArgs e)
        {
			try
			{
				//verificar se não existe um registo selecionado
				if (dataViewFilmes.SelectedRows.Count == 0)
				{
					MessageBox.Show("Selecione um filme!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				//caso contrário, se tudo correu bem
				else
				{
					//apagar o Filme
					FormFilmeController.apagarFilme(identificador, nomeFilme);

					//atualizar DataGridView
					LoadFilmes();

					//apagar conteúdo das textbox´s
					textBoxNomeFilme.Clear();
					textBoxTempoFilme.Clear();
					//remover o visto da checkbox
					checkBoxAtivo.Checked = false;

					//apagar dados dos campos do form
					textBoxNomeFilme.Text = "";
					textBoxTempoFilme.Text = "";

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

        private void textBoxTempoFilme_KeyPress(object sender, KeyPressEventArgs e)
        {
            //chamada do método do programa.cs para apenas inserção de digitos
            Program.Digitos(e);
        }

        private void FormFilme_FormClosed(object sender, FormClosedEventArgs e)
        {
            //ao ser efetuado o encerramento do programa, efetuar o fecho total
            Application.Exit();
        }
    }
}
