using CineGest.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineGest.Model
{
    public class Bilhete
    {
        //campos para a tabela Bilhete
        public int ID { get; set; }
        public float Preco { get; set; }
        public int Lugar { get; set; }
        public string Estado { get; set; }
		public int Cliente { get; set; }
		public int IdSessao { get; set; }

		//construtor do modelo
		public Bilhete()
        {

        }
    }
}
