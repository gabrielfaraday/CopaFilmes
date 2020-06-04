using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.Api.ExternalCalls.Filmes
{
    public interface IFilmeHttpExternalCall
    {
        Task<List<FilmeDto>> ObterFilmes();
    }
}