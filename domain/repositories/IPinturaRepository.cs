using domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.repositories
{
    public interface IPinturaRepository
    {
        Task<string> Agregar(Pintura pintura);

        Task<string> Actualizar(Pintura pintura);

        Task<string> Eliminar(int id);

        Task<List<Pintura>> BuscarPorIdUsuario(int id);

        Task<List<Pintura>> Listar();
    }
}
