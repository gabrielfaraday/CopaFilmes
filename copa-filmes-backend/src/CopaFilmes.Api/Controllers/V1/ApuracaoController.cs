using CopaFilmes.Domain.Apuracoes;
using CopaFilmes.Domain.Filmes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    public class ApuracaoController : ControllerVersionBase
    {
        readonly IApuracaoService _apuracaoService;

        public ApuracaoController(IApuracaoService apuracaoService)
        {
            _apuracaoService = apuracaoService;
        }

        /// <summary>
        /// Realiza a apuração das eliminatórias com base nos filmes recebidos e retorna o campeão e vice campeão
        /// </summary>
        /// <param name="filmes">Lista de filmes participantes</param>
        /// <response code="200">Caso a apuração ocorra com sucesso</response>
        /// <response code="400">Caso ocorra alguma falha de negocio</response>
        /// <response code="500">Caso ocorra alguma falha de sistema</response>
        [HttpPost("apuracao")]
        public ActionResult<List<Filme>> ApurarResultado([FromBody] List<Filme> filmes)
        {
            return Ok(_apuracaoService.ApurarEliminatorias(filmes).ToList());
        }
    }
}