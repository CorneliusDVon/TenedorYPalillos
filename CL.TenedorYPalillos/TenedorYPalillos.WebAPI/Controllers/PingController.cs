using Microsoft.AspNetCore.Mvc;
using TenedorYPalillos.Model.DTO.Log;
using TenedorYPalillos.Utils;

namespace TenedorYPalillos.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PingController : ControllerBase
    {

        private readonly ILogger<PingController> _logger;


        public PingController(ILogger<PingController> logger)
        {
            _logger = logger;
        }


        [HttpGet(Name = "Ping")]
        public ActionResult<string> Get()
        {

            Log.Info(new LogResquestDTO { 
                Society="ROOT",
                Date= DateTime.Now,
                LibraryClass= "PingController",
                Method= "Get",
                Message="se ha ejecutado el metodo GET para el recurso",
                Comment="",
                Detail=""
            });

            return new UriBuilder(
                Request.Scheme, 
                Request.Host.Host,
                Request.Host.Port.Value,
                Request.Path,
                Url.Content("~")).ToString();
        }

    }
}