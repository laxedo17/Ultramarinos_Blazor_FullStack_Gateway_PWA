using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TendaUltramarinos.Api.Repositorios.Contratos;
using TendaUltramarinos.Modelos.Dtos;
using TendaUltramarinos.Api.Extensions;

namespace TendaUltramarinos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CestaCompraController : ControllerBase
    {
        private readonly ICestaCompraRepositorio cestaCompraRepositorio;
        private readonly IProductoRepositorio productoRepositorio;

        public CestaCompraController(ICestaCompraRepositorio cestaCompraRepositorio, IProductoRepositorio productoRepositorio)
        {
            this.cestaCompraRepositorio = cestaCompraRepositorio;
            this.productoRepositorio = productoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CestaItemDto>>> GetItems(int usuarioId)
        {
            try
            {
                var cestaItems = await this.cestaCompraRepositorio.GetItems(usuarioId);

                if (cestaItems == null)
                {
                    return NoContent();
                }

                var productos = await this.productoRepositorio.GetItems();

                //non ten sentido que o usuario intente engadir productos a cesta se non hai productos no sistema
                if (productos == null)
                {
                    throw new Exception("Non hai productos disponhibles");
                }

                var cestaItemsDto = cestaItems.ConvertirADto(productos);

                return Ok(cestaItemsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Devolvemos un unico elemento de tipo CestaItemDto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CestaItemDto>> GetItem(int id)
        {
            try
            {
                var cestaItem = await this.cestaCompraRepositorio.GetItem(id);
                if (cestaItem == null)
                {
                    return NotFound();
                }

                var producto = await productoRepositorio.GetItem(cestaItem.ProductoId);

                var cestaItemDto = cestaItem.ConvertirADto(producto);
                return Ok(cestaItemDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CestaItemDto>> PostItem([FromBody] CestaItemAnadirDto cestaItemAnadirDto)
        {
            try
            {
                var novoCestaItem = await this.cestaCompraRepositorio.AddElemento(cestaItemAnadirDto);

                if (novoCestaItem == null)
                {
                    return NoContent();
                }

                var producto = await productoRepositorio.GetItem(novoCestaItem.ProductoId);

                if (producto == null)
                {
                    throw new Exception($"Erro intentando obter producto (productoId:({cestaItemAnadirDto.ProductoId}");
                }

                var novoCestaItemDto = novoCestaItem.ConvertirADto(producto);

                //devolvemos header da resposta Http devolta por este metodo
                //Obtemos isto da URI (universal resource identifier)
                return CreatedAtAction(nameof(GetItem), new { id = novoCestaItemDto.Id }, novoCestaItemDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CestaItemDto>> DeleteElemento(int id)
        {
            try
            {
                var cestaItem = await this.cestaCompraRepositorio.DeleteElemento(id);
                if (cestaItem == null)
                {
                    return NotFound();
                }

                var producto = await this.productoRepositorio.GetItem(cestaItem.ProductoId);

                if (producto == null)
                {
                    return NotFound();
                }

                var cestaItemDto = cestaItem.ConvertirADto(producto);

                return Ok(cestaItemDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //[HttpPut] asociase con cambios completos dun recurso
        //mentres que [HttpPost] asociase con cambios parciales
        //como solo queremos cambiar a Cantidade, usaremos HttpPatch
        [HttpPatch("{id:int}")]
        public async Task<ActionResult<CestaItemDto>> UpdateCantidade(int id, CestaItemCtdUpdateDto cestaItemCtdUpdateDto)
        {
            try
            {
                var cestaItem = await this.cestaCompraRepositorio.UpdateCantidade(id, cestaItemCtdUpdateDto);

                if (cestaItem == null)
                {
                    return NotFound();
                }

                var producto = await productoRepositorio.GetItem(cestaItem.ProductoId);

                var cestaItemDto = cestaItem.ConvertirADto(producto);
                return Ok(cestaItemDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
