using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using TenedorYPalillos.Connection.Context;
using TenedorYPalillos.Model.Contract.Security;
using TenedorYPalillos.Model.Contract.SessionUsuario;
using TenedorYPalillos.Model.DAO.UsuarioEntity;
using TenedorYPalillos.Model.DTO.Usuario;


namespace TenedorYPalillos.BaseController
{

    public class UsuarioController : IRequestHandler<UsuarioRequestDTO, UsuarioResponseDTO>
    {

        private readonly TenedorYPalillosContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IJWTGen _gen;
        private readonly ISessionUsuario _sessionUsuario;


        public UsuarioController(TenedorYPalillosContext context, UserManager<User> userManager, IJWTGen gen, ISessionUsuario sessionUsuario)
        {
            _context = context;
            _userManager = userManager;
            _gen = gen;
            _sessionUsuario = sessionUsuario;
        }





        public async Task<UsuarioResponseDTO> Handle(UsuarioRequestDTO request, CancellationToken cancellationToken)
        {

            string proceso = request.TraeAccion();


            return proceso switch
            {
                "CONSULTA_USUARIO_SESSION" => await ConsultaUsuarioSession(),
                "CREA_USUARIO" => await CreaUsuario(request),
                _ => throw new Exception("No se ha especificado una funcion a la operacion solicitada."),
            };

        }




        
        private async Task<UsuarioResponseDTO> ConsultaUsuarioSession()
        {

            User usuario = await _userManager.FindByNameAsync(_sessionUsuario.ObtenerSession());


            return new UsuarioResponseDTO()
            {
                NombreUsuario = usuario.UserName,
                Nombre1 = usuario.Nombre_1,
                Nombre2 = usuario.Nombre_2,
                Nombre3 = usuario.Nombre_3,
                Apellido1 = usuario.Apellido_1,
                Apellido2 = usuario.Apellido_2,
                Email = usuario.Email,
            };

        }


        private async Task<UsuarioResponseDTO> CreaUsuario(UsuarioRequestDTO request)
        {

            bool existe = false;

            try
            {

                existe = await _context.Users.Where(x => x.UserName == request.NombreUsuario).AnyAsync();

                if (existe == true)
                {
                    throw new Exception("Este usuario ya existe.");
                }

                existe = await _context.Users.Where(x => x.NormalizedEmail == request.Email.ToUpper()).AnyAsync();

                if (existe == true)
                {
                    throw new Exception("Este usuario ya existe.");
                }

                User usuario = new User();
                usuario.Nombre_1 = request.Nombre1;
                usuario.Nombre_2 = request.Nombre2;
                usuario.Nombre_3 = request.Nombre3;
                usuario.Apellido_1 = request.Apellido1;
                usuario.Apellido_2 = request.Apellido2;
                usuario.Email = request.Email;
                usuario.UserName = request.NombreUsuario;
                usuario.PhoneNumber = request.Sociedad;

                IdentityResult unit = await _userManager.CreateAsync(usuario,request.Contraseña);

                if (unit.Succeeded == false)
                {
                    throw new Exception("No se ha podido crear el usuario.");
                }

                usuario = _context.Users.Single(x => x.UserName == request.NombreUsuario);

                return new UsuarioResponseDTO
                {
                    Nombre1 = usuario.Nombre_1,
                    Nombre2 = usuario.Nombre_2,
                    Nombre3 = usuario.Nombre_3,
                    Apellido1 = usuario.Apellido_1,
                    Apellido2 = usuario.Apellido_2,
                    Email = usuario.Email,
                    NombreUsuario = usuario.UserName,
                    Sociedad = usuario.PhoneNumber,
                    Error = new UsuarioErrorResponseDTO
                    {
                        Id = usuario.Id,
                        IsOK = true,
                        Mensaje = "Se ha creado el Usuario para " + usuario.Nombre_1 + " " + usuario.Apellido_1 + " " + usuario.Apellido_2
                    }
                };

            }
            catch (Exception)
            {
                throw new Exception("No se ha podido crear el usuario");
            }

        }


    }

}
