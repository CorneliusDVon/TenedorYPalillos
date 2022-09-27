using Microsoft.AspNetCore.Mvc;
using TenedorYPalillos.BaseController;
using TenedorYPalillos.Model.DTO.Login;


namespace TenedorYPalillos.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class LoginAPIController : BaseAPIController
    {


        [HttpPost(Name = "Login", Order = 1)]
        public async Task<ActionResult<LoginResponseDTO>> IniciaSesion(LoginRequestDTO request)
        {

            try
            {
                //return await new LoginController().IniciaSesion(request);

                return await mediator.Send(request);

            }
            catch (Exception ex)
            {
                throw;
            }

        }


    }

}
