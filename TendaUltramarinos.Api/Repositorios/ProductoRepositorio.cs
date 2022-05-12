using Microsoft.EntityFrameworkCore;

using TendaUltramarinos.Api.Datos;
using TendaUltramarinos.Api.Entidades;
using TendaUltramarinos.Api.Repositorios.Contratos;

namespace TendaUltramarinos.Api.Repositorios
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly UltramarinosDbContext db;

        /// <summary>
        /// Con Dependency Injection usamos o contexto
        /// da base de datos no constructor.
        /// </summary>
        /// <param name="db"></param>
        public ProductoRepositorio(UltramarinosDbContext db)
        {
            this.db = db;
        }

        public async Task<ProductoCategoria> GetCategoria(int id)
        {
            var categoria = await this.db.ProductoCategorias.SingleOrDefaultAsync(c => c.Id == id);
            return categoria;
        }

        /// <summary>
        /// Obtemos todos os productos dunha categoria da nosa base de datos.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ProductoCategoria>> GetCategorias()
        {
            var categorias = await this.db.ProductoCategorias.ToListAsync();
            return categorias;
        }

        public async Task<Producto> GetItem(int id)
        {
            var producto = await db.Productos.FindAsync(id);
            return producto;
        }

        /// <summary>
        /// Devolvemos unha coleccion de datos
        /// ao lado cliente, neste caso o noso Blazor Component.
        /// </summary>
        /// <returns>Todos os productos da taboa Productos.</returns>
        public async Task<IEnumerable<Producto>> GetItems()
        {
            var productos = await this.db.Productos.ToListAsync();
            return productos;
        }

        public async Task<IEnumerable<Producto>> GetItemsPorCategoria(int id)
        {
            var productos = await this.db.Productos
                         .Include(p => p.ProductoCategoria)
                         .Where(p => p.CategoriaId == id).ToListAsync();
            return productos;
        }
    }
}
