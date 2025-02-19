using CineGest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CineGest.Controller
{
    public class FormSessaoController
    {
        //obter uma lista de filmes cuja sessão está a True
        public static List<Filme> GetFilmes()
        {
            //criar lista
            List<Filme> lst = new List<Filme>();

            //abrir ligação com a base dados
            using (var db = new CinemaContext())
            {
                //guardar o valor desejado
                string textoProcurado = "True";

                //procurar registos que contenha o valor True
                lst = db.Filmes.Where(f => f.Activo.Contains(textoProcurado)).ToList();
            }

            //apresentar resultado da lista
            return lst;
        }

        //listar as salas
        public static List<Sala> GetSalas()
        {
            //criar lista
            List<Sala> lst = new List<Sala>();

            //abrir ligação com a base dados
            using (var db = new CinemaContext())
            {
                //guardar o valor desejado
                lst = db.Salas.ToList();
            }

            //apresentar resultado da lista
            return lst;
        }

        //obter uma lista de todas as sessões registadas
        public static List<Sessao> GetSessoes()
        {
            //criar lista
            List<Sessao> lst = new List<Sessao>();

            //abrir ligação com a base dados
            using (var db = new CinemaContext())
            {
                //procurar os registos e substituir na visualização o id do filme e o id da sala para string
                lst = db.Sessoes.Include("Filme").Include("Sala").ToList();
            }

            //apresentar resultado da lista
            return lst;
        }

        //método para criar sessão
        public static void addSessao(int hora, int minuto, float preco, DateTime data, Filme filme, Sala sala)
        {
            //abrir ligação com a base de dados
            using (var db = new CinemaContext())
            {
                   //verificar se a sessão já existe na sala
                   if (!db.Sessoes.Where(c => c.hora == hora && c.minuto == minuto && c.data == data && c.Sala.ID == sala.ID).ToList().Any())
                   {
                       //criar nova sessão
                       Sessao s = new Sessao();
                       s.hora = hora;
                       s.minuto = minuto;
                       s.data = data;
                       s.Preco = preco;
                       s.Filme = db.Filmes.FirstOrDefault(f => f.ID == filme.ID);
                       s.Sala = db.Salas.FirstOrDefault(sl => sl.ID == sala.ID);

                       //armazenar nova sessão
                       db.Sessoes.Add(s);
                       db.SaveChanges();

                       MessageBox.Show("Sessão criada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   }
                   //se a sessão não foi criada
                   else
                   {
                       MessageBox.Show("A sessão não foi criada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   }
            }
        }

        //método para alterar sessão
        public static void alterSessao(int identificador_sessao, int hora, int minuto, float preco, DateTime data, Filme filme, Sala sala)
        {
            // abrir ligação com a base de dados
            using (var db = new CinemaContext())
            {
                //se não encontrar um bilhete associado à sessão pretendida
                if (!db.Bilhetes.Where(b => b.IdSessao == identificador_sessao).ToList().Any())
                {
					//selecionar o ID pretendido
					var sessoes = db.Sessoes.Where(c => c.ID == identificador_sessao).ToList();

					//percorrer todos os campos da tabela Categorias e fazer edição do registo selecionado
					foreach (var sessao in sessoes)
					{
						sessao.hora = hora;
						sessao.minuto = minuto;
						sessao.data = data;
						sessao.Preco = preco;
						sessao.Filme = db.Filmes.FirstOrDefault(f => f.ID == filme.ID);
						sessao.Sala = db.Salas.FirstOrDefault(sl => sl.ID == sala.ID);

					}

					//armazenar os dados na base dados
					db.SaveChanges();

					MessageBox.Show("Sessão alterada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
                //se encontrar bilhete
                else
                {
                    MessageBox.Show("A sessão não foi alterada devido a já estar atribuída a um bilhete!", "Proibido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

			}
		}

        //método apagar sessão
        public static void apagarSessao(int identificador_sessao)
        {
            //abrir ligação com a base dados
            using (var db = new CinemaContext())
            {
				//se não encontrar um bilhete associado à sessão pretendida
				if (!db.Bilhetes.Where(b => b.IdSessao == identificador_sessao).ToList().Any())
                {
					//selecionar o ID pretendido
					var sessoes = db.Sessoes.Where(c => c.ID == identificador_sessao).ToList();

					//percorrer todos os campos da tabela Categorias e fazer a eliminação do registo selecionado
					foreach (var sessao in sessoes)
					{
						db.Sessoes.Remove(sessao);
					}

					//armazenar as alterações na base dados
					db.SaveChanges();

					MessageBox.Show("Dados apagados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				//se encontrar bilhete
				else
				{
					MessageBox.Show("A sessão não foi apagada devido a já estar atribuída a um bilhete!", "Proibido", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
        }
    }
}
