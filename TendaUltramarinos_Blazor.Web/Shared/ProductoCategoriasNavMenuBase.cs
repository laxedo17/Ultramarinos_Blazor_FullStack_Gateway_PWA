using Microsoft.AspNetCore.Components;

using TendaUltramarinos.Modelos.Dtos;

using TendaUltramarinos_Blazor.Web.Servicios.Contratos;

namespace TendaUltramarinos_Blazor.Web.Shared
{
    public class ProductoCategoriasNavMenuBase : ComponentBase
    {
        [Inject]
        public IProductoServicio ProductoServicio { get; set; }

        public IEnumerable<ProductoCategoriaDto> ProductoCategoriaDtos { get; set; }

        public string ErrorMensaxe { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                ProductoCategoriaDtos = await ProductoServicio.GetProductoCategorias();
            }
            catch (Exception ex)
            {
                ErrorMensaxe = ex.Message;
            }
        }
    }
}