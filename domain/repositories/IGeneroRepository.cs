using domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.repositories
{
    public interface IGeneroRepository
    {
        Task<string> Agregar(Genero genero);

        Task<string> Actualizar(Genero genero);

        Task<string> Eliminar(int id);

        Task<List<Genero>> Listar();
    }
}
