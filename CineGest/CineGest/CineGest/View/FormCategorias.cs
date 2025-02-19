using CineGest.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CineGest.View
{
    public partial class FormCategorias : Form
    {
        //armazenar o identificador da categoria
        private int identificador = 0;

        public FormCategorias()
        {
            InitializeComponent();
        }

        private void FormCategorias_Load(object sender, EventArgs e)
        {
            try
            {
                //atualizar DataGridView
                LoadCategorias();
            }
            catch (Exception)
            {
                //caso ocorra um erro geral na aplicação
                MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCategorias()
        {
            try
            {
				//atualizar a DataGirdView pelos dados da base dados
				dataViewCategorias.DataSource = null;

				//chamada do controlador
				//atualizar os dados
				dataViewCategorias.DataSource = FormCategoriaController.GetCategorias();
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

        private void dataViewCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
				//permitir a seleção do registo pretendido e obter dados dos seus campos
				dataViewCategorias.CurrentRow.Selected = true;

				//guardar em variaveis os dados selecionados da DataGridView
				identificador = int.Parse(dataViewCategorias.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString());
				textBoxNomeCategoria.Text = dataViewCategorias.Rows[e.RowIndex].Cells["NomeCategoria"].FormattedValue.ToString();
				checkBoxAtivo.Checked = bool.Parse(dataViewCategorias.Rows[e.RowIndex].Cells["Activa"].FormattedValue.ToString());
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        private void buttonCriarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
				//verificar se o campo está vazio
				if (String.IsNullOrEmpty(textBoxNomeCategoria.Text))
				{
					MessageBox.Show("O campo de nome da categoria está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				//caso contrário, verificar se as categorias são as específicas:
				else if (textBoxNomeCategoria.Text != "Comédia" && textBoxNomeCategoria.Text != "Sci-fi" &&
					textBoxNomeCategoria.Text != "Terror" && textBoxNomeCategoria.Text != "Romance" && textBoxNomeCategoria.Text != "Acção"
					&& textBoxNomeCategoria.Text != "Thriller" && textBoxNomeCategoria.Text != "Drama" && textBoxNomeCategoria.Text != "Mistério"
					&& textBoxNomeCategoria.Text != "Crime" && textBoxNomeCategoria.Text != "Aventura" && textBoxNomeCategoria.Text != "Fantasia"
					&& textBoxNomeCategoria.Text != "Animação")
				{
					//se a categoria inserida não for a específica
					MessageBox.Show("Categoria Inválida!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				//caso contrário, se correr tudo bem
				else
				{
					//chamada do controlador
					//criar uma nova Categoria
					FormCategoriaController.categoria(textBoxNomeCategoria.Text, checkBoxAtivo.Checked);

					//apagar conteúdo textbox
					textBoxNomeCategoria.Clear();
					//desmarcar checkbox
					checkBoxAtivo.Checked = false;

					//atualizar DataGridView
					LoadCategorias();
				}
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            try
            {
				//verificar se os campos estão vazios
				if (dataViewCategorias.SelectedRows.Count == 0)
				{
					MessageBox.Show("Categoria não selecionada!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (String.IsNullOrEmpty(textBoxNomeCategoria.Text))
				{
					MessageBox.Show("O campo de nome da categoria está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				//caso contrário, verificar se as categorias são as específicas:
				else if (textBoxNomeCategoria.Text != "Comédia" && textBoxNomeCategoria.Text != "Sci-fi" &&
					textBoxNomeCategoria.Text != "Terror" && textBoxNomeCategoria.Text != "Romance" && textBoxNomeCategoria.Text != "Acção"
					&& textBoxNomeCategoria.Text != "Thriller" && textBoxNomeCategoria.Text != "Drama" && textBoxNomeCategoria.Text != "Mistério"
					&& textBoxNomeCategoria.Text != "Crime" && textBoxNomeCategoria.Text != "Aventura" && textBoxNomeCategoria.Text != "Fantasia"
					&& textBoxNomeCategoria.Text != "Animação")
				{
					//se a categoria inserida não for a específica
					MessageBox.Show("Categoria Inválida!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				//caso contrário, se correr tudo bem
				else
				{
					//chamada do controlador
					//editar a categoria
					FormCategoriaController.altercategoria(identificador, textBoxNomeCategoria.Text, checkBoxAtivo.Checked);

					//apagar conteúdo textbox
					textBoxNomeCategoria.Clear();
					//desmarcar checkbox
					checkBoxAtivo.Checked = false;

					//atualizar DataGridView
					LoadCategorias();
				}
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

        private void buttonApagar_Click(object sender, EventArgs e)
        {
			try
			{
				//verificar se não existe um registo selecionado
				if (dataViewCategorias.SelectedRows.Count == 0)
				{
					MessageBox.Show("Selecione uma categoria!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				//caso contrário, se correr tudo bem
				else
				{
					//chamada do controlador
					//apagar a categoria
					FormCategoriaController.apagarCategoria(identificador);

					//apagar conteúdo textbox
					textBoxNomeCategoria.Clear();
					//desmarcar checkbox
					checkBoxAtivo.Checked = false;

					//atualizar DataGridView
					LoadCategorias();
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
            //abrir uma nova Janela (FormFilme)
            FormFilme formfilme = new FormFilme();
            formfilme.Show();
            this.Hide();
        }

        private void FormCategorias_FormClosed(object sender, FormClosedEventArgs e)
        {
            //ao ser efetuado o encerramento do programa, efetuar o fecho total
            Application.Exit();
        }
    }
}
