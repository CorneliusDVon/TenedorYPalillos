using MediatR;
using System;


namespace TenedorYPalillos.Model.DTO.Login
{

    public class LoginRequestDTO : BaseRequest, IRequest<LoginResponseDTO>
    {

        private string _usuario;
        private string _password;

        public LoginRequestDTO()
        {
            Usuario = string.Empty;
            Password = string.Empty;
        }

        public string Usuario { get => _usuario; set => _usuario = value; }
        public string Password { get => _password; set => _password = value; }

    }


    public class LoginResponseDTO
    {

        private string _iD;
        private string _usuario;
        private string _password;
        private int _contadorFallos;
        private bool _dobleFactor;
        private string _token;


        public LoginResponseDTO()
        {
            ID = string.Empty;
            Usuario = string.Empty;
            Password = string.Empty;
            ContadorFallos = 0;
            DobleFactor = false;
            Token = "NO_VALID";
        }


        public string ID { get => _iD; set => _iD = value; }
        public string Usuario { get => _usuario; set => _usuario = value; }
        public string Password { get => _password; set => _password = value; }
        public int ContadorFallos { get => _contadorFallos; set => _contadorFallos = value; }
        public bool DobleFactor { get => _dobleFactor; set => _dobleFactor = value; }
        public string Token { get => _token; set => _token = value; }

    }



}
