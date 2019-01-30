using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.Domain.Filmes
{
    public class FilmeService : IFilmeService
    {
        public IEnumerable<Filme> ApurarFinal(IEnumerable<Filme> filmes)
        {
            return filmes.OrderByDescending(x => x.Nota).ThenBy(x => x.Titulo);
        }

        public IEnumerable<Filme> ApurarQuartasDeFinal(IEnumerable<Filme> filmes)
        {
            var vencedorQuartas1 = ObterVencedor(filmes.ElementAt(0), filmes.ElementAt(7));
            var vencedorQuartas2 = ObterVencedor(filmes.ElementAt(1), filmes.ElementAt(6));
            var vencedorQuartas3 = ObterVencedor(filmes.ElementAt(2), filmes.ElementAt(5));
            var vencedorQuartas4 = ObterVencedor(filmes.ElementAt(3), filmes.ElementAt(4));

            return new List<Filme>
            {
                vencedorQuartas1,
                vencedorQuartas2,
                vencedorQuartas3,
                vencedorQuartas4
            };
        }

        public IEnumerable<Filme> ApurarSemiFinal(IEnumerable<Filme> filmes)
        {
            var vencedorSemi1 = ObterVencedor(filmes.ElementAt(0), filmes.ElementAt(1));
            var vencedorSemi2 = ObterVencedor(filmes.ElementAt(2), filmes.ElementAt(3));

            return new List<Filme>
            {
                vencedorSemi1,
                vencedorSemi2
            };
        }

        public IEnumerable<Filme> PrepararFilmesParaApuracao(IEnumerable<Filme> filmes)
        {
            return filmes.OrderBy(x => x.Titulo);
        }

        private Filme ObterVencedor(Filme filme1, Filme filme2)
        {
            if (filme1.Nota > filme2.Nota)
                return filme1;

            if (filme1.Nota < filme2.Nota)
                return filme2;

            if (string.Compare(filme1.Titulo, filme2.Titulo) < 0)
                return filme1;

            return filme2;
        }
    }
}
