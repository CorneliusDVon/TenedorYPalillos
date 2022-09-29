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

        [HttpPost(Name = "Login", Order = 1)]
        public async Task<ActionResult<LoginResponseDTO>> IniciaSesion(LoginRequestDTO request)
        {

            try
            {
                return await mediator.Send(request);
            }
            catch (Exception ex)
            {
                throw new Exception("No se ha podido iniciar sesion. Por favor, verifique sus credenciales.");
            }

        }


    }

}
