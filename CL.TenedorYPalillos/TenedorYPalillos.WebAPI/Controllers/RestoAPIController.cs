using MediatR;
using Microsoft.AspNetCore.Mvc;
using TenedorYPalillos.BaseController;
using TenedorYPalillos.Model.DAO.RestoEntity;
using TenedorYPalillos.Model.DTO.Resto;


namespace TenedorYPalillos.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class RestoAPIController : ControllerBase
    {

        private readonly IMediator _mediador;


        public RestoAPIController(IMediator mediator)
        {
            _mediador = mediator;
        }





        [HttpGet(Name = "GetAll", Order = 1)]
        public async Task<ActionResult<List<RestoDTOResponse>>> Obtiene()
        {

            try
            {
                return await new RestoController().CargaTodoResto(new RestoDTORequest()
                {
                    Sociedad = string.Empty
                });
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        [HttpGet(template: "{sociedad}/{id}", Name = "GetID", Order = 2)]
        public async Task<ActionResult<List<RestoDTOResponse>>> ObtieneID(string sociedad, int id)
        {

            try
            {
                return await new RestoController().CargaRestoPorID(new RestoDTORequest()
                {
                    Sociedad = sociedad,
                    ID = id
                });
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        [HttpPost(Name = "UpdateID", Order = 3)]
        public async Task<ActionResult<List<RestoDTOResponse>>> Actualiza(RestoDTORequest request)
        {

            try
            {
                return await new RestoController().ActualizaRestoPorID(request);
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        [HttpPut(Name = "Insert", Order = 4)]
        public async Task<ActionResult<List<RestoDTOResponse>>> Crea(RestoDTORequest resto)
        {

            try
            {
                return await new RestoController().CreaResto(resto);
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        [HttpDelete(template: "{sociedad}/{id}", Name = "DeleteID", Order = 5)]
        public async Task<ActionResult<List<RestoDTOResponse>>> Elimina(string sociedad, int id)
        {

            try
            {
                return await new RestoController().EliminaRestoPorID(new RestoDTORequest()
                {
                    Sociedad = sociedad,
                    ID=id
                });
            }
            catch (Exception ex)
            {
                throw;
            }

        }



        //[HttpPut(Name = "Crea Nuevo Restaurant", Order = 4)]
        //public async Task<Unit> CreaHandler(RestoDTORequest resto)
        //{

        //    try
        //    {
        //        return await _mediador.Send(resto);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }

        //}



    }

}
