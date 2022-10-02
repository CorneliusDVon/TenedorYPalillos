using Microsoft.AspNetCore.Mvc;
using TenedorYPalillos.Model.DTO.Usuario;


namespace TenedorYPalillos.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioAPIController : BaseAPIController
    {

        [HttpGet("ConsultaUsuarioSession")]
        public async Task<ActionResult<UsuarioResponseDTO>> ConsultaUsuarioSession(UsuarioRequestDTO request)
        {

            try
            {
                request.DefineAccion("CONSULTA_USUARIO_SESSION");
                return await mediator.Send(request);
            }
            catch (Exception ex)
            {
                throw;
            }
                       
        }



        [HttpPost("CreaUsuario")]
        public async Task<ActionResult<UsuarioResponseDTO>> CreaUsuario(UsuarioRequestDTO request)
        {

            try
            {
                request.DefineAccion("CREA_USUARIO");
                return await mediator.Send(request);
            }
            catch (Exception ex)
            {
                throw new Exception("No se ha podido crear el usuario.");
            }

        }



    }


}
