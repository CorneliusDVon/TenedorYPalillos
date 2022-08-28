using Microsoft.AspNetCore.Mvc;

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
            string url = Request.Scheme + "://" + Request.Host + "" + Request.Path + "" + Url.Content("~");

            return url;
        }

    }
}