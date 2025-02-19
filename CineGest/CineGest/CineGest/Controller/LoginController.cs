using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CineGest.Model;

namespace CineGest.Controller
{
     public class LoginController
     {
        //atributo para guardar o utilizador com a sessão iniciada no momento
        private static int UtilizadorLogin = 0;

        //obter o nome de utilizador com a sessão iniciada
        public static string GetNome()
        {
            //abrir ligação com a base dados
            using (var db = new CinemaContext())
            {
                //apresentar nome de utilizador
                return db.Logins.Find(UtilizadorLogin).Utilizador;
            }

        }

        //método para iniciar login pelo utilizador autorizado e registado na base dados
        public static bool login(string username, string password)
        {
            //abrir ligação com a base dados
            using (var db = new CinemaContext())
            {
                //validar todos os dados do utilizador e verificar se estão registados e autorizados para entrarem no programa
                Login login = db.Logins.FirstOrDefault(h => h.Utilizador == username);
                if (login != null && login.Password == password)
                {
                   //se sim, permite a entrada no programa
                   UtilizadorLogin = login.ID;
                   return true;
                }
                else
                {
                   //se não, não entra no programa
                   return false;
                }
            }
        }

        //método para registar um novo utilizador na base dados
        public static bool Registar(string username, string password)
        {
            //abrir ligação com a base dados
            using (var db = new CinemaContext())
            {
                 //se o Utilizador (nome) inserido não existir na base dados
                 if (!db.Logins.Where(h => h.Utilizador == username).ToList().Any())
                 {
                     //criar novo utilizador
                     Login l = new Login();
                     l.Utilizador = username;
                     l.Password = password;
                        
                     //armazenar novo utilizador
                     db.Logins.Add(l);
                     db.SaveChanges();

                     return true;
                 }
                 else
                 {   //caso não aconteça, apresenta mensagem de erro
                     return false;
                 }
            }    
        }
     }
}


