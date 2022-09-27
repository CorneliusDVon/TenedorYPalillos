using TenedorYPalillos.Connection.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using TenedorYPalillos.Model.DAO.UsuarioEntity;
using TenedorYPalillos.Model.DTO.Login;


namespace TenedorYPalillos.BaseController
{

    public class LoginController: IRequestHandler<LoginRequestDTO, LoginResponseDTO> 
    {


        private List<LoginResponseDTO> _loginResponseDTOList;
        private readonly UserManager<UsuarioEntityDAO> _userManager;
        private readonly SignInManager<UsuarioEntityDAO> _signInManager;


        public LoginController()
        {
            LoginResponseDTOList = new List<LoginResponseDTO>();
        }


        public LoginController(UserManager<UsuarioEntityDAO> userManager, SignInManager<UsuarioEntityDAO> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }



        private List<LoginResponseDTO> LoginResponseDTOList { get => _loginResponseDTOList; set => _loginResponseDTOList = value; }






        public async Task<LoginResponseDTO> Handle(LoginRequestDTO request, CancellationToken cancellationToken)
        {

            LoginResponseDTO loginResponseDTO = new LoginResponseDTO();
            UsuarioEntityDAO usuario;

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


                return loginResponseDTO;

            }

            throw new Exception("No se ha superado la validacion de la contraseña.");

        }


    }


}
