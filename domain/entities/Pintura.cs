using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.entities
{
    public class Pintura
    {
        public int Id { get; set; }

        public string? Titulo { get; set; }

        public string? Descripcion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string? Tipo { get; set; }

        public decimal Precio { get; set; }

        public int TecnicaId { get; set; }

        public string? ImageUrl { get; set; }

        public int UsuarioId { get; set; }

        public virtual Tecnica? Tecnica { get; set; }

        public virtual Usuario? Usuario { get; set; }
    }
}
