using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenedorYPalillos.Model.DAO.UsuarioEntity;


namespace TenedorYPalillos.Model.Contract.Login
{

    public interface IJWTGen
    {

        string GeneraJWT(Usuario usuario);

    }

}
