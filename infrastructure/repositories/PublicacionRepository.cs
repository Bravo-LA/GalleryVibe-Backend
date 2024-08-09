using domain.entities;
using domain.repositories;
using infrastructure.context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.repositories
{
	public class PublicacionRepository : IPublicacionRepository
    {
        private readonly ApplicationDbContext _context;

        public PublicacionRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Crear(Publicacion publicacion)
        {
            context.Add(publicacion);
            await context.SaveChangesAsync();
            return publicacion.Id;
        }

        public async Task<int> CambiarEstadoActivo(int id)
        {
            Publicacion publicacion = await context.Publicacions.FindAsync(id); 
            publicacion.Estado = 1;
            await context.SaveChangesAsync();
            return publicacion.Id;
        }

        public async Task<Publicacion?> ObtenerPorId(int id)
        {
            return await context.Publicacions.FindAsync(id);
        }

        public async Task<List<Publicacion>> ObtenerTodos()
        {
            return context.Publicacions.Where(g => g.Estado == 1).ToList();
        }

        public async Task EliminarPublicacion(int id)
        {
            Publicacion publicacion = await context.Publicacions.FindAsync(id);
            context.Publicacions.Remove(publicacion);
            context.SaveChanges();
        }

        public async Task<int> ModificarPublicacion(Publicacion publicacion)
        {
            Publicacion objPub = await context.Publicacions.FindAsync(publicacion.Id);
            objPub.Nombre = publicacion.Titulo;
            objPub.Estado = publicacion.Estado;
            objPub.Imagen = publicacion.Imagen;
            objPub.Precio = publicacion.Precio;
            objPub.Categoria = publicacion.Categoria;
            objPub.Detalles = publicacion.Detalles;
            await context.SaveChangesAsync();
            return objGenero.Id;
        }

    }
}