using System;

namespace CopaFilmes.Domain.Exceptions
{
    public class QuantidadeFilmesInvalida : ArgumentOutOfRangeException
    {
        public QuantidadeFilmesInvalida(string parametro, object valorAtual, string mensagem) : base(parametro, valorAtual, mensagem)
        {

        }
    }
}
