using CineGest.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineGest.Model
{
    public class Filme
    {
        //campos para a tabela Filme
        public int ID { get; set; }
        public string NomeFilme { get; set; }
        public string Duracao { get; set; }
        public string Activo { get; set; }

        //chave estrangeira
        public Categoria Categoria { get; set; }

		//construtor do modelo
		public Filme()
        {

        }

		//permite a escrita do NomeFilme
		public override string ToString()
        {
            return NomeFilme;

        }
    }
}
