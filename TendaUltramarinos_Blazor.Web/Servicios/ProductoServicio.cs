using System.Net.Http.Json;

using TendaUltramarinos.Modelos.Dtos;

using TendaUltramarinos_Blazor.Web.Servicios.Contratos;

namespace TendaUltramarinos_Blazor.Web.Servicios
{
    public class ProductoServicio : IProductoServicio
    {
        //facemos Dependency Injection con HttpClient
        //para poder usar os metodos Http necesarios
        //para o lado cliente
        private readonly HttpClient httpClient;

        public ProductoServicio(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ProductoDto> GetItem(int id)
        {
            try
            {
                var resposta = await httpClient.GetAsync($"api/Producto/{id}");
                if (resposta.IsSuccessStatusCode)
                {
                    if (resposta.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(ProductoDto);
                        //ProductoDto é un reference type, co cal a resposta por defecto sempre vai ser null, en caso de que por calquera razon a resposta do server non teña contido
                    }

                    //se todo vai ben
                    return await resposta.Content.ReadFromJsonAsync<ProductoDto>();
                }
                else
                {
                    var mensaxe = await resposta.Content.ReadAsStringAsync();
                    throw new Exception(mensaxe);
                }
            }
            catch (Exception)
            {
                //Facer log da exception

                throw;
            }
        }

        public async Task<IEnumerable<ProductoDto>> GetItems()
        {
            try
            {
                var resposta = await this.httpClient.GetAsync("api/Producto");

                if (resposta.IsSuccessStatusCode)
                {
                    if (resposta.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ProductoDto>();
                    }

                    return await resposta.Content.ReadFromJsonAsync<IEnumerable<ProductoDto>>();
                }
                else
                {
                    var mensaxe = await resposta.Content.ReadAsStringAsync();
                    throw new Exception(mensaxe);
                }

                //pasamos unha coleccion IEnumerable
                //de ProductoDto a metodo generic json async
                //productos sera unha coleccion IEnumerable
                //de obxectod de tipo ProductoDto
                //var productos = await this.httpClient.GetFromJsonAsync<IEnumerable<ProductoDto>>("api/Producto");
                //con json async chamamos ao action method apropiado no noso componente web api
                //o metodo GetFromJsonAsync convirte
                //os datos json devoltos polo componente web api
                //nun obxecto de tipo IEnumerable
                //que e strongly typed co tipo ProductoDto
                //"api/Producto" indica onde esta situada
                //a coleccion que queremos obter
                //do noso componente web api
                //o componente web api sabera onde esta 
                //o metodo Get dentro da clase controller
                //do producto da nosa web api basandose
                //nesa informacion pasada como argumento
                //ao metodo GetFromJsonAsync
                //return productos;

            }
            catch (Exception)
            {
                //Facer log da exception
                throw;
            }
        }

        public async Task<IEnumerable<ProductoDto>> GetItemsPorCategoria(int categoriaId)
        {

            try
            {
                var resposta = await httpClient.GetAsync($"api/Producto/{categoriaId}/GetItemsPorCategoria");

                if (resposta.IsSuccessStatusCode)
                {
                    if (resposta.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ProductoDto>();
                    }
                    return await resposta.Content.ReadFromJsonAsync<IEnumerable<ProductoDto>>();
                }
                else
                {
                    var message = await resposta.Content.ReadAsStringAsync();
                    throw new Exception($"Http Codigo de status - {resposta.StatusCode} Mensaxe - {message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ProductoCategoriaDto>> GetProductoCategorias()
        {
            try
            {
                var resposta = await httpClient.GetAsync("api/Producto/GetProductoCategorias");

                if (resposta.IsSuccessStatusCode)
                {
                    if (resposta.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ProductoCategoriaDto>();
                    }
                    return await resposta.Content.ReadFromJsonAsync<IEnumerable<ProductoCategoriaDto>>();
                }
                else
                {
                    var mensaxe = await resposta.Content.ReadAsStringAsync();
                    throw new Exception($"Http codigo de status - {resposta.StatusCode} Mensaxe - {mensaxe}");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
