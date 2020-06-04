using Microsoft.AspNetCore.Mvc;

namespace CopaFilmes.Api.Controllers
{
    [Route("v{version:apiVersion}/api")]
    public class ControllerVersionBase : ControllerBase
    {
        
    }
}