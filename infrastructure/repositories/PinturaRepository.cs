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
    public class PinturaRepository : IPinturaRepository
    {
        private readonly ApplicationDbContext _context;

        public PinturaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Actualizar(Pintura pintura)
        {
            try
            {
                var pinturaExistente = await _context.Pinturas.FindAsync(pintura.Id);
                if (pinturaExistente != null)
                {
                    _context.Entry(pinturaExistente).CurrentValues.SetValues(pintura);
                    await _context.SaveChangesAsync();
                    return "Actualización exitosa";
                }
                return "Pintura no encontrado";
            }
            catch (Exception ex)
            {
                return $"Error al actualizar: {ex.Message}";
            }
        }

        public async Task<string> Agregar(Pintura pintura)
        {
            try
            {
                await _context.Pinturas.AddAsync(pintura);
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
                var pintura = await _context.Pinturas.FindAsync(id);
                if (pintura != null)
                {
                    _context.Pinturas.Remove(pintura);
                    await _context.SaveChangesAsync();
                    return "Eliminado exitosamente";
                }
                return "Pintura no encontrado";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar: {ex.Message}";
            }
        }
        public async Task<List<Pintura>> Listar()
        {
            try
            {
                return await _context.Pinturas.ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<Pintura>();
            }
        }

        public async Task<List<Pintura>> BuscarPorIdUsuario(int id)
        {
            try
            {
                var pinturas = await _context.Pinturas
                                .Where(p => p.UsuarioId == id)
                                .ToListAsync();
                return pinturas;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
