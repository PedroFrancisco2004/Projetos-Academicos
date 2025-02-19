using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineGest.Model
{
    public class Sala
    {
        //campos para a tabela Sala
        public int ID { get; set; }
        public string NomeSala { get; set; }
        public int Coluna { get; set; }
        public int Fila { get; set; }

		//construtor do modelo
		public Sala()
        {

        }

		//permite a escrita do NomeSala
		public override string ToString()
        {
            return NomeSala;

        }
    }
}
