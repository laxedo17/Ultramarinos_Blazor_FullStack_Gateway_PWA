using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

using TendaUltramarinos.Modelos.Dtos;

using TendaUltramarinos_Blazor.Web.Servicios.Contratos;

namespace TendaUltramarinos_Blazor.Web.Pages
{
    public class PagoBase : ComponentBase
    {
        [Inject]
        public IJSRuntime Javatoscript { get; set; }

        protected IEnumerable<CestaItemDto> CestaCompraItems { get; set; }

        protected int TotalCantidade { get; set; }

        protected string PagoDescripcion { get; set; }

        protected decimal PagoCantidade { get; set; }

        [Inject]
        public ICestaCompraServicio CestaCompraServicio { get; set; }

        [Inject]
        public IXestionarCestaItemsLocalStorageServicio XestionarCestaItemsLocalStorageServicio { get; set; }


        protected string MostrarBotons { get; set; } = "block";

        protected override async Task OnInitializedAsync()
        {
            try
            {
                CestaCompraItems = await XestionarCestaItemsLocalStorageServicio.GetColeccion();

                if (CestaCompraItems != null && CestaCompraItems.Count() > 0)
                {
                    //valor Guid para identificar un pedido inequivocamente
                    Guid pedidoGuid = Guid.NewGuid();

                    PagoCantidade = CestaCompraItems.Sum(p => p.PrecioTotal);
                    TotalCantidade = CestaCompraItems.Sum(p => p.Cantidade);
                    PagoDescripcion = $"Pedido de_{Hardcodeada.UsuarioId}_{pedidoGuid}";

                }
                else
                {
                    MostrarBotons = "none";
                }

            }
            catch (Exception)
            {
                //Log exception
                throw;
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                if (firstRender)
                {
                    await Javatoscript.InvokeVoidAsync("initPayPalButton");
                    //chama a funcion de Paypal no arquivo Index.html da carpeta wwwroot
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
