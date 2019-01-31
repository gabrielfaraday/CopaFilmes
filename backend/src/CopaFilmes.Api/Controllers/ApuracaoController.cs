using CopaFilmes.Domain.Apuracoes;
using CopaFilmes.Domain.Filmes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApuracaoController : ControllerBase
    {
        readonly IApuracaoService _apuracaoService;

        public ApuracaoController(IApuracaoService apuracaoService)
        {
            _apuracaoService = apuracaoService;
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public ActionResult<List<Filme>> Get([FromBody]List<Filme> filmes)
        {
            return Ok(_apuracaoService.ApurarEliminatorias(filmes).ToList());
        }
    }
}