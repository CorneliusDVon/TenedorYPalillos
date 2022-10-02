using System;
using TenedorYPalillos.Model.DAO.UsuarioEntity;


namespace TenedorYPalillos.Model.Contract.Security
{

    public interface IJWTGen
    {

        string GeneraJWT(User usuario);

    }

}
