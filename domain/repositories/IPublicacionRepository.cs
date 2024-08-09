using domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.repositories
{
    public interface IPublicacionRepository
    {
        Task<int> Crear(Publicacion publicacion);
        Task<int> CambiarEstadoActivo(int id);
        Task<Publicacion?> ObtenerPorId(int id);
        Task<List<Publicacion>> ObtenerTodos();
        Task EliminarPublicacion(int id);
        Task<int> ModificarPublicacion(Publicacion publicacion);
    }
}
