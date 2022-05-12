using TendaUltramarinos.Modelos.Dtos;

namespace TendaUltramarinos_Blazor.Web.Servicios.Contratos
{
    public interface IProductoServicio
    {
        Task<IEnumerable<ProductoDto>> GetItems();
        //usamos Task porque queremos que sexa async
        //o valor de id e necesario para evaluar un producto especifico
        Task<ProductoDto> GetItem(int id);
        Task<IEnumerable<ProductoCategoriaDto>> GetProductoCategorias();
        Task<IEnumerable<ProductoDto>> GetItemsPorCategoria(int categoriaId);
    }
}
