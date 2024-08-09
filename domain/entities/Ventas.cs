using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.

namespace domain.entities
{
    public class Ventas
    {
        public int Id { get; set; }
        public int Precio { get; set; }

        public virtual Publicacion Publicacion { get; set; }
        public int PublicacionId { get; set; }

    }
}
