using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineGest.Model
{
    public class Login
    {
        //campos para a tabela Login
        public int ID { get; set; }
        public string Utilizador { get; set; }
        public string Password { get; set; }


		//construtor do modelo
		public Login()
        {

        }
    }
}
