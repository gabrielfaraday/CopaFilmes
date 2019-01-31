using CopaFilmes.Domain.Apuracoes;
using CopaFilmes.Domain.Filmes;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CopaFilmes.Domain.Tests.Apuracoes
{
    public class ApuracaoServiceTest
    {
        readonly Mock<IFilmeService> _filmeServiceMock;
        ApuracaoService _apuracaoService;

        public ApuracaoServiceTest()
        {
            _filmeServiceMock = new Mock<IFilmeService>();
            _apuracaoService = new ApuracaoService(_filmeServiceMock.Object);
        }

        [Fact]
        public void ApurarEliminatorias_DeveOrdenarFilmes_ApurarQuartas_ApurarSemi_ApuraFinal()
        {
            var filme1 = new Filme("ABC", 10);
            var filme2 = new Filme("DEF", 9);

            _filmeServiceMock
                .Setup(x => x.ApurarFinal(It.IsAny<IEnumerable<Filme>>()))
                .Returns(new List<Filme> { filme1, filme2 });

            var resultado = _apuracaoService.ApurarEliminatorias(new List<Filme>());

            _filmeServiceMock.Verify(x => x.PrepararFilmesParaApuracao(It.IsAny<IEnumerable<Filme>>()), Times.Once);
            _filmeServiceMock.Verify(x => x.ApurarQuartasDeFinal(It.IsAny<IEnumerable<Filme>>()), Times.Once);
            _filmeServiceMock.Verify(x => x.ApurarSemiFinal(It.IsAny<IEnumerable<Filme>>()), Times.Once);
            _filmeServiceMock.Verify(x => x.ApurarFinal(It.IsAny<IEnumerable<Filme>>()), Times.Once);

            Assert.Same(resultado.ElementAt(0), filme1);
            Assert.Same(resultado.ElementAt(1), filme2);
        }
    }
}
