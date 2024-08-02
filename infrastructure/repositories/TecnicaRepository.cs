using domain.entities;
using domain.repositories;
using infrastructure.context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.repositories
{
    public class TecnicaRepository : ITecnicaRepository
    {
        private readonly ApplicationDbContext _context;

        public TecnicaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Actualizar(Tecnica tecnica)
        {
            try
            {
                var tecnicaExistente = await _context.Tecnicas.FindAsync(tecnica.Id);
                if (tecnicaExistente != null)
                {
                    _context.Entry(tecnicaExistente).CurrentValues.SetValues(tecnica);
                    await _context.SaveChangesAsync();
                    return "Actualización exitosa";
                }
                return "Técnica no encontrado";
            }
            catch (Exception ex)
            {
                return $"Error al actualizar: {ex.Message}";
            }
        }

        public async Task<string> Agregar(Tecnica tecnica)
        {
            try
            {
                await _context.Tecnicas.AddAsync(tecnica);
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
                var tecnica = await _context.Tecnicas.FindAsync(id);
                if (tecnica != null)
                {
                    _context.Tecnicas.Remove(tecnica);
                    await _context.SaveChangesAsync();
                    return "Eliminado exitosamente";
                }
                return "Técnica no encontrado";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar: {ex.Message}";
            }
        }

        public async Task<List<Tecnica>> Listar()
        {
            try
            {
                return await _context.Tecnicas.ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<Tecnica>();
            }
        }
    }
}
