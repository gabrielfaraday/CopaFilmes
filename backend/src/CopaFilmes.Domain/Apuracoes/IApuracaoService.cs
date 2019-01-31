using CopaFilmes.Domain.Filmes;
using System.Collections.Generic;

namespace CopaFilmes.Domain.Apuracoes
{
    public interface IApuracaoService
    {
        IEnumerable<Filme> ApurarEliminatorias(List<Filme> filmes);
    }
}
