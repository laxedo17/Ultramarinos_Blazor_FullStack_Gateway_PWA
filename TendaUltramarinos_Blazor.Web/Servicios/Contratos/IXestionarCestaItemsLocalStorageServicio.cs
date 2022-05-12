using TendaUltramarinos.Modelos.Dtos;

namespace TendaUltramarinos_Blazor.Web.Servicios.Contratos
{
    public interface IXestionarCestaItemsLocalStorageServicio
    {
        Task<List<CestaItemDto>> GetColeccion();
        Task SaveColeccion(List<CestaItemDto> cestaItemDtos);
        Task RemoveColeccion();
    }
}
