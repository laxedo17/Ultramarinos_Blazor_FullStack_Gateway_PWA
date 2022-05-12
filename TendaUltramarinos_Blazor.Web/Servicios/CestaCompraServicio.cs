using Newtonsoft.Json;

using System.Net.Http.Json;
using System.Text;

using TendaUltramarinos.Modelos.Dtos;

using TendaUltramarinos_Blazor.Web.Servicios.Contratos;

namespace TendaUltramarinos_Blazor.Web.Servicios
{
    public class CestaCompraServicio : ICestaCompraServicio
    {
        private readonly HttpClient httpClient;
        public event Action<int> OnCestaCompraChanged;

        public CestaCompraServicio(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public void RaiseEventOnCestaCompraChanged(int totalCantidade)
        {
            if (OnCestaCompraChanged != null)
            {
                //se o evento ten subscribers
                //escribimos o codigo que lanza o evento -raises event-
                //a ditos subscribers
                //o cal facemos co Invoke()
                //e enton podemos enviar o valor integer apropiado a cada subscriber do evento
                OnCestaCompraChanged.Invoke(totalCantidade);
            }
        }

        public async Task<CestaItemDto> AddElemento(CestaItemAnadirDto cestaItemAnadirDto)
        {
            try
            {
                var resposta = await httpClient.PostAsJsonAsync<CestaItemAnadirDto>("api/CestaCompra", cestaItemAnadirDto);

                if (resposta.IsSuccessStatusCode)
                {
                    if (resposta.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(CestaItemDto); //devolve null, que e o valor default dun obxecto ao ser reference type
                    }

                    return await resposta.Content.ReadFromJsonAsync<CestaItemDto>();
                }
                else
                {
                    var mensaxe = await resposta.Content.ReadAsStringAsync();
                    throw new Exception($"Http codigo de status: {resposta.StatusCode} Mensaxe - {mensaxe}");

                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<CestaItemDto> DeleteElemento(int id)
        {
            try
            {
                var resposta = await httpClient.DeleteAsync($"api/CestaCompra/{id}");

                if (resposta.IsSuccessStatusCode)
                {
                    return await resposta.Content.ReadFromJsonAsync<CestaItemDto>();
                }
                return default(CestaItemDto); //devolve null
            }
            catch (Exception)
            {
                //Loggea excepcion
                throw;
            }
        }

        public async Task<List<CestaItemDto>> GetItems(int usuarioId)
        {
            try
            {
                //var resposta = await httpClient.GetAsync($"api/{usuarioId}/GetItems");
                //Engadimos o nome correcto do controller para evitar erros
                var resposta = await httpClient.GetAsync($"api/CestaCompra/{usuarioId}/GetItems");

                if (resposta.IsSuccessStatusCode)
                {
                    if (resposta.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<CestaItemDto>().ToList();
                    }

                    return await resposta.Content.ReadFromJsonAsync<List<CestaItemDto>>();
                }

                else
                {
                    var mensaxe = await resposta.Content.ReadAsStringAsync();
                    throw new Exception($"Http codigo de status: {resposta.StatusCode} Mensaxe - {mensaxe}");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<CestaItemDto> UpdateCantidade(CestaItemCtdUpdateDto cestaItemCtdUpdateDto)
        {
            try
            {
                var peticionJson = JsonConvert.SerializeObject(cestaItemCtdUpdateDto);
                var contido = new StringContent(peticionJson, Encoding.UTF8, "application/json-patch+json");

                var resposta = await httpClient.PatchAsync($"api/CestaCompra/{cestaItemCtdUpdateDto.CestaItemId}", contido);

                if (resposta.IsSuccessStatusCode)
                {
                    return await resposta.Content.ReadFromJsonAsync<CestaItemDto>();
                }

                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
