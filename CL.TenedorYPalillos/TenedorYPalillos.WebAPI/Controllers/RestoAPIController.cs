using Microsoft.AspNetCore.Mvc;
using TenedorYPalillos.BaseController;
using TenedorYPalillos.Model.DTO.Resto;


namespace TenedorYPalillos.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class RestoAPIController : ControllerBase
    {

        private readonly ILogger<PingController> _logger;


        public RestoAPIController(ILogger<PingController> logger)
        {
            _logger = logger;
        }



        // GET: RestoController
        [HttpGet]
        public ActionResult<List<RestoDTOResponse>> Obtiene()
        {
            return new RestoController().CargaTodoResto(new RestoDTORequest()
            {
                Sociedad = string.Empty
            });
        }


        [HttpGet("{sociedad}/{id}")]
        public ActionResult<List<RestoDTOResponse>> ObtieneID(string sociedad, int id)
        {
            return new RestoController().CargaTodoResto(new RestoDTORequest()
            {
                Sociedad = sociedad,
                ID = id
            });
        }


        [HttpPost]
        public ActionResult<List<RestoDTOResponse>> Actualiza(RestoDTORequest resto)
        {
            return new RestoController().CargaTodoResto(new RestoDTORequest()
            {
                Sociedad = string.Empty
            });
        }


        [HttpPut]
        public ActionResult<List<RestoDTOResponse>> Crea(RestoDTORequest resto)
        {
            return new RestoController().CargaTodoResto(new RestoDTORequest()
            {
                Sociedad = string.Empty
            });
        }


        [HttpDelete]
        public ActionResult<List<RestoDTOResponse>> Elimina(int id)
        {
            return new RestoController().CargaTodoResto(new RestoDTORequest()
            {
                Sociedad = string.Empty
            });
        }



    }
}
