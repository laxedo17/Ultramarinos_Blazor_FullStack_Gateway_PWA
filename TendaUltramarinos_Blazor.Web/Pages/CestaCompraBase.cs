using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

using TendaUltramarinos.Modelos.Dtos;

using TendaUltramarinos_Blazor.Web.Servicios.Contratos;

namespace TendaUltramarinos_Blazor.Web.Pages
{
    public class CestaCompraBase : ComponentBase
    {
        [Inject]
        public IJSRuntime Javatoscript { get; set; }
        [Inject]
        public ICestaCompraServicio CestaCompraServicio { get; set; }

        //public IEnumerable<CestaItemDto> CestaCompraItems { get; set; }

        //Mostra a lista de elementos da cesta da compra para mostrar os datos relevantes en pantalla. Pasamola a List para ter unha maneira facil de borrar os elementos da cesta
        public List<CestaItemDto> CestaCompraItems { get; set; }
        public string ErrorMensaxe { get; set; }

        protected string PrecioTotal { get; set; }
        public int TotalCantidade { get; set; }

        /// <summary>
        /// Devolvemos unha coleccion de items da cesta da compra devoltos desde o server para a propiedade CestaCompraItems cando se renderiza inicialmente o Razor component
        /// </summary>
        /// <returns></returns>
        protected override async Task OnInitializedAsync()
        {
            try
            {
                CestaCompraItems = await CestaCompraServicio.GetItems(Hardcodeada.UsuarioId);
                CestaChanged();

            }
            catch (Exception ex)
            {
                ErrorMensaxe = ex.Message;
            }
        }

        protected async Task DeleteCestaItem_Click(int id)
        {
            var cestaItemDto = await CestaCompraServicio.DeleteElemento(id);

            //necesitamos que o Razor component se re-renderice cando se complete o eliminado correctamente, para que se reflexa apropiadamente no user interface
            RemoveCestaItem(id);
            CestaChanged();
        }

        private CestaItemDto GetCestaItem(int id)
        {
            return CestaCompraItems.FirstOrDefault(ci => ci.Id == id);
        }

        /// <summary>
        /// Metodo para eliminar un elemento da cesta solamente no lado cliente para evitar viaxar ao servidor e asi aforrar o tempo significativamente
        /// </summary>
        /// <param name="id"></param>
        private void RemoveCestaItem(int id)
        {
            var cestaItemDto = GetCestaItem(id); //devolvemos o obxecto que desexamos borrar
            CestaCompraItems.Remove(cestaItemDto);
        }

        protected async Task UpdateCtdCestaItem_Click(int id, int cantidade)
        {
            try
            {
                if (cantidade > 0)
                {
                    var updateItemDto = new CestaItemCtdUpdateDto
                    {
                        CestaItemId = id,
                        Cantidade = cantidade
                    };

                    var devoltoUpdateItemDto = await this.CestaCompraServicio.UpdateCantidade(updateItemDto);

                    UpdateItemPrecioTotal(devoltoUpdateItemDto);
                    CestaChanged();

                    await FacerBotonCtdVisible(id, false);
                }
                else //se non hai cambios
                {
                    var elemento = this.CestaCompraItems.FirstOrDefault(i => i.Id == id);

                    if (elemento != null)
                    {
                        elemento.Cantidade = 1;
                        elemento.PrecioTotal = elemento.Precio;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SetPrecioTotal()
        {
            PrecioTotal = this.CestaCompraItems.Sum(p => p.PrecioTotal).ToString("C");
        }

        private void SetCantidadeTotal()
        {
            TotalCantidade = this.CestaCompraItems.Sum(p => p.Cantidade);
        }

        private void UpdateItemPrecioTotal(CestaItemDto cestaItemDto)
        {
            var elemento = GetCestaItem(cestaItemDto.Id);

            if (elemento != null)
            {
                elemento.PrecioTotal = cestaItemDto.Precio * cestaItemDto.Cantidade;
            }
        }

        private void CalculaCestaResumenTotales()
        {
            SetPrecioTotal();
            SetCantidadeTotal();
        }

        protected async Task UpdateCantidade_Entrada(int id)
        {
            await FacerBotonCtdVisible(id, true);
        }

        private async Task FacerBotonCtdVisible(int id, bool visible)
        {
            await Javatoscript.InvokeVoidAsync("ActualizarBotonCantidadeVisible", id, true);
        }

        private void CestaChanged()
        {
            CalculaCestaResumenTotales();
            CestaCompraServicio.RaiseEventOnCestaCompraChanged(TotalCantidade);
        }
    }
}
