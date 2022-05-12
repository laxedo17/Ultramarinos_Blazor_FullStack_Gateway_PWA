using TendaUltramarinos.Api.Entidades;
using TendaUltramarinos.Modelos.Dtos;

namespace TendaUltramarinos.Api.Repositorios.Contratos
{
    public interface ICestaCompraRepositorio
    {
        Task<CestaItem> AddElemento(CestaItemAnadirDto cestaItemAnadirDto);
        Task<CestaItem> UpdateCantidade(int id, CestaItemCtdUpdateDto cestaItemCtdUpdateDto);
        Task<CestaItem> DeleteElemento(int id);
        Task<CestaItem> GetItem(int id);
        Task<IEnumerable<CestaItem>> GetItems(int usuarioId);
    }
}
