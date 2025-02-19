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
    public partial class FormGestaoCliente : Form
    {
        //armazenar o identificador do Cliente
        private int identificador = 0;

        public FormGestaoCliente()
        {
            InitializeComponent();
        }
        private void FormGestaoCliente_Load(object sender, EventArgs e)
        {
            try
            {
				//atualizar DataGridView
				LoadClientes();
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
				//atualizar a DataGirdView pelos dados da base dados
				dataViewClientes.DataSource = null;

				//atualizar dados
				dataViewClientes.DataSource = FormClienteController.GetClientes();
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
				dataViewClientes.CurrentRow.Selected = true;

				//guardar em variaveis e apresentar os dados selecionados na DataGridView
				identificador = int.Parse(dataViewClientes.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString());
				textBoxNomeCliente.Text = dataViewClientes.Rows[e.RowIndex].Cells["Nome"].FormattedValue.ToString();
				textBoxMoradaCliente.Text = dataViewClientes.Rows[e.RowIndex].Cells["Morada"].FormattedValue.ToString();
				textBoxNIFCliente.Text = dataViewClientes.Rows[e.RowIndex].Cells["numFiscal"].FormattedValue.ToString();

				//mostrar dados vindo do controlador FormClienteController
				N_Bilhetes.Text = FormClienteController.NumeroBilhetes(identificador).ToString();
				Preco_Total.Text = FormClienteController.Preco(identificador).ToString();
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        private void buttonAdicionarCliente_Click(object sender, EventArgs e)
        {
            try
            {
				//verificar se os campos estão vazios
				if (String.IsNullOrEmpty(textBoxNomeCliente.Text))
				{
					MessageBox.Show("O campo nome está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);

				}
				else if (String.IsNullOrEmpty(textBoxMoradaCliente.Text))
				{
					MessageBox.Show("O campo morada está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (String.IsNullOrEmpty(textBoxNIFCliente.Text))
				{
					MessageBox.Show("O campo NIF está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				//caso contrário, se correr tudo bem
				else
				{
					//criar um novo Cliente
					FormClienteController.cliente(textBoxNomeCliente.Text.ToString(), textBoxMoradaCliente.Text.ToString(), int.Parse(textBoxNIFCliente.Text));

					//apagar conteúdo das textbox´s
					textBoxNomeCliente.Clear();
					textBoxMoradaCliente.Clear();
					textBoxNIFCliente.Clear();

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

        private void buttonAlterarCliente_Click(object sender, EventArgs e)
        {
            try
            {
				//verificar se os campos estão vazios
				if (dataViewClientes.SelectedRows.Count == 0)
				{
					MessageBox.Show("Cliente não selecionado!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (String.IsNullOrEmpty(textBoxNomeCliente.Text))
				{
					MessageBox.Show("O campo nome está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);

				}
				else if (String.IsNullOrEmpty(textBoxMoradaCliente.Text))
				{
					MessageBox.Show("O campo morada está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (String.IsNullOrEmpty(textBoxNIFCliente.Text))
				{
					MessageBox.Show("O campo NIF está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				//caso contrário, se correr tudo bem
				else
				{
					//alterar dados do Cliente
					FormClienteController.alterCliente(identificador, textBoxNomeCliente.Text, textBoxMoradaCliente.Text, int.Parse(textBoxNIFCliente.Text));

					//apagar conteúdo das textbox´s
					textBoxNomeCliente.Clear();
					textBoxMoradaCliente.Clear();
					textBoxNIFCliente.Clear();

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

        private void buttonRemoverCliente_Click(object sender, EventArgs e)
        {
			try
			{
				//verificar se não existe um registo selecionado
				if (dataViewClientes.SelectedRows.Count == 0)
				{
					MessageBox.Show("Selecione um cliente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
				//caso contrário, se correu bem
				else
				{
					//apagar Cliente
					FormClienteController.apagarCliente(identificador);

					//apagar conteúdo das textbox´s
					textBoxNomeCliente.Clear();
					textBoxMoradaCliente.Clear();
					textBoxNIFCliente.Clear();

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

        private void textBoxNIFCliente_KeyPress(object sender, KeyPressEventArgs e)
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

        private void FormGestaoCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            //quando efetuado o fecho do programa, deve efetuar o fecho total
            Application.Exit();
        }
    }
}
