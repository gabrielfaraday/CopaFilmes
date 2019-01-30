using CopaFilmes.Domain.Apuracoes;
using CopaFilmes.Domain.Filmes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.Api.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
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
        public ActionResult<List<Filme>> Get([FromBody]List<Filme> filmes)
        {
            return _apuracaoService.ApurarEliminatorias(filmes).ToList();
        }
    }
}