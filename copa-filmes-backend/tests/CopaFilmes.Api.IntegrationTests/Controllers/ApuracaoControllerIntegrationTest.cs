using CopaFilmes.Api.IntegrationTests.Configuration;
using CopaFilmes.Domain.Filmes;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CopaFilmes.Api.IntegrationTests.Controllers
{
    public class ApuracaoControllerIntegrationTest : BaseIntegrationTest
    {
        public ApuracaoControllerIntegrationTest(BaseTestFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task Post_ListaComOitoFilmes_DeveRetornar200_ComFilmesFinalistasOrdenados()
        {
            var filmes = new List<Filme>
            {
                new Filme("Os Incríveis 2", 8.5),
                new Filme("Jurassic World: Reino Ameaçado", 6.7),
                new Filme("Oito Mulheres e um Segredo", 6.3),
                new Filme("Hereditário", 7.8),
                new Filme("Vingadores: Guerra Infinita", 8.8),
                new Filme("Deadpool 2", 8.1),
                new Filme("Han Solo: Uma História Star Wars", 7.2),
                new Filme("Thor: Ragnarok", 7.9)
            };

            var response = await Server
                .CreateRequest("v1/api/apuracao")
                .And(req => req.Content = GenerateRequestContent(filmes))
                .PostAsync();

            response.EnsureSuccessStatusCode();

            var resultado = await GetContentFromResponseAsync<List<Filme>>(response);

            Assert.NotEmpty(resultado);
            Assert.NotNull(resultado);
            Assert.Equal(2, resultado.Count);
            Assert.Equal("Vingadores: Guerra Infinita", resultado[0].Titulo);
            Assert.Equal("Os Incríveis 2", resultado[1].Titulo);
        }

        [Fact]
        public async Task Post_ListaComMaisDeOitoFilmes_DeveRetornar400()
        {
            var filmes = new List<Filme>
            {
                new Filme("AAA", 8.9),
                new Filme("Os Incríveis 2", 8.5),
                new Filme("Jurassic World: Reino Ameaçado", 6.7),
                new Filme("Oito Mulheres e um Segredo", 6.3),
                new Filme("Hereditário", 7.8),
                new Filme("Vingadores: Guerra Infinita", 8.8),
                new Filme("Deadpool 2", 8.1),
                new Filme("Han Solo: Uma História Star Wars", 7.2),
                new Filme("Thor: Ragnarok", 7.9)
            };

            var response = await Server
                .CreateRequest("v1/api/apuracao")
                .And(req => req.Content = GenerateRequestContent(filmes))
                .PostAsync();

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Post_ListaComMenosDeOitoFilmes_DeveRetornar400()
        {
            var filmes = new List<Filme>
            {
                new Filme("Vingadores: Guerra Infinita", 8.8),
                new Filme("Deadpool 2", 8.1),
                new Filme("Han Solo: Uma História Star Wars", 7.2),
                new Filme("Thor: Ragnarok", 7.9)
            };

            var response = await Server
                .CreateRequest("v1/api/apuracao")
                .And(req => req.Content = GenerateRequestContent(filmes))
                .PostAsync();

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
