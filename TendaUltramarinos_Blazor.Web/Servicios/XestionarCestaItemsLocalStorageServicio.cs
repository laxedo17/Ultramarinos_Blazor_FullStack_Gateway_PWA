using Blazored.LocalStorage;

using TendaUltramarinos.Modelos.Dtos;

using TendaUltramarinos_Blazor.Web.Servicios.Contratos;

namespace TendaUltramarinos_Blazor.Web.Servicios
{
    public class XestionarCestaItemsLocalStorageServicio : IXestionarCestaItemsLocalStorageServicio
    {
        private readonly ILocalStorageService localStorageService;
        private readonly ICestaCompraServicio cestaCompraServicio;

        public XestionarCestaItemsLocalStorageServicio(ILocalStorageService localStorageService, ICestaCompraServicio cestaCompraServicio)
        {
            this.localStorageService = localStorageService;
            this.cestaCompraServicio = cestaCompraServicio;
        }

        const string clave = "CestaItemColeccion";

        public async Task<List<CestaItemDto>> GetColeccion()
        {
            return await this.localStorageService.GetItemAsync<List<CestaItemDto>>(clave) ?? await AddColeccion();
        }

        public async Task RemoveColeccion()
        {
            await this.localStorageService.RemoveItemAsync(clave);
        }

        public async Task SaveColeccion(List<CestaItemDto> cestaItemDtos)
        {
            await this.localStorageService.SetItemAsync(clave, cestaItemDtos);
        }

        /// <summary>
        /// Engade coleccion de obxectos CestaItemDto desde o servidor para pasar a LocalStorage (lado cliente).
        /// </summary>
        /// <returns></returns>
        private async Task<List<CestaItemDto>> AddColeccion()
        {
            var cestaCompraColeccion = await this.cestaCompraServicio.GetItems(Hardcodeada.UsuarioId);

            if (cestaCompraColeccion != null)
            {
                await this.localStorageService.SetItemAsync(clave, cestaCompraColeccion);
            }

            return cestaCompraColeccion;
        }
    }
}
