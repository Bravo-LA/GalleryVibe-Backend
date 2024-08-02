using domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.repositories
{
    public interface ITecnicaRepository
    {
        Task<string> Agregar(Tecnica tecnica);

        Task<string> Actualizar(Tecnica tecnica);

        Task<string> Eliminar(int id);

        Task<List<Tecnica>> Listar();
    }
}
