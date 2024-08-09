using domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.repositories
{
    public interface IOrdenCompraRepository

    {
        Task<string> Agregar(OrdenCompra OrdenCompra);

        Task<string> Actualizar(OrdenCompra OrdenCompra);

        Task<string> Eliminar(int id);

        Task<List<OrdenCompra>> Listar();
    }
}
