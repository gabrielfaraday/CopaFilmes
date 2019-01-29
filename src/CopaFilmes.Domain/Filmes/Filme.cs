namespace CopaFilmes.Domain.Filmes
{
    public class Filme
    {
        public string Titulo { get; private set; }
        public decimal Nota { get; private set; }

        public Filme(string titulo, decimal nota)
        {
            Titulo = titulo;
            Nota = nota;
        }
    }
}
