using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineGest.Model
{
    public class Pessoa
    {
        //campos para serem herdados nas tabelas Funcionario e Cliente
        public string Nome { get; set; }
        public string Morada { get; set; }

		//construtor do modelo
		public Pessoa()
        {

        }
    }
}
