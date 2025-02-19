using CineGest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CineGest.Controller
{
    public class FormPrincipalController
    {
        //listar as sessões pelo dia atual
        public static List<Sessao> GetSessoes()
        {
            //criar lista
            List<Sessao> lst = new List<Sessao>();

            //abrir ligação com a base dados
                using (var db = new CinemaContext())
                {
                    //listar as sessões incluindo a apresentação do filme e sala por substituição dos ids por string
                    lst = db.Sessoes.Include("Filme").Include("Sala").Where(s => s.data == DateTime.Today).ToList();
                }

                //apresentar resultado da lista
                return lst;
        }

        //método para verificar se o cinema está registado
        public static bool VerificarCinemaRegistado()
        {
            //abrir ligação com a base dados
            using (var db = new CinemaContext())
            {
                //selecionar o registo que contêm os dados do cinema
                Cinema cinema = db.Cinema.FirstOrDefault(c => c.ID == 1);

                //se os dados do cinema existirem
                if (cinema != null)
                {
                    return true;
                }
                // se não
                else
                {
                    return false;
                }
            }
        }
    }
}
