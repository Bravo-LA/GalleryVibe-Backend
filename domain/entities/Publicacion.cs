using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.entities
{
    public class Publicacion
    {
        public int Id { get; set; }
        public string Imagen { get; set; }
        public string Titulo { get; set; }
        public float Precio { get; set; }
        public string Categoria { get; set; }
        public bool Estado { get; set; }
        public string Detalles { get; set; }
    }
}
