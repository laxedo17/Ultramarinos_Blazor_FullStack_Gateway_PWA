using Microsoft.AspNetCore.Components;

using TendaUltramarinos.Modelos.Dtos;

using TendaUltramarinos_Blazor.Web.Servicios.Contratos;

namespace TendaUltramarinos_Blazor.Web.Pages
{
    public class ProductosBase : ComponentBase
    {
        //obxecto para facilitar Dependency Injection
        //do type IProductoServicio no noso componentes Productos.razor
        [Inject]
        public IProductoServicio ProductoServicio { get; set; }
        [Inject]
        public ICestaCompraServicio CestaCompraServicio { get; set; }

        public IEnumerable<ProductoDto> Productos { get; set; }

        /// <summary>
        /// O metodo OnInitializedAsync asociase
        /// cun evento life cycle -ciclo de vida-
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitializedAsync()
        {
            Productos = await ProductoServicio.GetItems();

            var cestaCompraElementos = await CestaCompraServicio.GetItems(Hardcodeada.UsuarioId);
            var totalCantidade = cestaCompraElementos.Sum(i => i.Cantidade);

            CestaCompraServicio.RaiseEventOnCestaCompraChanged(totalCantidade);
        }

        protected IOrderedEnumerable<IGrouping<int, ProductoDto>> GetProductosAgrupadosPorCategoria()
        {
            return from producto in Productos
                   group producto by producto.CategoriaId into prodPorCatGrupo
                   orderby prodPorCatGrupo.Key
                   select prodPorCatGrupo;
        }

        protected string GetCategoriaNome(IGrouping<int, ProductoDto> agrupadosProductoDtos)
        {
            return agrupadosProductoDtos.FirstOrDefault(pg => pg.CategoriaId == agrupadosProductoDtos.Key).CategoriaNome;
        }
    }
}
