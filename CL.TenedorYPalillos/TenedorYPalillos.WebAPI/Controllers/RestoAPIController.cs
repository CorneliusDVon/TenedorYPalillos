using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TenedorYPalillos.BaseController;
using TenedorYPalillos.Model.DAO.RestoEntity;
using TenedorYPalillos.Model.DTO.Resto;


namespace TenedorYPalillos.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class RestoAPIController : BaseAPIController
    {

        [HttpGet("Trae")]
        public async Task<ActionResult<List<RestoResponseDTO>>> Obtiene(RestoRequestDTO request)
        {

            try
            {
                request.DefineAccion("CARGA_RESTO");
                return await Mediator.Send(request);
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        [HttpGet(template: "{sociedad}/{id}", Name = "TraeId")]
        public async Task<ActionResult<List<RestoResponseDTO>>> ObtieneID(string sociedad, int id)
        {

            try
            {
                RestoRequestDTO request = new RestoRequestDTO() { Sociedad = sociedad, ID = id };
                request.DefineAccion("CARGA_RESTO_ID");
                return await Mediator.Send(request);
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        [HttpPost("ActualizaId")]
        public async Task<ActionResult<List<RestoResponseDTO>>> Actualiza(RestoRequestDTO request)
        {

            try
            {
                request.DefineAccion("ACTUALIZA_RESTO_ID");
                return await Mediator.Send(request);
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        [HttpPut("Crea")]
        public async Task<ActionResult<List<RestoResponseDTO>>> Crea(RestoRequestDTO request)
        {

            try
            {
                request.DefineAccion("CREA_RESTO");
                return await Mediator.Send(request);
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        [HttpDelete(template: "{sociedad}/{id}",Name = "Elimina")]
        public async Task<ActionResult<List<RestoResponseDTO>>> Elimina(string sociedad, int id)
        {

            try
            {
                RestoRequestDTO request = new RestoRequestDTO()
                {
                    Sociedad = sociedad,
                    ID = id
                };

                request.DefineAccion("ELIMINA_RESTO_ID");

                return await Mediator.Send(request);
            }
            catch (Exception ex)
            {
                throw;
            }

        }


    }

}
