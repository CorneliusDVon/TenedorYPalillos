using MediatR;
using System;


namespace TenedorYPalillos.Model.DTO.Usuario
{

    public class UsuarioRequestDTO : IRequest<UsuarioResponseDTO>
    {

        private string _sociedad;
        private string _rut;
        private string _nombreUsuario;
        private string _nombre1;
        private string _nombre2;
        private string _nombre3;
        private string _apellido1;
        private string _apellido2;
        private string _contraseña;
        private string _email;


        public UsuarioRequestDTO()
        {
            Sociedad = string.Empty;
            Rut = string.Empty;
            NombreUsuario = string.Empty;
            Nombre1 = string.Empty;
            Nombre2 = string.Empty;
            Nombre3 = string.Empty;
            Apellido1 = string.Empty;
            Apellido2 = string.Empty;
            Contraseña = string.Empty;
            Email = string.Empty;
        }


        public string NombreUsuario { get => _nombreUsuario; set => _nombreUsuario = value; }
        public string Nombre1 { get => _nombre1; set => _nombre1 = value; }
        public string Nombre2 { get => _nombre2; set => _nombre2 = value; }
        public string Nombre3 { get => _nombre3; set => _nombre3 = value; }
        public string Apellido1 { get => _apellido1; set => _apellido1 = value; }
        public string Apellido2 { get => _apellido2; set => _apellido2 = value; }
        public string Contraseña { get => _contraseña; set => _contraseña = value; }
        public string Email { get => _email; set => _email = value; }
        public string Sociedad { get => _sociedad; set => _sociedad = value; }
        public string Rut { get => _rut; set => _rut = value; }

    }


    public class UsuarioResponseDTO
    {

        private string _sociedad;
        private string _rut;
        private string _nombreUsuario;
        private string _nombre1;
        private string _nombre2;
        private string _nombre3;
        private string _apellido1;
        private string _apellido2;
        private string _contraseña;
        private string _email;
        private UsuarioErrorResponseDTO _error;


        public UsuarioResponseDTO()
        {
            Sociedad = string.Empty;
            Rut = string.Empty;
            NombreUsuario = string.Empty;
            Nombre1 = string.Empty;
            Nombre2 = string.Empty;
            Nombre3 = string.Empty;
            Apellido1 = string.Empty;
            Apellido2 = string.Empty;
            Contraseña = string.Empty;
            Email = string.Empty;
            //Error = new UsuarioErrorResponseDTO();
        }


        public string NombreUsuario { get => _nombreUsuario; set => _nombreUsuario = value; }
        public string Nombre1 { get => _nombre1; set => _nombre1 = value; }
        public string Nombre2 { get => _nombre2; set => _nombre2 = value; }
        public string Nombre3 { get => _nombre3; set => _nombre3 = value; }
        public string Apellido1 { get => _apellido1; set => _apellido1 = value; }
        public string Apellido2 { get => _apellido2; set => _apellido2 = value; }
        public string Contraseña { get => _contraseña; set => _contraseña = value; }
        public string Email { get => _email; set => _email = value; }
        public string Sociedad { get => _sociedad; set => _sociedad = value; }
        public string Rut { get => _rut; set => _rut = value; }
        public UsuarioErrorResponseDTO Error { get => _error; set => _error = value; }

    }


    public class UsuarioErrorResponseDTO
    {

        private bool _isOK;
        private string _id;
        private string _mensaje;

        public UsuarioErrorResponseDTO()
        {
            IsOK = false;
            Id = string.Empty;
            Mensaje = string.Empty;
        }

        public bool IsOK { get => _isOK; set => _isOK = value; }
        public string Id { get => _id; set => _id = value; }
        public string Mensaje { get => _mensaje; set => _mensaje = value; }

    }



}
