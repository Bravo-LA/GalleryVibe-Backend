using domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.repositories
{
    public interface IVentasRepository
    {
        Task<int> Crear(Ventas ventas);
        Task<Ventas?> ObtenerPorId(int id);
        Task<List<Ventas>> ObtenerTodos();
    }
}
