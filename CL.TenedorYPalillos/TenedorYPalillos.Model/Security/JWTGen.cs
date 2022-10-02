using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TenedorYPalillos.Model.Contract.Security;
using TenedorYPalillos.Model.DAO.UsuarioEntity;


namespace TenedorYPalillos.Model.Security
{

    public class JWTGen : IJWTGen
    {

        public string GeneraJWT(User usuario)
        {

            List<Claim> claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.NameId, usuario.UserName),
                new Claim(JwtRegisteredClaimNames.FamilyName, usuario.Nombre_1)
            };

            SymmetricSecurityKey llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aBcDeFgHiJkLmNñOpQrStUvWxYz1620.."));
            SigningCredentials credenciales = new SigningCredentials(llave, SecurityAlgorithms.HmacSha512Signature);


            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = credenciales
            };

            JwtSecurityTokenHandler manejador = new JwtSecurityTokenHandler();
            SecurityToken token = manejador.CreateToken(descriptor);


            return manejador.WriteToken(token).Trim();

        }


    }

}
