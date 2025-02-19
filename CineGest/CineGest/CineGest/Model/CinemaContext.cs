using CineGest.Controller;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineGest.Model
{
    public class CinemaContext : DbContext
    {
        //tabelas da base dados que são interligadas às respetivas classes do programa
        public DbSet<Login> Logins { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Cinema> Cinema { get; set; }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Sessao> Sessoes { get; set; }

		public DbSet<Bilhete> Bilhetes { get; set; }
	}
}
