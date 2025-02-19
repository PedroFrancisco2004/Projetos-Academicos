using CineGest.Controller;
using CineGest.Model;
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
    public partial class FormCinema : Form
    {
        //armazenar o identificador do Cinema
        private int identificador = 0;
        public FormCinema()
        {
            InitializeComponent();
        }

        private void FormCinema_Load(object sender, EventArgs e)
        {
            try
            {
                //atualizar DataGridViews
                LoadSalas();
                LoadCinema();
            }
            catch (Exception)
            {
                //caso ocorra um erro geral na aplicação
                MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSalas()
        {
            try
            {
				//atualizar a DataGirdView pelos dados da base dados
				dataViewSalas.DataSource = null;

				//chamada do controlador
				//atualizar dados
				dataViewSalas.DataSource = FormCinemaController.GetSalas();
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }
        private void LoadCinema()
        {
            try
            {
				//atualizar a DataGirdView pelos dados da base dados
				dataViewCinema.DataSource = null;

				//atualizar dados
				dataViewCinema.DataSource = FormCinemaController.GetCinema();

				//se não conter registo dos dados do Cinema
				if (dataViewCinema.Rows.Count == 0)
				{
					//bloquar ações dos botões
					groupBox2.Enabled = false;
					dataViewSalas.Enabled = false;
				}
				//se existir dados do Cinema
				else
				{
					//ativa os botões
					groupBox2.Enabled = true;
					dataViewSalas.Enabled = true;
				}
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

        private void dataViewSalas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
				//permitir a seleção do registo pretendido e obter dados dos seus campos
				dataViewSalas.CurrentRow.Selected = true;

				//guardar e apresentar em variaveis e labels os dados selecionados da DataGridView
				identificador = int.Parse(dataViewSalas.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString());
				textBoxSala.Text = dataViewSalas.Rows[e.RowIndex].Cells["NomeSala"].FormattedValue.ToString();
				textBoxColunas.Text = dataViewSalas.Rows[e.RowIndex].Cells["Coluna"].FormattedValue.ToString();
				textBoxFilas.Text = dataViewSalas.Rows[e.RowIndex].Cells["Fila"].FormattedValue.ToString();
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

        private void dataViewCinema_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
				//permitir a seleção do registo pretendido e obter dados dos seus campos
				dataViewCinema.CurrentRow.Selected = true;

				//apresentar em labels os dados selecionados da DataGridView
				textBoxNomeCinema.Text = dataViewCinema.Rows[e.RowIndex].Cells["nome"].FormattedValue.ToString();
				textBoxMorada.Text = dataViewCinema.Rows[e.RowIndex].Cells["morada"].FormattedValue.ToString();
				textBoxEmail.Text = dataViewCinema.Rows[e.RowIndex].Cells["email"].FormattedValue.ToString();
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

        private void buttonAdicionarSala_Click(object sender, EventArgs e)
        {
            try
            {
				//verificar se os campos estão vazios
				if (String.IsNullOrEmpty(textBoxSala.Text))
				{
					MessageBox.Show("O campo identificação da sala está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);

				}
				else if (String.IsNullOrEmpty(textBoxColunas.Text))
				{
					MessageBox.Show("O campo número de colunas está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (String.IsNullOrEmpty(textBoxFilas.Text))
				{
					MessageBox.Show("O campo número de filas está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				//caso contrário, se correr tudo bem
				else
				{
					//chamada do controlador
					//criar uma nova Sala
					FormCinemaController.sala(textBoxSala.Text.ToString(), int.Parse(textBoxColunas.Text), int.Parse(textBoxFilas.Text));

					//apagar conteúdo das textbox´s
					textBoxSala.Clear();
					textBoxColunas.Clear();
					textBoxFilas.Clear();

					//atualizar DataGridView
					LoadSalas();
				}
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

        private void buttonAlterarSala_Click(object sender, EventArgs e)
        {
            try
            {
				//verificar se os campos estão vazios
				if (dataViewSalas.SelectedRows.Count == 0)
				{
					MessageBox.Show("Sala não selecionada!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (String.IsNullOrEmpty(textBoxSala.Text))
				{
					MessageBox.Show("O campo identificação da sala está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);

				}
				else if (String.IsNullOrEmpty(textBoxColunas.Text))
				{
					MessageBox.Show("O campo número de colunas está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (String.IsNullOrEmpty(textBoxFilas.Text))
				{
					MessageBox.Show("O campo número de filas está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				//caso contrário, se correr tudo bem
				else
				{
					//chamada do controlador
					//alterar a Sala
					FormCinemaController.alterSala(identificador, textBoxSala.Text, int.Parse(textBoxColunas.Text), int.Parse(textBoxFilas.Text));

					//apagar conteúdo das textbox´s
					textBoxSala.Clear();
					textBoxColunas.Clear();
					textBoxFilas.Clear();

					//atualizar DataGridView
					LoadSalas();
				}
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

        private void btnAdInforCinema_Click(object sender, EventArgs e)
        {
			try
			{
				//verificar se os campos estão vazios
				if (String.IsNullOrEmpty(textBoxNomeCinema.Text))
				{
					MessageBox.Show("O campo nome do cinema está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (String.IsNullOrEmpty(textBoxMorada.Text))
				{
					MessageBox.Show("O campo morada está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (String.IsNullOrEmpty(textBoxEmail.Text))
				{
					MessageBox.Show("O campo email está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if(!textBoxEmail.Text.Contains("@"))
				{
                    MessageBox.Show("O campo email tem de obrigatoriamente conter @!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //caso contrário, se correr tudo bem
                else
				{
					//chamada do controlador
					//adicionar informação do cinema
					FormCinemaController.addCinema(textBoxNomeCinema.Text, textBoxMorada.Text, textBoxEmail.Text);

					//apagar conteúdo das textbox´s
					textBoxNomeCinema.Clear();
					textBoxMorada.Clear();
					textBoxEmail.Clear();

					//atualizar DataGridView
					LoadCinema();
				}
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

        private void btnAlterDadosCinema_Click(object sender, EventArgs e)
        {
			try
			{
				//verificar se os campos estão vazios
				if (dataViewCinema.SelectedRows.Count == 0)
				{
					MessageBox.Show("Dados do cinema não selecionados!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (String.IsNullOrEmpty(textBoxNomeCinema.Text))
				{
					MessageBox.Show("O campo nome do cinema está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (String.IsNullOrEmpty(textBoxMorada.Text))
				{
					MessageBox.Show("O campo morada está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (String.IsNullOrEmpty(textBoxEmail.Text))
				{
					MessageBox.Show("O campo email está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
                else if (!textBoxEmail.Text.Contains("@"))
                {
                    MessageBox.Show("O campo email tem de obrigatoriamente conter @!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //caso contrário, se correr tudo bem
                else
				{
					//chamada do controlador
					//alterar informação do cinema
					FormCinemaController.alterCinema(textBoxNomeCinema.Text, textBoxMorada.Text, textBoxEmail.Text);

					//apagar conteúdo das textbox´s
					textBoxNomeCinema.Clear();
					textBoxMorada.Clear();
					textBoxEmail.Clear();

					//atualizar DataGridView
					LoadCinema();
				}
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

        private void textBoxColunas_KeyPress(object sender, KeyPressEventArgs e)
        {
            //chamada do método do programa.cs para apenas inserção de digitos
            Program.Digitos(e);
        }

        private void textBoxFilas_KeyPress(object sender, KeyPressEventArgs e)
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

        private void FormCinema_FormClosed(object sender, FormClosedEventArgs e)
        {
            //ao ser efetuado o encerramento do programa, efetuar o fecho total
            Application.Exit();
        }
    }
}
