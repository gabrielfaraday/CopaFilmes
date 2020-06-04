using CopaFilmes.Api.ExternalCalls.Filmes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    public class FilmeController : ControllerVersionBase
    {
        readonly IFilmeHttpExternalCall _filmeHttpExternalCall;

        public FilmeController(IFilmeHttpExternalCall filmeHttpExternalCall)
        {
            _filmeHttpExternalCall = filmeHttpExternalCall;
        }

        /// <summary>
        /// Retorna a lista completa de filmes
        /// </summary>
        /// <response code="200">Caso a solicitação ocorra com sucesso</response>
        /// <response code="500">Caso ocorra alguma falha de sistema</response>
        [HttpGet("listar-filmes")]
        public async Task<ActionResult<List<FilmeDto>>> ObterFilmes()
        {
            var filmes = await _filmeHttpExternalCall.ObterFilmes();
            return Ok(filmes);
        }
    }
}