using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TendaUltramarinos.Modelos.Dtos
{
    /// <summary>
    /// Dto ou Data Transfer Object para intercambiar os datos relevantes
    /// dun producto entre Servidor e Cliente e que o Cliente
    /// tenha acceso aos datos mais relevantes do producto
    /// </summary>
    public class ProductoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descripcion { get; set; }
        public string ImaxeUrl { get; set; }
        public decimal Precio { get; set; }
        public int Cantidade { get; set; }
        public int CategoriaId { get; set; }
        public string CategoriaNome { get; set; }
    }
}
