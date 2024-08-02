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
    public class GeneroRepository : IGeneroRepository
    {
        private readonly ApplicationDbContext _context;

        public GeneroRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Actualizar(Genero genero)
        {
            try
            {
                var generoExistente = await _context.Generos.FindAsync(genero.Id);
                if (generoExistente != null)
                {
                    _context.Entry(generoExistente).CurrentValues.SetValues(genero);
                    await _context.SaveChangesAsync();
                    return "Actualización exitosa";
                }
                return "Género no encontrado";
            }
            catch (Exception ex)
            {
                return $"Error al actualizar: {ex.Message}";
            }
        }

        public async Task<string> Agregar(Genero genero)
        {
            try
            {
                await _context.Generos.AddAsync(genero);
                await _context.SaveChangesAsync();
                return "Agregado exitosamente";
            }
            catch (Exception ex)
            {
                return $"Error al agregar: {ex.Message}";
            }
        }

        public async Task<string> Eliminar(int id)
        {
            try
            {
                var genero = await _context.Generos.FindAsync(id);
                if (genero != null)
                {
                    _context.Generos.Remove(genero);
                    await _context.SaveChangesAsync();
                    return "Eliminado exitosamente";
                }
                return "Género no encontrado";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar: {ex.Message}";
            }
        }

        public async Task<List<Genero>> Listar()
        {
            try
            {
                return await _context.Generos.ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<Genero>();
            }
        }
    }
}
