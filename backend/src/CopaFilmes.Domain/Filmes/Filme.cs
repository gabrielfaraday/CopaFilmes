namespace CopaFilmes.Domain.Filmes
{
    public class Filme
    {
        public string Titulo { get; private set; }
        public double Nota { get; private set; }

        public Filme(string titulo, double nota)
        {
            Titulo = titulo;
            Nota = nota;
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Filme;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Titulo.Equals(compareTo.Titulo);
        }

        public static bool operator ==(Filme a, Filme b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null)) return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;

            return a.Equals(b);
        }

        public static bool operator !=(Filme a, Filme b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 900) + Titulo.GetHashCode();
        }
    }
}
