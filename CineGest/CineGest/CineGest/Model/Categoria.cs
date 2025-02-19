using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineGest.Controller
{
    public class Categoria
    {
        //campos para a tabela Categoria
        public int ID { get; set; }
        public string NomeCategoria { get; set; }
        public string Activa { get; set; }

		//permite a escrita do NomeCategoria
		public override string ToString()
        {
            return NomeCategoria;
        }

		//construtor do modelo
		public Categoria()
        {

        }
    }
}
