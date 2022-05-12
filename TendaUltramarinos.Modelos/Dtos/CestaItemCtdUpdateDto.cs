using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TendaUltramarinos.Modelos.Dtos
{
    /// <summary>
    /// Controla a cantidade de elementos dun producto da cesta da compra
    /// </summary>
    public class CestaItemCtdUpdateDto
    {
        public int CestaItemId { get; set; }
        public int Cantidade { get; set; }
    }
}
