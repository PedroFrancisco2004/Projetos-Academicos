using CineGest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CineGest.Controller
{
    public class FormCategoriaController
    {
        //obter uma lista de todos os clientes registados
        public static List<Categoria> GetCategorias()
        {
            //criar lista
            List<Categoria> lst = new List<Categoria>();

            //abrir ligação com a base dados
            using (var db = new CinemaContext())
            {
                //listar as categorias
                lst = db.Categorias.ToList();
            }

            //apresentar resultado da lista
            return lst;
        }

        //método para declarar uma nova categoria
        public static void categoria(string nomeCategoria, bool estado)
        {
            //abrir ligação com a base dados
            using (var db = new CinemaContext())
            {
                //se o nomeCategoria inserido não existir na base dados
                if (!db.Categorias.Where(ct => ct.NomeCategoria == nomeCategoria).ToList().Any())
                {
                    //criar nova categoria
                    Categoria ct = new Categoria();
                    ct.NomeCategoria = nomeCategoria;
                    ct.Activa = estado.ToString();

                    //armazenar nova categoria
                    db.Categorias.Add(ct);
                    db.SaveChanges();

                    MessageBox.Show("Categoria criada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //se o nomeCategoria inserido existir na base dados
                else
                {
                    MessageBox.Show("A categoria não foi criada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //método para alterar categoria
        public static void altercategoria(int identificador, string nomeCategoria, bool estado)
        {
            //abrir ligação com a base dados
            using (var db = new CinemaContext())
            {
				//se não encontrar um filme associado à categoria pretendida
				if (!db.Filmes.Where(f => f.Categoria.ID == identificador).ToList().Any())
                {
					//se existir uma categoria com o mesmo nome
					if (db.Categorias.Where(c => c.NomeCategoria == nomeCategoria).ToList().Any() && db.Categorias.Where(c => c.Activa == estado.ToString()).ToList().Any())
					{
						MessageBox.Show("Os dados inseridos não foram registados!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					//se o novo nomeCategoria inserida não existir na base dados
					else
					{
						//selecionar o ID pretendido
						var categorias = db.Categorias.Where(c => c.ID == identificador).ToList();

						//percorrer todos os campos da tabela Categorias e fazer edição do registo selecionado
						foreach (var categoria in categorias)
						{
							categoria.NomeCategoria = nomeCategoria;
							categoria.Activa = estado.ToString();

						}

						//armazenar os dados na base dados
						db.SaveChanges();
						MessageBox.Show("Dados alterados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
				//se encontrar filme
				else
                {
					MessageBox.Show("A categoria não foi alterada devido a já estar atribuída a um filme!", "Proibido", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
        }

        //método para apagar categoria
        public static void apagarCategoria(int identificador)
        {
            //abrir ligação com a base dados
            using (var db = new CinemaContext())
            {
				//se não encontrar um filme associado à categoria pretendida
				if (!db.Filmes.Where(f => f.Categoria.ID == identificador).ToList().Any())
                {
					//selecionar o ID pretendido
					var categorias = db.Categorias.Where(c => c.ID == identificador).ToList();

					//percorrer todos os campos da tabela Categorias e fazer a eliminação do registo selecionado
					foreach (var categoria in categorias)
					{
						//apagar a categoria
						db.Categorias.Remove(categoria);
					}

					//armazenar as alterações na base dados
					db.SaveChanges();
					MessageBox.Show("Dados apagados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				//se encontrar filme
				else
				{
					MessageBox.Show("A categoria não foi apagada devido a já estar atribuída a um filme!", "Proibido", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
        }
    }
}
