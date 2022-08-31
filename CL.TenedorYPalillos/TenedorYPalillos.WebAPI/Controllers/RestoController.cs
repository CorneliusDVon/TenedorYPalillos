using LLegoCarta.Controller;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using TenedorYPalillos.Model.DTO.Resto;


namespace TenedorYPalillos.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class RestoController : ControllerBase
    {


        private readonly ILogger<PingController> _logger;


        public RestoController(ILogger<PingController> logger)
        {
            _logger = logger;
        }



        // GET: RestoController
        [HttpGet]
        public ActionResult<List<RestoDTO>> Obtiene()
        {

            TenedorYPalillosController tenedorYPalillosController = new  TenedorYPalillosController();
             tenedorYPalillosController.CargaTodoResto(string.Empty);

            return tenedorYPalillosController.RestoDTOList;
        }


        [HttpGet("{sociedad}/{id}")]
        public ActionResult<List<RestoDTO>> ObtieneID(string sociedad, int id)
        {
            TenedorYPalillosController tenedorYPalillosController = new TenedorYPalillosController();
            tenedorYPalillosController.CargaRestoPorID(string.Empty, id);

            return tenedorYPalillosController.RestoDTOList;
        }


        [HttpPost]
        public ActionResult<List<RestoDTO>> Actualiza(RestoDTO resto)
        {
            TenedorYPalillosController tenedorYPalillosController = new TenedorYPalillosController();
            tenedorYPalillosController.CargaTodoResto(string.Empty);

            return tenedorYPalillosController.RestoDTOList;
        }


        [HttpPut]
        public ActionResult<List<RestoDTO>> Crea(RestoDTO resto)
        {
            TenedorYPalillosController tenedorYPalillosController = new TenedorYPalillosController();
            tenedorYPalillosController.CargaTodoResto(string.Empty);

            return tenedorYPalillosController.RestoDTOList;
        }


        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult<List<RestoDTO>> Elimina(int id)
        {
            TenedorYPalillosController tenedorYPalillosController = new TenedorYPalillosController();
            tenedorYPalillosController.CargaTodoResto(string.Empty);

            return tenedorYPalillosController.RestoDTOList;
        }



    }
}
