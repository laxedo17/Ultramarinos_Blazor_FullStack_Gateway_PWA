using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TendaUltramarinos.Api.Extensions;
using TendaUltramarinos.Api.Repositorios.Contratos;
using TendaUltramarinos.Modelos.Dtos;

namespace TendaUltramarinos.Api.Controllers
{
    /// <summary>
    /// Un obxecto de tipo ProductoRepositorio inxectase automaticamente no constructor do controller das nosas clases.
    /// Usando Dependency Injection.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        //representa obxecto pasado con Dependency Injection
        private readonly IProductoRepositorio productoRepositorio;

        public ProductoController(IProductoRepositorio productoRepositorio)
        {
            this.productoRepositorio = productoRepositorio;
        }

        /// <summary>
        /// Devolve os datos dun producto ao cliente.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> GetItems()
        {
            try
            {
                var productos = await this.productoRepositorio.GetItems();
                //var productoCategorias = await this.productoRepositorio.GetCategorias();
                //despois unimos os productos a cada categoria de producto,
                //esta forma de arriba e ineficiente
                //para facer un Join
                //millor usar Linq e unir ambas cousas con Include
                //para devolver os datos cunha sola query
                //var productos = await db.Productos
                //    .Include(p => p.ProductoCategoria).ToListAsync();

                if (productos == null)
                {
                    return NotFound();
                }
                else
                {
                    //unimos ambos, productos e productosCategorias
                    //asi podemos devolver un Dto -data transfer object-
                    //que incluira tamen CategoriaNome
                    //que e un dato que para ser obtido
                    //necesita unir unha coleccion de tipo Producto
                    //coa coleccion de tipo ProductoCategoria
                    //para aforrar lineas de codigo neste metodo
                    //usamos un extension method propio para devolver
                    //unha coleccion de tipo ProductoDto ao noso
                    //action method
                    //o extension method creamolo na carpeta Extensions
                    var productoDtos = productos.ConvertirADto();
                    return Ok(productoDtos);//devolve codigo http 200
                }

            }
            catch (Exception)
            {
                //en caso de producirse un erro por calquera motivo
                //devolvemos o codigo de status 500 -error do servidor-
                //e agregamos unha mensaxe simple
                return StatusCode(StatusCodes.Status500InternalServerError, "Error obtendo os datos da base de datos");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductoDto>> GetItem(int id)
        {
            try
            {
                var producto = await this.productoRepositorio.GetItem(id);

                if (producto == null)
                {
                    return BadRequest();
                }
                else
                {
                    //var productoCategoria = await this.productoRepositorio.GetCategoria(producto.CategoriaId);
                    var productoDto = producto.ConvertirADto();

                    return Ok(productoDto);
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error obtendo os datos da base de datos");
            }
        }

        [HttpGet]
        [Route(nameof(GetProductoCategorias))]
        public async Task<ActionResult<IEnumerable<ProductoCategoriaDto>>> GetProductoCategorias()
        {
            try
            {
                var productoCategorias = await productoRepositorio.GetCategorias();
                var productoCategoriasDto = productoCategorias.ConvertirADto();

                return Ok(productoCategoriasDto);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error obtendo os datos da base de datos");
            }
        }

        [HttpGet]
        [Route("{categoriaId}/GetItemsPorCategoria")]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> GetItemsPorCategoria(int categoriaId)
        {
            try
            {
                var productos = await productoRepositorio.GetItemsPorCategoria(categoriaId);
                //var productoCategorias = await productoRepositorio.GetCategorias();

                var productoDtos = productos.ConvertirADto();

                return Ok(productoDtos);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                "Error obtendo datos da base de datos");
            }
        }
    }
}
