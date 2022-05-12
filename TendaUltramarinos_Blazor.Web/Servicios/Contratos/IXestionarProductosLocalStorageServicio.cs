using TendaUltramarinos.Modelos.Dtos;

namespace TendaUltramarinos_Blazor.Web.Servicios.Contratos
{
    public interface IXestionarProductosLocalStorageServicio
    {
        Task<IEnumerable<ProductoDto>> GetColeccion();
        Task RemoveColeccion();

    }
}
