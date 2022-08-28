using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace TenedorYPalillos.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PingController : ControllerBase
    {

        //private readonly ILogger<PingController> _logger;

        //public PingController(ILogger<PingController> logger)
        //{
        //    _logger = logger;
        //}


        [HttpGet(Name = "Ping")]
        public ActionResult<string> Get()
        {
            return new UriBuilder(
                Request.Scheme, 
                Request.Host.Host.ToString(),
                Request.Host.Port.Value,
                Request.Path,
                Url.Content("~")).ToString();
        }

    }
}