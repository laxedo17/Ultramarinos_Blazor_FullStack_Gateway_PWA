using Microsoft.AspNetCore.Components;

using TendaUltramarinos.Modelos.Dtos;

using TendaUltramarinos_Blazor.Web.Servicios.Contratos;

namespace TendaUltramarinos_Blazor.Web.Pages
{
    public class ProductoDetallesBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        [Inject]
        public IProductoServicio ProductoServicio { get; set; }
        [Inject]
        public ICestaCompraServicio CestaCompraServicio { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; } //para navegar o usuario a pantalla relevante
        public ProductoDto Producto { get; set; }
        public string ErrorMensaxe { get; set; } //para excepcions

        [Inject]
        public IXestionarProductosLocalStorageServicio XestionarProductosLocalStorageServicio { get; set; }

        [Inject]
        public IXestionarCestaItemsLocalStorageServicio XestionarCestaItemsLocalStorageServicio { get; set; }

        private List<CestaItemDto> CestaCompraItems { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                CestaCompraItems = await XestionarCestaItemsLocalStorageServicio.GetColeccion();
                //Producto = await ProductoServicio.GetItem(Id);
                Producto = await GetProductoPorId(Id);
            }
            catch (Exception ex)
            {
                ErrorMensaxe = ex.Message;
            }
        }

        private async Task<ProductoDto> GetProductoPorId(int id)
        {
            var productoDtos = await XestionarProductosLocalStorageServicio.GetColeccion();

            if (productoDtos != null)
            {
                return productoDtos.SingleOrDefault(p => p.Id == id);
            }
            return null;
        }

        protected async Task AddToCesta_Click(CestaItemAnadirDto cestaItemAnadirDto)
        {
            try
            {
                var cestaItemDto = await CestaCompraServicio.AddElemento(cestaItemAnadirDto);

                if (cestaItemDto != null)
                {
                    CestaCompraItems.Add(cestaItemDto);
                    await XestionarCestaItemsLocalStorageServicio.SaveColeccion(CestaCompraItems);
                }

                NavigationManager.NavigateTo("/CestaCompra");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
