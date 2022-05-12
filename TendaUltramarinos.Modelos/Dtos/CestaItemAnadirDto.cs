using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TendaUltramarinos.Modelos.Dtos
{
    public class CestaItemAnadirDto
    {
        public int CestaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidade { get; set; }
    }
}
