using CineGest.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CineGest.Controller
{
    public class FormAtendimentoController
    {

		//obter uma lista de todos os clientes registados
		public static List<Cliente> GetClientes()
        {
            //criar lista
            List<Cliente> lst = new List<Cliente>();

            //abrir ligação com a base dados
            using (var db = new CinemaContext())
            {
                //listar os clientes
                lst = db.Clientes.ToList();
            }

            //apresentar resultado da lista
            return lst;
        }

        //obter uma lista de todos os bilhetes registados
        public static List<Bilhete> GetBilhetes()
        {
            //criar lista
            List<Bilhete> lst = new List<Bilhete>();

            //abrir ligação com a base dados
            using (var db = new CinemaContext())
            {
                //listar os bilhetes cujo um dos campos contenha False
                lst = db.Bilhetes.Where(s => s.Estado == "False").ToList();
            }

            //apresentar resultado da lista
            return lst;
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
				//se o numFiscal inserido existir na base dados
				else
				{
                    MessageBox.Show("O cliente não foi criado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //método para alterar filme
        public static void alterBilhete(int idBilhete,bool estado)
        {
            //abrir ligação com a base dados
            using (var db = new CinemaContext())
            {

				//selecionar o cliente pretendido
				var bilhetes = db.Bilhetes.Where(c => c.ID == idBilhete).ToList();

                //percorrer todos os campos da tabela Filmes e efetuar alteração dos dados do filme pretendido
                foreach (var bilhete in bilhetes)
                {
                    bilhete.Estado = estado.ToString();
                }

				//armazenar as alterações
				db.SaveChanges();
                MessageBox.Show("Dados alterados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
	}
}
