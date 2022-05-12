using Microsoft.AspNetCore.Components;

using TendaUltramarinos.Modelos.Dtos;

namespace TendaUltramarinos_Blazor.Web.Pages
{
    public class MostrarProductosBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<ProductoDto> Productos { get; set; }
    }
}
