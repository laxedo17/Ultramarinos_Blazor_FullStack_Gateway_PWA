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

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Producto = await ProductoServicio.GetItem(Id);
            }
            catch (Exception ex)
            {
                ErrorMensaxe = ex.Message;
            }
        }

        protected async Task AddToCesta_Click(CestaItemAnadirDto cestaItemAnadirDto)
        {
            try
            {
                var cestaItemDto = await CestaCompraServicio.AddElemento(cestaItemAnadirDto);

                NavigationManager.NavigateTo("/CestaCompra");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
