using CopaFilmes.Domain.Exceptions;
using CopaFilmes.Domain.Filmes;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CopaFilmes.Domain.Tests.Filmes
{
    public class FilmeServiceTest
    {
        [Fact]
        public void ApurarFinal_NotasDiferentes_OrdenaPorNota()
        {
            var filme1 = new Filme("ABC", 10);
            var filme2 = new Filme("DEF", 9);

            var filmes = new List<Filme>
            {
                filme1,
                filme2
            };

            var filmeService = new FilmeService();
            var resultado = filmeService.ApurarFinal(filmes);

            Assert.Same(resultado.ElementAt(0), filme1);
            Assert.Same(resultado.ElementAt(1), filme2);
        }

        [Fact]
        public void ApurarFinal_NotasIguais_OrdenaPorTitulo()
        {
            var filme1 = new Filme("DEF", 10);
            var filme2 = new Filme("ABC", 10);

            var filmes = new List<Filme>
            {
                filme1,
                filme2
            };

            var filmeService = new FilmeService();
            var resultado = filmeService.ApurarFinal(filmes);

            Assert.Same(resultado.ElementAt(0), filme2);
            Assert.Same(resultado.ElementAt(1), filme1);
        }

        [Fact]
        public void ApurarFinal_MaisQueDoisFilmes_GeraExcecao()
        {
            var filme1 = new Filme("ABC", 10);
            var filme2 = new Filme("DEF", 9);
            var filme3 = new Filme("GHI", 8);

            var filmes = new List<Filme>
            {
                filme1,
                filme2,
                filme3
            };

            var filmeService = new FilmeService();
            Assert.Throws<QuantidadeFilmesInvalida>("Quantidade de filmes.", () => filmeService.ApurarFinal(filmes));
        }

        [Fact]
        public void ApurarFinal_MenosQueDoisFilmes_GeraExcecao()
        {
            var filme1 = new Filme("ABC", 10);

            var filmes = new List<Filme>
            {
                filme1
            };

            var filmeService = new FilmeService();
            Assert.Throws<QuantidadeFilmesInvalida>("Quantidade de filmes.", () => filmeService.ApurarFinal(filmes));
        }

        [Fact]
        public void ApurarQuartasDeFinal_NotasDiferentes_ApuracaoOcorrePorNota()
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

            var filmeService = new FilmeService();
            var resultado = filmeService.ApurarQuartasDeFinal(filmes);

            Assert.Equal("Os Incríveis 2", resultado.ElementAt(0).Titulo);
            Assert.Equal("Han Solo: Uma História Star Wars", resultado.ElementAt(1).Titulo);
            Assert.Equal("Deadpool 2", resultado.ElementAt(2).Titulo);
            Assert.Equal("Vingadores: Guerra Infinita", resultado.ElementAt(3).Titulo);
        }

        [Fact]
        public void ApurarQuartasDeFinal_NotasIguais_ApuracaoOcorrePorTitulo()
        {
            var filmes = new List<Filme>
            {
                new Filme("Os Incríveis 2", 8.5),
                new Filme("Jurassic World: Reino Ameaçado", 7.2),
                new Filme("Oito Mulheres e um Segredo", 6.3),
                new Filme("Hereditário", 7.8),
                new Filme("Vingadores: Guerra Infinita", 7.8),
                new Filme("Deadpool 2", 6.3),
                new Filme("Han Solo: Uma História Star Wars", 7.2),
                new Filme("Thor: Ragnarok", 8.5)
            };

            var filmeService = new FilmeService();
            var resultado = filmeService.ApurarQuartasDeFinal(filmes);

            Assert.Equal("Os Incríveis 2", resultado.ElementAt(0).Titulo);
            Assert.Equal("Han Solo: Uma História Star Wars", resultado.ElementAt(1).Titulo);
            Assert.Equal("Deadpool 2", resultado.ElementAt(2).Titulo);
            Assert.Equal("Hereditário", resultado.ElementAt(3).Titulo);
        }

        [Fact]
        public void ApurarQuartasDeFinal_MaisQueOitoFilmes_GeraExcecao()
        {
            var filme1 = new Filme("ABC", 10);
            var filme2 = new Filme("DEF", 9);
            var filme3 = new Filme("GHI", 8);
            var filme4 = new Filme("ABC", 10);
            var filme5 = new Filme("DEF", 9);
            var filme6 = new Filme("GHI", 8);
            var filme7 = new Filme("ABC", 10);
            var filme8 = new Filme("DEF", 9);
            var filme9 = new Filme("GHI", 8);

            var filmes = new List<Filme>
            {
                filme1,
                filme2,
                filme3,
                filme4,
                filme5,
                filme6,
                filme7,
                filme8,
                filme9
            };

            var filmeService = new FilmeService();
            Assert.Throws<QuantidadeFilmesInvalida>("Quantidade de filmes.", () => filmeService.ApurarQuartasDeFinal(filmes));
        }

        [Fact]
        public void ApurarQuartasDeFinal_MenosQueOitoFilmes_GeraExcecao()
        {
            var filme1 = new Filme("ABC", 10);
            var filme2 = new Filme("DEF", 9);
            var filme3 = new Filme("GHI", 8);
            var filme4 = new Filme("ABC", 10);
            var filme5 = new Filme("DEF", 9);
            var filme6 = new Filme("GHI", 8);
            var filme7 = new Filme("ABC", 10);

            var filmes = new List<Filme>
            {
                filme1,
                filme2,
                filme3,
                filme4,
                filme5,
                filme6,
                filme7
            };

            var filmeService = new FilmeService();
            Assert.Throws<QuantidadeFilmesInvalida>("Quantidade de filmes.", () => filmeService.ApurarQuartasDeFinal(filmes));
        }

        [Fact]
        public void ApurarSemiFinal_NotasDiferentes_ApuracaoOcorrePorNota()
        {
            var filmes = new List<Filme>
            {
                new Filme("Os Incríveis 2", 8.5),
                new Filme("Jurassic World: Reino Ameaçado", 6.7),
                new Filme("Oito Mulheres e um Segredo", 6.3),
                new Filme("Hereditário", 7.8)
            };

            var filmeService = new FilmeService();
            var resultado = filmeService.ApurarSemiFinal(filmes);

            Assert.Equal("Os Incríveis 2", resultado.ElementAt(0).Titulo);
            Assert.Equal("Hereditário", resultado.ElementAt(1).Titulo);
        }

        [Fact]
        public void ApurarSemiFinal_NotasIguais_ApuracaoOcorrePorTitulo()
        { 
            var filmes = new List<Filme>
            {
                new Filme("Os Incríveis 2", 8.5),
                new Filme("Jurassic World: Reino Ameaçado", 8.5),
                new Filme("Oito Mulheres e um Segredo", 7.8),
                new Filme("Hereditário", 7.8)
            };

            var filmeService = new FilmeService();
            var resultado = filmeService.ApurarSemiFinal(filmes);

            Assert.Equal("Jurassic World: Reino Ameaçado", resultado.ElementAt(0).Titulo);
            Assert.Equal("Hereditário", resultado.ElementAt(1).Titulo);
        }

        [Fact]
        public void ApurarSemiFinal_MaisQueQuatroFilmes_GeraExcecao()
        {
            var filme1 = new Filme("ABC", 10);
            var filme2 = new Filme("DEF", 9);
            var filme3 = new Filme("GHI", 8);
            var filme4 = new Filme("ABC", 10);
            var filme5 = new Filme("DEF", 9);

            var filmes = new List<Filme>
            {
                filme1,
                filme2,
                filme3,
                filme4,
                filme5
            };

            var filmeService = new FilmeService();
            Assert.Throws<QuantidadeFilmesInvalida>("Quantidade de filmes.", () => filmeService.ApurarQuartasDeFinal(filmes));
        }

        [Fact]
        public void ApurarSemiFinal_MenosQueQuatroFilmes_GeraExcecao()
        {
            var filme1 = new Filme("ABC", 10);
            var filme2 = new Filme("DEF", 9);
            var filme3 = new Filme("GHI", 8);

            var filmes = new List<Filme>
            {
                filme1,
                filme2,
                filme3
            };

            var filmeService = new FilmeService();
            Assert.Throws<QuantidadeFilmesInvalida>("Quantidade de filmes.", () => filmeService.ApurarQuartasDeFinal(filmes));
        }

        [Fact]
        public void PrepararFilmesParaApuracao_OrdenaFilmesPorTitulo()
        {
            var filmes = new List<Filme>
            {
                new Filme("Os Incríveis 2", 8.5),
                new Filme("Jurassic World: Reino Ameaçado", 8.5),
                new Filme("Oito Mulheres e um Segredo", 7.8),
                new Filme("Hereditário", 7.8)
            };

            var filmeService = new FilmeService();
            var resultado = filmeService.PrepararFilmesParaApuracao(filmes);

            Assert.Equal("Hereditário", resultado.ElementAt(0).Titulo);
            Assert.Equal("Jurassic World: Reino Ameaçado", resultado.ElementAt(1).Titulo);
            Assert.Equal("Oito Mulheres e um Segredo", resultado.ElementAt(2).Titulo);
            Assert.Equal("Os Incríveis 2", resultado.ElementAt(3).Titulo);
        }

        [Fact]
        public void PrepararFilmesParaApuracao_ListaVazia_NaoPodeGerarErro()
        {
            var filmes = new List<Filme>();

            var filmeService = new FilmeService();
            var resultado = filmeService.PrepararFilmesParaApuracao(filmes);

            Assert.Empty(resultado);
        }
    }
}
