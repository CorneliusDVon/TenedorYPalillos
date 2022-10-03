using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;


namespace TenedorYPalillos.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BaseAPIController : ControllerBase
    {

        private IMediator _mediador;

        protected IMediator Mediator => _mediador ?? (_mediador = HttpContext.RequestServices.GetService<IMediator>());

    }
}
