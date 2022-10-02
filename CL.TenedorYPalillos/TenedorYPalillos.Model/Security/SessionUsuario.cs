using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TenedorYPalillos.Model.Contract.SessionUsuario;


namespace TenedorYPalillos.Model.Security
{

    public class SessionUsuario : ISessionUsuario
    {

        private readonly IHttpContextAccessor _httpContextAccessor;    


        public SessionUsuario(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        public string ObtenerSession()
        {
            string NombreUSuario = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            return NombreUSuario;            
        }

    }

}
