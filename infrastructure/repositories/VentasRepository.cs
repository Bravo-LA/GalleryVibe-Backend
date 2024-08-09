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
    public class VentasRepository : IVentasRepository
    {
        private readonly ApplicationDbContext context;

        public VentasRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Crear(Ventas ventas)
        {
            context.Ventass.Add(ventas);
            await context.SaveChangesAsync();

            return ventas.Id;
        }

        public async Task<Ventas?> ObtenerPorId(int id)
        {
            return context.Ventass.Where(x => x.Id == id)
                .Include(x => x.Publicacion)
                .ToList()[0];

        }

        public async Task<List<Ventas>> ObtenerTodos()
        {
            return await context.Ventass.ToListAsync();
        }
    }
}
