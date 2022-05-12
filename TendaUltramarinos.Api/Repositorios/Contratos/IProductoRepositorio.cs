using TendaUltramarinos.Api.Entidades;

namespace TendaUltramarinos.Api.Repositorios.Contratos
{
    /// <summary>
    /// Usamos o repository design pattern para abstraer 
    /// a nosa capa de manexo de datos.
    /// Os repositorios son clases ou componentes
    /// que encapsulan a loxica necesaria
    /// para acceder as fontes ou orixen dos datos.
    /// Podemos usar os repositorios para centralizar a funcionalidade
    /// de acceso a datos comun
    /// o cal aporta o beneficio de 
    /// facilitar millor mantenibilidade,
    /// unit testing mais facil, extensibilidade 
    /// e codigo mais limpo.
    /// Esta interface implementarase na clase ProductoRepositorio
    /// </summary>
    public interface IProductoRepositorio
    {
        //Pasamos unha coleccion IEnumerable de type Producto
        Task<IEnumerable<Producto>> GetItems();
        Task<IEnumerable<ProductoCategoria>> GetCategorias();
        //Obtemos item unico que toma un parametro tipo integer id
        Task<Producto> GetItem(int id);
        Task<ProductoCategoria> GetCategoria(int id);
        Task<IEnumerable<Producto>> GetItemsPorCategoria(int id);
    }
}
