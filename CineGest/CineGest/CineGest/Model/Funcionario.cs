using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineGest.Model
{
    internal class Funcionario : Pessoa
    {
        //campos para a tabela Funcionario
        public int ID { get; set; }
        public float Salario { get; set; }
        public string Funcao { get; set; }

		//construtor do modelo
		public Funcionario()
        {

        }
    }
}
