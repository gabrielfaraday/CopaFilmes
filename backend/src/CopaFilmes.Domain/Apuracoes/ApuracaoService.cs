using CopaFilmes.Domain.Filmes;
using System.Collections.Generic;

namespace CopaFilmes.Domain.Apuracoes
{
    public class ApuracaoService : IApuracaoService
    {
        readonly IFilmeService _filmeService;

        public ApuracaoService(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        public IEnumerable<Filme> ApurarEliminatorias(List<Filme> filmes)
        {
            var filmesApuracao = _filmeService.PrepararFilmesParaApuracao(filmes);
            filmesApuracao = _filmeService.ApurarQuartasDeFinal(filmesApuracao);
            filmesApuracao = _filmeService.ApurarSemiFinal(filmesApuracao);
            return _filmeService.ApurarFinal(filmesApuracao);
        }
    }
}
