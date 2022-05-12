using Microsoft.EntityFrameworkCore;

using TendaUltramarinos.Api.Datos;
using TendaUltramarinos.Api.Entidades;
using TendaUltramarinos.Api.Repositorios.Contratos;
using TendaUltramarinos.Modelos.Dtos;

namespace TendaUltramarinos.Api.Repositorios
{
    public class CestaCompraRepositorio : ICestaCompraRepositorio
    {
        private readonly UltramarinosDbContext db;

        /// <summary>
        /// Acceso a base de datos con Dependency Injection para usar Entity Framework Core e manipular os datos
        /// </summary>
        /// <param name="db"></param>
        public CestaCompraRepositorio(UltramarinosDbContext db)
        {
            this.db = db;
        }

        /// <summary>
        /// Devolve un valor bool que indica se un producto xa estaba na cesta
        /// </summary>
        /// <param name="cestaId"></param>
        /// <param name="productoId"></param>
        /// <returns></returns>
        private async Task<bool> CestaItemExiste(int cestaId, int productoId)
        {
            return await this.db.CestaItems.AnyAsync(c => c.CestaId == cestaId && c.ProductoId == productoId);
        }
        public async Task<CestaItem> AddElemento(CestaItemAnadirDto cestaItemAnadirDto)
        {
            if (await CestaItemExiste(cestaItemAnadirDto.CestaId, cestaItemAnadirDto.ProductoId) == false)
            {
                var elemento = await (from producto in this.db.Productos
                                      where producto.Id == cestaItemAnadirDto.ProductoId
                                      select new CestaItem
                                      {
                                          CestaId = cestaItemAnadirDto.CestaId,
                                          ProductoId = producto.Id,
                                          Cantidade = cestaItemAnadirDto.Cantidade
                                      }).SingleOrDefaultAsync();

                if (elemento != null)
                {
                    var resultado = await this.db.CestaItems.AddAsync(elemento);
                    await this.db.SaveChangesAsync();
                    return resultado.Entity;
                }
            }


            return null;
        }

        public async Task<CestaItem> DeleteElemento(int id)
        {
            var elemento = await this.db.CestaItems.FindAsync(id);

            if (elemento != null)
            {
                this.db.CestaItems.Remove(elemento);
                await this.db.SaveChangesAsync();
            }

            return elemento;
        }

        public async Task<CestaItem> GetItem(int id)
        {
            return await (from cesta in this.db.Cestas
                          join cestaItem in this.db.CestaItems
                          on cesta.Id equals cestaItem.CestaId
                          where cestaItem.Id == id
                          select new CestaItem
                          {
                              Id = cestaItem.Id,
                              ProductoId = cestaItem.ProductoId,
                              Cantidade = cestaItem.Cantidade,
                              CestaId = cestaItem.CestaId
                          }).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<CestaItem>> GetItems(int usuarioId)
        {
            return await (from cesta in this.db.Cestas
                          join cestaItem in this.db.CestaItems
                          on cesta.Id equals cestaItem.CestaId
                          where cesta.UsuarioId == usuarioId
                          select new CestaItem
                          {
                              Id = cestaItem.Id,
                              ProductoId = cestaItem.ProductoId,
                              Cantidade = cestaItem.Cantidade,
                              CestaId = cestaItem.CestaId
                          }).ToListAsync();
        }

        public async Task<CestaItem> UpdateCantidade(int id, CestaItemCtdUpdateDto cestaItemCtdUpdateDto)
        {
            var elemento = await this.db.CestaItems.FindAsync(id);

            if (elemento != null)
            {
                elemento.Cantidade = cestaItemCtdUpdateDto.Cantidade;
                await this.db.SaveChangesAsync();
                return elemento;
            }

            return null; //se o item non se atopa na base de datos
        }
    }
}
