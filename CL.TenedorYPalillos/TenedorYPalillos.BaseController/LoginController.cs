using MediatR;
using Microsoft.AspNetCore.Identity;
using TenedorYPalillos.Model.DAO.UsuarioEntity;
using TenedorYPalillos.Model.DTO.Login;
using TenedorYPalillos.Model.Contract.Security;


namespace TenedorYPalillos.BaseController
{

    public class LoginController : IRequestHandler<LoginRequestDTO, LoginResponseDTO>
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJWTGen _jwtGen;


        public LoginController(UserManager<User> userManager, SignInManager<User> signInManager, IJWTGen jwtGen)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtGen = jwtGen;
        }





        public async Task<LoginResponseDTO> Handle(LoginRequestDTO request, CancellationToken cancellationToken)
        {
            
            string proceso = request.TraeAccion();

            return proceso switch
            {
                "INICIA_SESSION" => await InicaSession(request),
                _ => throw new Exception("No se ha especificado una funcion a la operacion solicitada."),
            };

        }





        private async Task<LoginResponseDTO> InicaSession(LoginRequestDTO request)
        {


            LoginResponseDTO loginResponseDTO = new LoginResponseDTO();
            User usuario;

            usuario = await _userManager.FindByNameAsync(request.Usuario);


            if (request.Usuario.Trim().Equals(string.Empty) | request.Password.Trim().Equals(string.Empty))
            {
                throw new Exception("Debe especificar un usuario y una contraseña.");
            }


            if (usuario == null)
            {
                usuario = await _userManager.FindByEmailAsync(request.Usuario);

                if (usuario == null)
                {
                    throw new Exception("No se ha encontrado usuario " + request.Usuario + ".");
                }

            }

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(usuario, request.Password, false);

            if (result.Succeeded)
            {

                loginResponseDTO.ID = usuario.Id;
                loginResponseDTO.Usuario = usuario.UserName;
                loginResponseDTO.Password = usuario.PasswordHash;
                loginResponseDTO.DobleFactor = usuario.TwoFactorEnabled;
                loginResponseDTO.ContadorFallos = usuario.AccessFailedCount;
                loginResponseDTO.Token = _jwtGen.GeneraJWT(usuario);


                return loginResponseDTO;

            }

            throw new Exception("No se ha superado la validacion de la contraseña.");

        }


    }


}
