using System.Collections.Generic;

namespace CopaFilmes.Domain.Filmes
{
    public interface IFilmeService
    {
        IEnumerable<Filme> ApurarFinal(IEnumerable<Filme> filmes);
        IEnumerable<Filme> ApurarQuartasDeFinal(IEnumerable<Filme> filmes);
        IEnumerable<Filme> ApurarSemiFinal(IEnumerable<Filme> filmes);
        IEnumerable<Filme> PrepararFilmesParaApuracao(IEnumerable<Filme> filmes);
    }
}