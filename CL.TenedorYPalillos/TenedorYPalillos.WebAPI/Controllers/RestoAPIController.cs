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

        [HttpGet(Name = "GetAll", Order = 1)]
        public async Task<ActionResult<List<RestoResponseDTO>>> Obtiene()
        {

            try
            {
                return await new RestoController().CargaTodoResto(new RestoRequestDTO()
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
        public async Task<ActionResult<List<RestoResponseDTO>>> ObtieneID(string sociedad, int id)
        {

            try
            {
                return await new RestoController().CargaRestoPorID(new RestoRequestDTO()
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
        public async Task<ActionResult<List<RestoResponseDTO>>> Actualiza(RestoRequestDTO request)
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
        public async Task<ActionResult<List<RestoResponseDTO>>> Crea(RestoRequestDTO resto)
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
        public async Task<ActionResult<List<RestoResponseDTO>>> Elimina(string sociedad, int id)
        {

            try
            {
                return await new RestoController().EliminaRestoPorID(new RestoRequestDTO()
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
        //        return await mediador.Send(resto);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }

        //}



    }

}
