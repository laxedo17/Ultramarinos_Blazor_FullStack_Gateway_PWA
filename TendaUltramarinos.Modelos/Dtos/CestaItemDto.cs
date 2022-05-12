using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TendaUltramarinos.Modelos.Dtos
{
    public class CestaItemDto
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int CestaId { get; set; }
        public string ProductoNome { get; set; }
        public string ProductoDescripcion { get; set; }
        public string ProductoImaxeUrl { get; set; }
        public decimal Precio { get; set; }
        public decimal PrecioTotal { get; set; }
        public int Cantidade { get; set; }
    }
}
