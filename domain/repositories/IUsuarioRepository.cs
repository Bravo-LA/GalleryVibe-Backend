using domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.repositories
{
    public interface IUsuarioRepository
    {
        Task<string> Login(Credenciales credenciales);

        Task<string> Agregar(Usuario usuario);

        Task<string> Actualizar(Usuario usuario);

        Task<string> Eliminar(int id);

        Task<Usuario> BuscarPorId(int id);

        Task<List<Usuario>> Listar();
    }
}
