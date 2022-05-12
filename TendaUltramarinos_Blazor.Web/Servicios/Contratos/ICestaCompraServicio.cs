using TendaUltramarinos.Modelos.Dtos;

namespace TendaUltramarinos_Blazor.Web.Servicios.Contratos
{
    public interface ICestaCompraServicio
    {
        //Task<IEnumerable<CestaItemDto>> GetItems(int usuarioId);
        Task<List<CestaItemDto>> GetItems(int usuarioId);
        Task<CestaItemDto> AddElemento(CestaItemAnadirDto cestaItemAnadirDto);
        Task<CestaItemDto> DeleteElemento(int id);
        Task<CestaItemDto> UpdateCantidade(CestaItemCtdUpdateDto cestaItemCtdUpdateDto);

        //Delegate para controlar cambios en cesta da compra en tempo real
        event Action<int> OnCestaCompraChanged;
        void RaiseEventOnCestaCompraChanged(int totalCantidade);
    }
}
