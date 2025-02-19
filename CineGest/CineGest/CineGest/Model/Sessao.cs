using CineGest.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineGest.Model
{
    public class Sessao
    {
        //campos para a tabela Sessao
        public int ID { get; set; }
        public int hora { get; set; }

        public DateTime data { get; set; }
        public int minuto { get; set; }
        public float Preco { get; set; }

        public Filme Filme { get; set; }

        public Sala Sala { get; set; }

        //construtor do modelo
        public Sessao()
        {

        }

        //permite a escrita do ID
		public override string ToString()
		{
			return ID.ToString();

		}
	}
}
