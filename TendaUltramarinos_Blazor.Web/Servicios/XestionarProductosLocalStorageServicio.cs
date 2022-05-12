using Blazored.LocalStorage;

using TendaUltramarinos.Modelos.Dtos;

using TendaUltramarinos_Blazor.Web.Servicios.Contratos;

namespace TendaUltramarinos_Blazor.Web.Servicios
{
    public class XestionarProductosLocalStorageServicio : IXestionarProductosLocalStorageServicio
    {
        private readonly ILocalStorageService localStorageService;
        private readonly IProductoServicio productoServicio;

        //clave = key para identificar o valor relevante para LocalStorage
        //neste caso unha coleccion serializada de obxectos
        //de tipo ProductoDto
        private const string clave = "ProductoColeccion";

        public XestionarProductosLocalStorageServicio(ILocalStorageService localStorageService, IProductoServicio productoServicio)
        {
            this.localStorageService = localStorageService;
            this.productoServicio = productoServicio;
        }

        /// <summary>
        /// Intenta obter os datos relevantes de LocalStorage.
        /// Senon existen en localstorage con AddColeccion() busca os datos relevantes no servidor e garda os datos relevantes no navegador de usuario utilizando LocalStorage.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ProductoDto>> GetColeccion()
        {
            return await this.localStorageService.GetItemAsync<IEnumerable<ProductoDto>>(clave) ?? await AddColeccion();
        }

        public async Task RemoveColeccion()
        {
            await this.localStorageService.RemoveItemAsync(clave);
        }

        /// <summary>
        /// Obten datos dos productos do servidor e simplemente garda os datos relevantes no navegador de usuario usando LocalStorage.
        /// </summary>
        /// <returns></returns>
        private async Task<IEnumerable<ProductoDto>> AddColeccion()
        {
            var productoColeccion = await this.productoServicio.GetItems();

            if(productoColeccion !=null)
            {
                await this.localStorageService.SetItemAsync(clave, productoColeccion);
            }

            return productoColeccion;
        }
    }
}
