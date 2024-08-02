using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.entities
{
    public class Usuario
    {
        public int Id { get; set; }

        public string? Nombres { get; set; }

        public string? Apellidos { get; set; }

        public string? Cedula { get; set; }

        public string? Correo { get; set; }

        public int GeneroId { get; set; }

        public DateTime FechaNac { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public virtual Genero? Genero { get; set; }

        public virtual ICollection<Pintura> Pinturas { get; set; } = new List<Pintura>();

    }
}
