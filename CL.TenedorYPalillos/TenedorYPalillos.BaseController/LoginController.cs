using TenedorYPalillos.Connection.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using TenedorYPalillos.Model.DAO.UsuarioEntity;
using TenedorYPalillos.Model.DTO.Login;
using TenedorYPalillos.Model.Contract.Login;

namespace TenedorYPalillos.BaseController
{

    public class LoginController : IRequestHandler<LoginRequestDTO, LoginResponseDTO>
    {


        private List<LoginResponseDTO> _loginResponseDTOList;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly IJWTGen _jwtGen;


        public LoginController()
        {
            LoginResponseDTOList = new List<LoginResponseDTO>();
        }


        public LoginController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, IJWTGen jwtGen)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtGen = jwtGen;
        }



        private List<LoginResponseDTO> LoginResponseDTOList { get => _loginResponseDTOList; set => _loginResponseDTOList = value; }






        public async Task<LoginResponseDTO> Handle(LoginRequestDTO request, CancellationToken cancellationToken)
        {

            LoginResponseDTO loginResponseDTO = new LoginResponseDTO();
            Usuario usuario;

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
