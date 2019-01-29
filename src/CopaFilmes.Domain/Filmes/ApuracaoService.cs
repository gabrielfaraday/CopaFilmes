using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.Domain.Filmes
{
    public class ApuracaoService : IApuracaoService
    {
        private readonly IFilmeService _filmeService;

        public ApuracaoService(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        public IEnumerable<Filme> ApurarEliminatorias(List<Filme> filmes)
        {
            var filmesFinalistas = new List<Filme>();

            var vencedorQuartas1 = _filmeService.ObterVencedor(filmes[0], filmes[7]);
            var vencedorQuartas2 = _filmeService.ObterVencedor(filmes[1], filmes[6]);
            var vencedorQuartas3 = _filmeService.ObterVencedor(filmes[2], filmes[5]);
            var vencedorQuartas4 = _filmeService.ObterVencedor(filmes[3], filmes[4]);

            var vencedorSemi1 = _filmeService.ObterVencedor(vencedorQuartas1, vencedorQuartas2);
            var vencedorSemi2 = _filmeService.ObterVencedor(vencedorQuartas3, vencedorQuartas4);

            filmesFinalistas.Add(vencedorSemi1);
            filmesFinalistas.Add(vencedorSemi2);

            return filmesFinalistas
                .OrderBy(x => x.Nota)
                .ThenBy(x => x.Titulo);
        }
    }
}
