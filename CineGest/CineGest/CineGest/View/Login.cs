using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CineGest.Controller;

namespace CineGest.View
{
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
        }

        private void buttonEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                //verificar se os campos estão vazios
                if (String.IsNullOrEmpty(textBoxUtilizador.Text))
                {
                    MessageBox.Show("O campo de Utilizador está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (String.IsNullOrEmpty(textBoxPassword.Text))
                {
                    MessageBox.Show("O campo de Password está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //caso contrário, se correr tudo bem
                else
                {
                    //iniciar programa com utilizador autorizado
                    var login = LoginController.login(textBoxUtilizador.Text.ToString(), textBoxPassword.Text.ToString());

					//se correr bem
					if (login == true)
                    {
                        MessageBox.Show("Login Autorizado!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //abrir uma nova Janela (FormPricipal)
                        FormPrincipal formPrincipal = new FormPrincipal();
                        formPrincipal.Show();
                        this.Hide();
                    }
					//se correr mal
					else
					{
                        MessageBox.Show("Login não Autorizado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception)
            {
                //caso ocorra um erro geral na aplicação
                MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRegisto_Click(object sender, EventArgs e)
        {
            try
            {
                //verificar se os campos estão vazios
                if (String.IsNullOrEmpty(textBoxUtilizador.Text))
                {
                    MessageBox.Show("O campo de Utilizador está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (String.IsNullOrEmpty(textBoxPassword.Text))
                {
                    MessageBox.Show("O campo de Password está vazio!", "Dados em falta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //caso contrário, se correr tudo bem
                else
                {
                    //registar um novo utilizador
                    var registo = LoginController.Registar(textBoxUtilizador.Text.ToString(), textBoxPassword.Text.ToString());

					//se correr bem
					if (registo == true)
                    {
                        MessageBox.Show("Registo com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //apagar conteúdo das textbox´s
                        textBoxUtilizador.Clear();
                        textBoxPassword.Clear();

                    }
					//se correr mal
					else
					{
                        MessageBox.Show("Registo não realizado! \n\n Nota: Esta ação pode acontecer caso o utilizador já exista.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception)
            {
                //caso ocorra um erro geral na aplicação
                MessageBox.Show("Ocorreu um erro... \n Tente Novamente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            //ao fechar o programa, efetuar o fecho total da aplicação
            Application.Exit();
        }
    }
}
