using domain.entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace domain.repositories
{
    public interface IContactoRepository
    {
        Task<string> Agregar(Contacto contacto);
        Task<string> Actualizar(Contacto contacto);
        Task<string> Eliminar(int id);
        Task<Contacto> BuscarPorId(int id);
        Task<List<Contacto>> Listar();
    }
}