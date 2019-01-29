namespace CopaFilmes.Domain.Filmes
{
    public class FilmeService : IFilmeService
    {
        public Filme ObterVencedor(Filme filme1, Filme filme2)
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
