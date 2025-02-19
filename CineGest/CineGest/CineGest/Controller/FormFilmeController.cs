using CineGest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CineGest.Controller
{
    public class FormFilmeController
    {
        //obter uma lista de todas os Filmes registados
        public static List<Filme> GetFilmes()
        {
            //criar lista
            List<Filme> lst = new List<Filme>();

            //abrir ligação com a base dados
            using (var db = new CinemaContext())
            {
                //listar as categorias incluindo a apresentação do id que representa a categoria por string
                lst = db.Filmes.Include("Categoria").ToList();
            }

            //apresentar resultado da lista
            return lst;
        }

        //listar as categorias com o estado True
        public static List<Categoria> CategoriasTrue()
        {
            //criar lista
            List<Categoria> lst = new List<Categoria>();

            //abrir ligação com a base dados
            using (var db = new CinemaContext())
            {
                //guardar o valor desejado
                string textoProcurado = "True";

                //listar as categorias cujo um dos campos contenha True
                lst = db.Categorias.Where(p => p.Activa.Contains(textoProcurado)).ToList();
            }

            //apresentar resultado da lista
            return lst;
        }


        //método para declarar um novo filme
        public static void addFilme(string nomeFilme, string duracao, bool estado, Categoria categoriaNome)
        {

            //abrir ligação com a base dados
            using (var db = new CinemaContext())
            {
                //se o NomeFilme inserido não existir na base dados
                if (!db.Filmes.Where(f => f.NomeFilme == nomeFilme).ToList().Any())
                {
                    //criar novo filme
                    Filme f = new Filme();
                    f.NomeFilme = nomeFilme;
                    f.Duracao = duracao;
                    f.Activo = estado.ToString();
                    f.Categoria = db.Categorias.FirstOrDefault(c => c.ID == categoriaNome.ID);

                    //armazenar novo filme
                    db.Filmes.Add(f);
                    db.SaveChanges();

                    MessageBox.Show("Filme criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
				//se o nomeFilme inserido existir na base dados
				else
				{
                    MessageBox.Show("O filme não foi criado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //método para alterar filme
        public static void alterFilme(int identificador, string nomeFilme, string duracao, bool estado, Categoria categoriaNome)
        {
            //abrir ligação com a base dados
            using (var db = new CinemaContext())
            {
				//se não encontrar um filme associado a uma sessão
				if (!db.Sessoes.Where(s => s.Filme.NomeFilme == nomeFilme).ToList().Any())
                {
					//selecionar o filme pretendido
					var filmes = db.Filmes.Where(c => c.ID == identificador).ToList();

					//percorrer todos os campos da tabela Filmes e efetuar alteração dos dados do filme pretendido
					foreach (var filme in filmes)
					{
						filme.NomeFilme = nomeFilme;
						filme.Duracao = duracao;
						filme.Activo = estado.ToString();
						filme.Categoria = db.Categorias.FirstOrDefault(c => c.ID == categoriaNome.ID);
					}

					//armazenar as alterações
					db.SaveChanges();
					MessageBox.Show("Dados alterados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				//se encontrar sessão
				else
				{
					MessageBox.Show("O filme não foi alterado devido a já estar atribuído a uma sessão!", "Proibido", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}     
        }

        //método para eliminar filme
        public static void apagarFilme(int identificador, string nomeFilme)
        {
            //abrir ligação com a base dados
            using (var db = new CinemaContext())
            {
				//se não encontrar um filme associado a uma sessão
				if (!db.Sessoes.Where(s => s.Filme.NomeFilme == nomeFilme).ToList().Any())
                {
					//selecionar o filme pretendido
					var filmes = db.Filmes.Where(c => c.ID == identificador).ToList();

					//percorrer todos os campos da tabela Filmes e efetuar eliminação do cliente pretendido
					foreach (var filme in filmes)
					{
						db.Filmes.Remove(filme);
					}

					//armazenar as alterações
					db.SaveChanges();
					MessageBox.Show("Dados apagados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				//se encontrar sessão
				else
				{
					MessageBox.Show("O filme não foi apagado devido a já estar atribuído a uma sessão!", "Proibido", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
        }
    }
}
