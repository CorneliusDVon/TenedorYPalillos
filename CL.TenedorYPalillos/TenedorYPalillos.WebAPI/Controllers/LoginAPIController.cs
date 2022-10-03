using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TenedorYPalillos.Model.DTO.Login;


namespace TenedorYPalillos.WebAPI.Controllers
{

    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class LoginAPIController : BaseAPIController
    {

        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponseDTO>> IniciaSesion(LoginRequestDTO request)
        {

            try
            {
                request.DefineAccion("INICIA_SESSION");
                return await Mediator.Send(request);
            }
            catch (Exception ex)
            {
                throw new Exception("No se ha podido iniciar sesion. Por favor, verifique sus credenciales.");
            }

        }


    }

}
