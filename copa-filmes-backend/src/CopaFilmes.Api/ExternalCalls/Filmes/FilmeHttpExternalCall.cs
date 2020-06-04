using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CopaFilmes.Api.ExternalCalls.Exceptions;
using Newtonsoft.Json;

namespace CopaFilmes.Api.ExternalCalls.Filmes
{
    public class FilmeHttpExternalCall : IFilmeHttpExternalCall
    {
        private readonly IHttpClientFactory _clientFactory;

        public FilmeHttpExternalCall(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<List<FilmeDto>> ObterFilmes()
        {
            try
            {
                var client = _clientFactory.CreateClient("CopaFilmes");

                var request = new HttpRequestMessage(HttpMethod.Get, $"/api/filmes");

                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<FilmeDto>>(responseString);
                }
                else
                {
                    throw new RequestWithoutSuccessException($"A requisição retornou com status {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new HttpRequestException($"Erro ao acessar API CopaFilmes 'GET: /filmes'", ex);
            }
        }
    }
}