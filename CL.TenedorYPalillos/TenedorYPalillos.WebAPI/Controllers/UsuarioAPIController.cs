using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TenedorYPalillos.BaseController;
using TenedorYPalillos.Connection.Context;
using TenedorYPalillos.Model.DAO.UsuarioEntity;
using TenedorYPalillos.Model.DTO.Resto;
using TenedorYPalillos.Model.DTO.Usuario;


namespace TenedorYPalillos.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioAPIController : BaseAPIController
    {

        [HttpGet(Name = "Get", Order = 1)]
        public async Task<ActionResult<UsuarioResponseDTO>> TraeUsuario(UsuarioRequestDTO request)
        {

            try
            {
                return await new UsuarioController().Trae(request);
            }
            catch (Exception ex)
            {
                throw;
            }
                       
        }



        [HttpPost(Name = "Get", Order = 1)]
        public async Task<ActionResult<UsuarioResponseDTO>> CreaUsuario(UsuarioRequestDTO request)
        {

            try
            {
                return await mediator.Send(request);
            }
            catch (Exception ex)
            {
                throw new Exception("No se ha podido crear el usuario.");
            }

        }



    }


}
