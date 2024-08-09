using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.entities
{
    public class OrdenCompra
    {
        public int id { get; set; }
        public string Usuario { get; set; }
        public DateTime feichaCreacion { get; set; }
        public string? estadoOrden { get; set; }
        public decimal totalOrden { get; set; }
        public int idImagen { get; set; }
        public int cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string? MetodoPago { get; set; }
        public string? DireccionEnvio { get; set; }
        public string? ComentariosAdicionales { get; set; }
    }
}
