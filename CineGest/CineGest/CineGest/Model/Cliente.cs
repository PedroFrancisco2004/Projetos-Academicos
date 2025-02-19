using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineGest.Model
{
    public class Cliente : Pessoa
    {
        //campos para a tabela Cliente
        public int ID { get; set; }
        public int numFiscal { get; set; }

		//construtor do modelo
		public Cliente()
        {

        }
    }
}
