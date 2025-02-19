using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineGest.Model
{
    public class Cinema
    {
        //campos para a tabela Cinema
        public int ID { get; set; }
        public string nome { get; set; }
        public  string morada { get; set; }
        public string email { get; set; }

		//construtor do modelo
		public Cinema()
        {

        }
    }
}
