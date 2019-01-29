namespace CopaFilmes.Domain.Filmes
{
    public interface IFilmeService
    {
        Filme ObterVencedor(Filme filme1, Filme filme2);
    }
}
