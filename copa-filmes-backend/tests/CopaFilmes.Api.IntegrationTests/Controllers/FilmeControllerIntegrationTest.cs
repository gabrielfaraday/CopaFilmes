using System.Collections.Generic;
using System.Threading.Tasks;
using CopaFilmes.Api.ExternalCalls.Filmes;
using CopaFilmes.Api.IntegrationTests.Configuration;
using Xunit;

namespace tests.CopaFilmes.Api.IntegrationTests.Controllers
{
    public class FilmeControllerIntegrationTest : BaseIntegrationTest
    {
        public FilmeControllerIntegrationTest(BaseTestFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task ObterFilmes_DeveListarFilmes()
        {
            var response = await Server
                .CreateRequest("v1/api/listar-filmes")
                .GetAsync();

            response.EnsureSuccessStatusCode();

            var resultado = await GetContentFromResponseAsync<List<FilmeDto>>(response);

            Assert.NotEmpty(resultado);
            Assert.NotNull(resultado);
        }
    }
}