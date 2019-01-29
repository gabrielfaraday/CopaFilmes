using System.Collections.Generic;

namespace CopaFilmes.Domain.Filmes
{
    public interface IApuracaoService
    {
        IEnumerable<Filme> ApurarEliminatorias(List<Filme> filmes);
    }
}
