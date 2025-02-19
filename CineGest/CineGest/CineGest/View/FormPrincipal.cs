using CineGest.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CineGest.Controller;

namespace CineGest
{
    public partial class FormPrincipal : Form
    {
        //armazenar o id da sessão escolhida
		private int identificador_sessao = 0;
		public FormPrincipal()
        {
            InitializeComponent();

            //apresentar nome de Utilizador iniciado no momento
            labelNome.Text = LoginController.GetNome();

        }

        private void buttonCinema_Click(object sender, EventArgs e)
        {
            //abrir uma nova Janela (FormCinema)
            FormCinema formcinema = new FormCinema();
            formcinema.Show();
            this.Hide();
        }

        private void buttonSessoes_Click(object sender, EventArgs e)
        {
            //abrir uma nova Janela (FormSessao)
            FormSessao formsessao = new FormSessao();
            formsessao.Show();
            this.Hide();
        }

        private void buttonClientes_Click(object sender, EventArgs e)
        {
            //abrir uma nova Janela (FormGestaoCliente)
            FormGestaoCliente formcliente = new FormGestaoCliente();
            formcliente.Show();
            this.Hide();
        }

        private void buttonFilmes_Click(object sender, EventArgs e)
        {
            //abrir uma nova Janela (FormFilme)
            FormFilme formfilme = new FormFilme();
            formfilme.Show();
            this.Hide();
        }

        private void buttonTrocarFuncionario_Click(object sender, EventArgs e)
        {
            try
            {
				//perguntar se pretende continuar a ação
				DialogResult confirmacao = MessageBox.Show("Pretende continuar a terminar a sessão em aberto?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				//se sim
				if (confirmacao == System.Windows.Forms.DialogResult.Yes)
				{
					//abrir uma nova Janela (Login)
					Login formLogin = new Login();
					formLogin.Show();
					this.Hide();
				}
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
				//verificar se os dados do cinema estão registados na Base Dados
				var cinema = FormPrincipalController.VerificarCinemaRegistado();

				//se não estiverem registados
				if (cinema != true)
				{
					//bloquear eventos dos botões:
					dataViewSessoes.Enabled = false;
					buttonClientes.Enabled = false;
					buttonSessoes.Enabled = false;
					buttonFilmes.Enabled = false;

					MessageBox.Show("Para usufruir a aplicação completa, deve efetuar o registo do cinema.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
				//se sim
				else
				{
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

        private void LoadSessoes()
        {
            try
            {
				//atualizar a DataGridView pelos dados da base dados
				dataViewSessoes.DataSource = null;

				//chamada do controlador
				//obter dados das Sessões na DataGridView
				dataViewSessoes.DataSource = FormPrincipalController.GetSessoes();
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

		private void dataViewSessoes_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				//permitir a seleção do registo pretendido na DataGridView
				dataViewSessoes.CurrentRow.Selected = true;

				//armazenar em variavel o id da sessão selecionada na DataGridView
				identificador_sessao = int.Parse(dataViewSessoes.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString());

				//passar ao form de atendimento
				FormAtendimento formulario = new FormAtendimento(identificador_sessao);
				formulario.Show();
				this.Hide();
			}
			catch (Exception)
			{
				//caso ocorra um erro geral na aplicação
				MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        private void FormPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            //quando efetuado o fecho do programa, efetuar o fecho total
            Application.Exit();
        }
    }
}
