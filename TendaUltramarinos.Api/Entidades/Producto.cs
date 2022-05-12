using System.ComponentModel.DataAnnotations.Schema;

namespace TendaUltramarinos.Api.Entidades
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descripcion { get; set; }
        public string ImaxeUrl { get; set; }
        public decimal Precio { get; set; }
        public int Cantidade { get; set; }
        public int CategoriaId { get; set; }
        //representaremos aqui unha relacion 1 a moitos con entidade ProductoCategoria
        //unha Categoria pode incluir moitos productos
        //Cambio para millorar o rendemento da aplicacion
        [ForeignKey("CategoriaId")]
        public ProductoCategoria ProductoCategoria { get; set; }
    }
}
