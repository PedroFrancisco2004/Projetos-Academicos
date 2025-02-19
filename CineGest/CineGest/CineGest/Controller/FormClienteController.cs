using CineGest.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace CineGest.Controller
{
    public class FormClienteController
    {
        //obter uma lista de todas os clientes registados
        public static List<Cliente> GetClientes()
        {
            //criar lista
            List<Cliente> lst = new List<Cliente>();

            //abrir ligação com a base dados
            using (var db = new CinemaContext())
            {
                //listar todos os clientes
                lst = db.Clientes.ToList();
            }

            //apresentar resultado da lista
            return lst;
        }

        //método do total de bilhetes comprados pelo cliente
        public static float Preco(int IDCliente)
        {
              float preco = 0;

              //abrir ligação com  base dados
              using (var db = new CinemaContext())
              {
				   //recebe o id do cliente
				   var cliente = db.Bilhetes.Where(s => s.ID == IDCliente);
				   //fazer a contagem dos bilhetes
				   var contadorBilhetes = db.Bilhetes.Count(bl => bl.Cliente == IDCliente);

				   //percorrer todos os campos da tabela Bilhete e fazer o calculo do preço do(s) bilhete(s) emitido(s)
				   foreach (var clientes in cliente)
                   {
                        //calculo do preço
                        preco = contadorBilhetes * clientes.Preco;
                   }
               }

              //apresentar valor
               return preco;
        }

        //método para declarar um novo cliente
        public static void cliente(string nomeCliente, string MoradaCliente, int numFiscal)
        {
            //abrir ligação com a base dados
            using (var db = new CinemaContext())
            {
                //se o numFiscal inserido não existir na base dados
                if (!db.Clientes.Where(s => s.numFiscal == numFiscal).ToList().Any())
                {
                    //criar novo cliente
                    Cliente s = new Cliente();
                    s.Nome = nomeCliente;
                    s.Morada = MoradaCliente;
                    s.numFiscal = numFiscal;

                    //armazenar novo cliente
                    db.Clientes.Add(s);
                    db.SaveChanges();

                    MessageBox.Show("Cliente criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // se existir
                else
                {
                    //se o numFiscal inserido existir na base dados
                    MessageBox.Show("O cliente não foi criado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //método para alterar cliente
        public static void alterCliente(int identificador, string nomeCliente, string moradaCliente, int NIFCliente)
        {
            //abrir ligação com a base dados
            using (var db = new CinemaContext())
            {
                //verificar se na base dados contem o mesmo numFiscal inserido pelo que o Utilizador inseriu
                if (db.Clientes.Where(s => s.numFiscal == NIFCliente).ToList().Any())
                {
                    MessageBox.Show("Os dados inseridos não foram registados!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //se não existir o mesmo NumFiscal
                else
                {
                    //selecionar o cliente pretendido
                    var clientes = db.Clientes.Where(c => c.ID == identificador).ToList();

                    //percorrer todos os campos da tabela Clientes e efetuar alteração dos dados do cliente pretendido
                    foreach (var cliente in clientes)
                    {
                        cliente.Nome = nomeCliente;
                        cliente.Morada = moradaCliente;
                        cliente.numFiscal = NIFCliente;
                    }

                    //armazenar as alterações
                    db.SaveChanges();
                    MessageBox.Show("Dados alterados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        //método para eliminar cliente
        public static void apagarCliente(int identificador)
        {
            //abrir ligação com a base dados
            using (var db = new CinemaContext())
            {
				//se não encontrar o cliente associado a um bilhete
				if (!db.Bilhetes.Where(b => b.Cliente == identificador).ToList().Any())
                {
					//selecionar o cliente pretendido
					var clientes = db.Clientes.Where(c => c.ID == identificador).ToList();

					//percorrer todos os campos da tabela Clientes e efetuar eliminação do cliente pretendido
					foreach (var cliente in clientes)
					{
						//apagar cliente pretendido
						db.Clientes.Remove(cliente);
					}

					//armazenar as alterações
					db.SaveChanges();
					MessageBox.Show("Dados apagados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				//se encontrar bilhete
				else
				{
					MessageBox.Show("O cliente não foi apagado devido a já estar atribuído a um bilhete!", "Proibido", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
        }

        //calcular o número de bilhetes
		public static int NumeroBilhetes(int idCliente)
		{
            int contadorBilhetes = 0;

			//abrir ligação com a base dados
			using (var db = new CinemaContext())
			{
                //adicionar a contagem dos bilhetes consoante o cliente selecionado
				contadorBilhetes = db.Bilhetes.Count(bl => bl.Cliente == idCliente);
			}

            //apresentar o valor
            return contadorBilhetes;
		}
	}
}
