using TendaUltramarinos.Api.Entidades;
using TendaUltramarinos.Modelos.Dtos;

namespace TendaUltramarinos.Api.Extensions
{
    /// <summary>
    /// Extension method para transformar unha coleccion IEnumerable de tipo Producto a unha coleccion IEnumerable de tipo ProductoDto e obter CategoriaNome como cando facemos un Join con Linq usando o metodo de Linq chamado Include
    /// </summary>
    public static class DtoConversions
    {
        /// <summary>
        /// Anque o Dto de ProductoCategoria e a entidade ProductoCategoria tenhen as mesmas propiedades e isto non deberia ser necesario.
        /// Isto son best practices.
        /// Porque poden cambiar os requerimentos.
        /// Asi mantemos unha clara separation of concerns
        /// entre as clases Dto e as Entidades da BD.
        /// Asi as clases Dto poden evolucionar
        /// sen afectar as suas correspondentes clases de Entidade.
        /// </summary>
        /// <param name="productoCategorias"></param>
        /// <returns></returns>
        public static IEnumerable<ProductoCategoriaDto> ConvertirADto(this IEnumerable<ProductoCategoria> productoCategorias)
        {
            return (from productoCategoria in productoCategorias
                    select new ProductoCategoriaDto
                    {
                        Id = productoCategoria.Id,
                        Nome = productoCategoria.Nome,
                        IconoCss = productoCategoria.IconoCss
                    }).ToList();
        }
        public static IEnumerable<ProductoDto> ConvertirADto(this IEnumerable<Producto> productos, IEnumerable<ProductoCategoria> productoCategorias)
        {
            return (from producto in productos
                    join productoCategoria in productoCategorias
                    on producto.CategoriaId equals productoCategoria.Id
                    select new ProductoDto
                    {
                        Id = producto.Id,
                        Nome = producto.Nome,
                        Descripcion = producto.Descripcion,
                        ImaxeUrl = producto.ImaxeUrl,
                        Precio = producto.Precio,
                        Cantidade = producto.Cantidade,
                        CategoriaId = producto.CategoriaId,
                        CategoriaNome = productoCategoria.Nome
                    }).ToList();
        }

        /// <summary>
        /// Overload de ConvertirADto que converte un unico obxecto de tipo Producto e ProductoCategoria a ProductoDto para obter o nome da categoria a que pertence, e obter os datos relevantes.
        /// </summary>
        /// <param name="productos"></param>
        /// <param name="productoCategorias"></param>
        /// <returns></returns>
        public static ProductoDto ConvertirADto(this Producto producto, ProductoCategoria productoCategoria)
        {
            return new ProductoDto
            {
                Id = producto.Id,
                Nome = producto.Nome,
                Descripcion = producto.Descripcion,
                ImaxeUrl = producto.ImaxeUrl,
                Precio = producto.Precio,
                Cantidade = producto.Cantidade,
                CategoriaId = producto.CategoriaId,
                CategoriaNome = productoCategoria.Nome
            };
        }

        /// <summary>
        /// Transforma unha lista de elementos da cesta e de productos da cesta nunha lista de elementos da cesta da compra cun resumen das caracteristicas de ambos, entidades CestaItem e Producto
        /// </summary>
        /// <param name="cestaItems"></param>
        /// <param name="productos"></param>
        /// <returns></returns>
        public static IEnumerable<CestaItemDto> ConvertirADto(this IEnumerable<CestaItem> cestaItems, IEnumerable<Producto> productos)
        {
            return (from cestaItem in cestaItems
                    join producto in productos
                    on cestaItem.ProductoId equals producto.Id
                    select new CestaItemDto
                    {
                        Id = cestaItem.Id,
                        ProductoId = cestaItem.ProductoId,
                        ProductoNome = producto.Nome,
                        ProductoDescripcion = producto.Descripcion,
                        ProductoImaxeUrl = producto.ImaxeUrl,
                        Precio = producto.Precio,
                        CestaId = cestaItem.CestaId,
                        Cantidade = cestaItem.Cantidade,
                        PrecioTotal = producto.Precio * cestaItem.Cantidade
                    }).ToList();
        }

        /// <summary>
        /// Devolve informacion dun unico CestaItemDto, cunha mezcla das caracteristias de CestaItem e de Producto
        /// </summary>
        /// <param name="cestaItem"></param>
        /// <param name="producto"></param>
        /// <returns></returns>
        public static CestaItemDto ConvertirADto(this CestaItem cestaItem, Producto producto)
        {
            return new CestaItemDto
            {
                Id = cestaItem.Id,
                ProductoId = cestaItem.ProductoId,
                ProductoNome = producto.Nome,
                ProductoDescripcion = producto.Descripcion,
                ProductoImaxeUrl = producto.ImaxeUrl,
                Precio = producto.Precio,
                CestaId = cestaItem.CestaId,
                Cantidade = cestaItem.Cantidade,
                PrecioTotal = producto.Precio * cestaItem.Cantidade
            };
        }
    }
}
