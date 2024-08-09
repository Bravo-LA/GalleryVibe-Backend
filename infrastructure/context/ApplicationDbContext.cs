using domain.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }


        public DbSet<Genero> Generos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Tecnica> Tecnicas { get; set; }

        public DbSet<Pintura> Pinturas { get; set; }

        public DbSet<Ventas> Ventass { get; set; }

        public DbSet<Publicacion> Publicacions { get; set; }

        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<OrdenCompra> OrdenCompras { get; set; }

    }
}
