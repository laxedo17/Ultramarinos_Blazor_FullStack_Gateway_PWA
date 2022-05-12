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


        [Inject]
        public IXestionarProductosLocalStorageServicio XestionarProductosLocalStorageServicio { get; set; }

        [Inject]
        public IXestionarCestaItemsLocalStorageServicio XestionarCestaItemsLocalStorageServicio { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public string ErrorMensaxe { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await ClearLocalStorage();

                //evita facer peticions innecesarios ao lado servidor
                Productos = await XestionarProductosLocalStorageServicio.GetColeccion();

                var cestaCompraItems = await XestionarCestaItemsLocalStorageServicio.GetColeccion();

                var totalCantidade = cestaCompraItems.Sum(i => i.Cantidade);

                CestaCompraServicio.RaiseEventOnCestaCompraChanged(totalCantidade);

            }
            catch (Exception ex)
            {
                ErrorMensaxe = ex.Message;

            }

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

        private async Task ClearLocalStorage()
        {
            await XestionarProductosLocalStorageServicio.RemoveColeccion();
            await XestionarCestaItemsLocalStorageServicio.RemoveColeccion();
        }
    }
    }

