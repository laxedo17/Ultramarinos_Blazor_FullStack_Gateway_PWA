using Microsoft.AspNetCore.Components;

using TendaUltramarinos.Modelos.Dtos;

using TendaUltramarinos_Blazor.Web.Servicios.Contratos;

namespace TendaUltramarinos_Blazor.Web.Pages
{
    public class ProductosPorCategoriaBase : ComponentBase
    {
        [Parameter]
        public int CategoriaId { get; set; }
        [Inject]
        public IProductoServicio ProductoServicio { get; set; }

        [Inject]
        public IXestionarProductosLocalStorageServicio XestionarProductosLocalStorageServicio { get; set; }

        public IEnumerable<ProductoDto> Productos { get; set; }
        public string CategoriaNome { get; set; }
        public string ErrorMensaxe { get; set; }

        /// <summary>
        /// Unicamente cando o parametro CategoriaId se establezca queremos obter os datos correspondentes, por iso usamos OnParameterSetAsync, que actua cando se establece un valor de parameter para un evento life cycle.
        /// </summary>
        /// <returns></returns>
        protected override async Task OnParametersSetAsync()
        {
            try
            {
                Productos = await GetProductoColeccionPorCategoriaId(CategoriaId);

                if (Productos != null && Productos.Count() > 0)
                {
                    var productoDto = Productos.FirstOrDefault(p => p.CategoriaId == CategoriaId);

                    if (productoDto != null)
                    {
                        CategoriaNome = productoDto.CategoriaNome;
                    }

                }
            }
            catch (Exception ex)
            {
                ErrorMensaxe = ex.Message;
            }
        }

        private async Task<IEnumerable<ProductoDto>> GetProductoColeccionPorCategoriaId(int categoriaId)
        {
            var productoColeccion = await XestionarProductosLocalStorageServicio.GetColeccion();

            if (productoColeccion != null)
            {
                return productoColeccion.Where(p => p.CategoriaId == categoriaId);
            }
            else
            {
                return await ProductoServicio.GetItemsPorCategoria(categoriaId);
            }

        }
    }
}
