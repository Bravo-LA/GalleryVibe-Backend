using domain.entities;
using domain.repositories;
using infrastructure.context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace infrastructure.repositories
{
    public class ContactoRepository : IContactoRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Agregar(Contacto contacto)
        {
            try
            {
                await _context.Contactos.AddAsync(contacto);
                await _context.SaveChangesAsync();
                return "Agregado exitosamente";
            }
            catch (Exception ex)
            {
                return $"Error al agregar: {ex.Message}";
            }
        }

        public async Task<string> Actualizar(Contacto contacto)
        {
            try
            {
                var contactoExistente = await _context.Contactos.FindAsync(contacto.Id);
                if (contactoExistente != null)
                {
                    _context.Entry(contactoExistente).CurrentValues.SetValues(contacto);
                    await _context.SaveChangesAsync();
                    return "Actualización exitosa";
                }
                return "Contacto no encontrado";
            }
            catch (Exception ex)
            {
                return $"Error al actualizar: {ex.Message}";
            }
        }

        public async Task<string> Eliminar(int id)
        {
            try
            {
                var contacto = await _context.Contactos.FindAsync(id);
                if (contacto != null)
                {
                    _context.Contactos.Remove(contacto);
                    await _context.SaveChangesAsync();
                    return "Eliminado exitosamente";
                }
                return "Contacto no encontrado";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar: {ex.Message}";
            }
        }

        public async Task<Contacto> BuscarPorId(int id)
        {
            try
            {
                return await _context.Contactos.FindAsync(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Contacto>> Listar()
        {
            try
            {
                return await _context.Contactos.ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<Contacto>();
            }
        }
    }
}
