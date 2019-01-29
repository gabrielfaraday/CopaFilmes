using CopaFilmes.Domain.Filmes;
using Xunit;

namespace CopaFilmes.Domain.Tests.Filmes
{
    public class FilmeServiceTest
    {
        [Fact]
        public void ObterVencedor_Filme1Melhor_RetornaFilme1()
        {
            var filme1 = new Filme("ABC", 10);
            var filme2 = new Filme("DEF", 9);

            var filmeService = new FilmeService();
            var resultado = filmeService.ObterVencedor(filme1, filme2);

            Assert.Same(filme1, resultado);
        }

        [Fact]
        public void ObterVencedor_Filme2Melhor_RetornaFilme2()
        {
            var filme1 = new Filme("ABC", 9);
            var filme2 = new Filme("DEF", 10);

            var filmeService = new FilmeService();
            var resultado = filmeService.ObterVencedor(filme1, filme2);

            Assert.Same(filme2, resultado);
        }

        [Fact]
        public void ObterVencedor_Empate_RetornaFilme1QuandoForOrdemAlfabeticaMenor()
        {
            var filme1 = new Filme("ABC", 10);
            var filme2 = new Filme("DEF", 10);

            var filmeService = new FilmeService();
            var resultado = filmeService.ObterVencedor(filme1, filme2);

            Assert.Same(filme1, resultado);
        }

        [Fact]
        public void ObterVencedor_Empate_RetornaFilme2QuandoForOrdemAlfabeticaMenor()
        {
            var filme1 = new Filme("DEF", 10);
            var filme2 = new Filme("ABC", 10);

            var filmeService = new FilmeService();
            var resultado = filmeService.ObterVencedor(filme1, filme2);

            Assert.Same(filme2, resultado);
        }

    }
}
