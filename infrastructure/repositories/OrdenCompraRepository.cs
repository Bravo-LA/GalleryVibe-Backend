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
    public class OrdenCompraRepository : IOrdenCompraRepository
    {
        private readonly ApplicationDbContext _context;

        public OrdenCompraRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Actualizar(OrdenCompra ordenCompra)
        {
            try
            {
                var ordencompraExistente = await _context.OrdenCompras.FindAsync(ordenCompra.id);
                if (ordencompraExistente != null)
                {
                    _context.Entry(ordencompraExistente).CurrentValues.SetValues(ordenCompra);
                    await _context.SaveChangesAsync();
                    return "Actualización exitosa";
                }
                return "Orden de Compra no encontrado";
            }
            catch (Exception ex)
            {
                return $"Error al actualizar: {ex.Message}";
            }
        }

        public async Task<string> Agregar(OrdenCompra ordenCompra)
        {
            try
            {
                await _context.OrdenCompras.AddAsync(ordenCompra);
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
                var ordenCompra = await _context.OrdenCompras.FindAsync(id);
                if (ordenCompra != null)
                {
                    _context.OrdenCompras.Remove(ordenCompra);
                    await _context.SaveChangesAsync();
                    return "Eliminado exitosamente";
                }
                return "Orden de Compra no encontrado";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar: {ex.Message}";
            }
        }

        public async Task<List<OrdenCompra>> Listar()
        {
            try
            {
                return await _context.OrdenCompras.ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<OrdenCompra>();
            }
        }
    }
}

