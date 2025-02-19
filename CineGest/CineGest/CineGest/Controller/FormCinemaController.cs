using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CineGest.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace CineGest.Controller
{
    public class FormCinemaController
    {
        //obter uma lista de todas as salas registadas
        public static List<Sala> GetSalas()
        {
            //criar lista
            List<Sala> lst = new List<Sala>();

            //abrir ligação com a base dados
            using (var db = new CinemaContext())
            {
                //listar todas as salas
                lst = db.Salas.ToList();
            }

            //apresentar resultado da lista
            return lst;
        }

        //obter os dados do cinema registado
        public static List<Cinema> GetCinema()
        {
            // criar lista
            List<Cinema> lst = new List<Cinema>();

            //abrir ligação com a base dados
            using (var db = new CinemaContext())
            {
                //listar os dados do cinema
                lst = db.Cinema.ToList();
            }

            //apresentar resultado
            return lst;
        }

        //método para declarar uma nova sala
        public static void sala(string salas, int colunas, int filas)
        {
            //abrir ligação com a base dados
            using (var db = new CinemaContext())
            {
                //se o nomeSala inserido não existir na base dados
                if (!db.Salas.Where(s => s.NomeSala == salas).ToList().Any())
                {
                    //criar nova sala
                    Sala s = new Sala();
                    s.NomeSala = salas;
                    s.Coluna = colunas;
                    s.Fila = filas;

                    //armazenar nova sala
                    db.Salas.Add(s);
                    db.SaveChanges();

                    MessageBox.Show("Sala criada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
				//se o nomeSala inserido existir na base dados
				else
				{
                    MessageBox.Show("A sala não foi criada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //método para editar sala
        public static void alterSala(int identificador, string nomeSala, int numeroColunas, int numeroFilas)
        {
            //abrir ligação com a base dados
            using (var db = new CinemaContext())
            {
                //se a NomeSala existir na base dados
                if (db.Salas.Where(c => c.NomeSala == nomeSala).ToList().Any())
                {
                    MessageBox.Show("Os dados inseridos não foram registados!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
				//se o nomeSala inserido não existir na base dados
				else
				{
                    var salas = db.Salas.Where(c => c.ID == identificador).ToList();

                    //percorrer todos os campos da tabela Sala e fazer edição da Sala pretendida
                    foreach (var sala in salas)
                    {
                        sala.NomeSala = nomeSala;
                        sala.Coluna = numeroColunas;
                        sala.Fila = numeroFilas;
                    }

                    //armazenar os dados
                    db.SaveChanges();
                    MessageBox.Show("Dados alterados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        //método para adicionar os dados do cinema
        public static void addCinema(string nomeCinema, string moradaCinema, string emailCinema)
        {
            //abrir ligação com a base dados
            using (var db = new CinemaContext())
            {
                //se não existir dados do cinema na base dados
                if (!db.Cinema.Where(c => c.ID == 1).ToList().Any())
                {
                    //criar dados do cinema
                    Cinema c = new Cinema();
                    c.nome = nomeCinema;
                    c.morada = moradaCinema;
                    c.email = emailCinema;

                    //armazenar dados do cinema
                    db.Cinema.Add(c);
                    db.SaveChanges();
                    
                    MessageBox.Show("Cinema registado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
				//se os dados cinema já existirem na base dados
				else
				{
                    MessageBox.Show("Os dados inseridos não foram registados!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //método para alterar os dados do cinema
        public static void alterCinema(string nomeCinema, string moradaCinema, string emailCinema)
        {
            //abrir ligação com a base dados
            using (var db = new CinemaContext())
            {
                //se não existir um registo dos dados do cinema
                if (!db.Cinema.Where(c => c.ID == 1).ToList().Any())
                {
                    MessageBox.Show("Os dados inseridos não foram registados!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //se existir dados do cinema
                else
                {
                    //selecionar o registo na base dados que contêm os dados do cinema
                    var cinemas = db.Cinema.Where(c => c.ID == 1).ToList();

                    //percorrer todos os campos da tabela Cinema e fazer edição dos dados do cinema
                    foreach (var cinema in cinemas)
                    {
                        cinema.nome = nomeCinema;
                        cinema.morada = moradaCinema;
                        cinema.email = emailCinema;
                    }

                    //armazenar os dados na base dados
                    db.SaveChanges();
                    MessageBox.Show("Dados alterados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
