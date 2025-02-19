using CineGest.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CineGest.Controller
{
	//listar as salas
	public class FormSalasCinemaController
	{
		//obter uma lista de todas as salas
		public static List<Sala> Salas()
		{

			//criar lista
			List<Sala> lst = new List<Sala>();

			//abrir ligação com a base dados
			using (var db = new CinemaContext())
			{
				//apresentar as salas
				lst = db.Salas.ToList();
			}

			//apresentar resultado da lista
			return lst;
		}

		//obter uma lista das sessões do dia atual
		public static List<Sessao> Sessoes()
		{
			//criar lista
			List<Sessao> lst = new List<Sessao>();

			//abrir ligação com a base dados
			using (var db = new CinemaContext())
			{
				//apresentar as sessões cuja data são do dia atual
				lst = db.Sessoes.Where(s => s.data == DateTime.Today).ToList();
			}

			//apresentar resultado da lista
			return lst;
		}

		//método para calcular lugares
		public static int calcularLugares(int IDSessao)
		{
			int filasCinema = 0;
			int colunasCinema = 0;
			int totalLugares = 0;

			//abrir ligação com a base dados
			using (var db = new CinemaContext())
			{
				//obter a sessão selecionada
				var sessao = db.Sessoes.Include(s => s.Sala).FirstOrDefault(s => s.ID == IDSessao);

				//se a sala e a sessão não forem nulls
				if (sessao != null && sessao.Sala != null)
				{
					int idDaSala = sessao.Sala.ID;
					var sala = db.Salas.FirstOrDefault(s => s.ID == idDaSala);

					//se a sala for diferente de null
					if (sala != null)
					{
						colunasCinema = sala.Coluna;
						filasCinema = sala.Fila;
					}
				}
			}

			//calcular número de lugares
			totalLugares = filasCinema * colunasCinema;

			//apresentar resultado
			return totalLugares;
		}

        //método para busca do NomeFilme para o bilhete
        public static string Sala(int IDSessao)
        {
            string sala_nome = "";

            // abrir ligação com a base de dados
            using (var db = new CinemaContext())
            {
                //obter a sessão selecionada
                var sessao = db.Sessoes.Include(s => s.Sala).FirstOrDefault(s => s.ID == IDSessao);

                //se a sala e a sessão não forem nulls
                if (sessao != null && sessao.Sala != null)
                {
                    int idDaSala = sessao.Sala.ID;
                    var sala = db.Salas.FirstOrDefault(s => s.ID == idDaSala);

                    //se a sala for diferente de null
                    if (sala != null)
                    {
                        sala_nome = sala.NomeSala;
                    }
                }
            }

            // apresentar valor
            return sala_nome;
        }

        //método para busca do NomeFilme para o bilhete
        public static string NomeFilme(int IDSessao)
        {
            string filmeNome = "";


            // abrir ligação com a base de dados
            using (var db = new CinemaContext())
            {
                //obter a sessão selecionada
                var sessao = db.Sessoes.Include(s => s.Filme).FirstOrDefault(s => s.ID == IDSessao);

                //se a sala e a sessão não forem nulls
                if (sessao != null && sessao.Filme != null)
                {
                    int idDoFilme = sessao.Filme.ID;
                    var filme = db.Filmes.FirstOrDefault(s => s.ID == idDoFilme);

                    //se a sala for diferente de null
                    if (filme != null)
                    {
						filmeNome = filme.NomeFilme;
                    }
                }
            }

            // apresentar valor
            return filmeNome;
        }


        //método para busca da Data para o bilhete
        public static DateTime Data(int IDSessao)
		{
			DateTime st = DateTime.Now;

			//abrir ligação com a base dados
			using (var db = new CinemaContext())
			{
				//selecionar a sessão pretendida
				var sessao = db.Sessoes.Where(s => s.ID == IDSessao);

				//percorrer até encontrar a data da sessão selecionada
				foreach (var sessoes in sessao)
				{
					st = sessoes.data;

				}
			}

			//apresentar valor
			return st;
		}

		//método para busca da Hora para o bilhete
		public static int Hora(int IDSessao)
		{
			int hora = 0;

			//abrir ligação com a base dados
			using (var db = new CinemaContext())
			{
				//selecionar a sessão pretendida do utilizador
				var sessao = db.Sessoes.Where(s => s.ID == IDSessao);

				//percorrer até encontrar a hora da sessão selecionada
				foreach (var sessoes in sessao)
				{
					hora = sessoes.hora;

				}
			}

			//apresentar o valor
			return hora;
		}

		//método para busca do Minuto para o bilhete
		public static int Minuto(int IDSessao)
		{
			int minuto = 0;

			//abrir ligação com a base dados
			using (var db = new CinemaContext())
			{
				//selecionar a sessão
				var sessao = db.Sessoes.Where(s => s.ID == IDSessao);

				//percorrer até encontrar o minuto da sessão selecionada
				foreach (var sessoes in sessao)
				{
					minuto = sessoes.minuto;

				}
			}

			//apresentar o valor
			return minuto;
		}

		//método para busca do Preço para o bilhete
		public static float Preco(int IDCliente)
		{
			float preco = 0;

			//abrir ligação com a base dados
			using (var db = new CinemaContext())
			{
				//selecionar o cliente
				var cliente = db.Sessoes.Where(s => s.ID == IDCliente);

				// percorrer até encontrar o preço da sessão selecionada
				foreach (var clientes in cliente)
				{
					preco = clientes.Preco;
				}
			}

			//apresentar o valor
			return preco;
		}

		//método para gerar o bilhete em ficheiro .txt
		public static string GerarBilhete(int sessao, string sala, string filme, DateTime data, int hora, int minuto, string nome, string[] cadeira, float preco, int contador)
		{
			//caminho para armazenar bilhete
			string caminhoBilhete = "../../Bilhetes/Bilhete.txt";

			//definir o stream de ligação ao ficheiro em modo append e para escrita
			FileStream fs = new FileStream(caminhoBilhete, FileMode.Append, FileAccess.Write);

			//criar o buffer de texto de escrita
			StreamWriter sw = new StreamWriter(fs);

			//guardar os dados no ficheiro
			sw.WriteLine("\n\n---------------------------------------");
            sw.WriteLine("Sessão: " + sessao);
			sw.WriteLine("Cliente: " + nome);
			sw.WriteLine("\nFilme: " + filme);
			sw.WriteLine("Data: " + data.Day + "/" + data.Month + "/" + data.Year);
			sw.WriteLine("Hora: " + hora);
			sw.WriteLine("Minuto: " + minuto);
			preco = preco * contador;
			sw.WriteLine("Preço: " + preco + "€");
			sw.WriteLine("Sala: " + sala);
			foreach (string cadeiraSelecionada in cadeira)
			{
				sw.WriteLine("Lugar: " + cadeiraSelecionada);
			}
			sw.WriteLine("\nFuncionário: " + LoginController.GetNome());
			sw.WriteLine("\n\n\nBilhete emitido em: " + DateTime.Now);
			sw.WriteLine("---------------------------------------");

			//fechar o ficheiro e o stream
			sw.Close();
			fs.Close();

			//gerar bilhete final
			return caminhoBilhete;
		}

		//método para guardar o bilhete na Base Dados
		public static void CriarBilhete(float preco, bool estado, int cliente, int cadeiras, int sessao)
		{
			//abrir ligação com a base dados
			using (var db = new CinemaContext())
			{
				//criar novo Bilhete na Base Dados
				Bilhete b = new Bilhete();

				//verifica se a tabela existe na base dados

				//calcular preço
				preco = preco * cadeiras;
				b.Preco = preco;

				b.Lugar = cadeiras;

				b.Estado = estado.ToString();
				b.Cliente = cliente;
				b.IdSessao = sessao;

				//armazenar novo bilhete
				db.Bilhetes.Add(b);
				db.SaveChanges();

			}
		}
	}
}
