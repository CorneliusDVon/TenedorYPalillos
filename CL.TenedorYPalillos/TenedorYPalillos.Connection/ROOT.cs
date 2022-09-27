using Microsoft.AspNetCore.Identity;
using TenedorYPalillos.Connection.Context;
using TenedorYPalillos.Model.DAO.UsuarioEntity;


namespace TenedorYPalillos.Connection
{

    public class ROOT
    {

        public static async Task CreaUsuarioROOT(TenedorYPalillosContext tenedorYPalillosContext, UserManager<UsuarioEntityDAO> userManager)
        {

            if (userManager.Users.Any() == false)
            {

                UsuarioEntityDAO usuarioROOT = new UsuarioEntityDAO();
                usuarioROOT.Nombre_1 = "ROOT_USER";
                usuarioROOT.UserName = "ROOT";

                await userManager.CreateAsync(usuarioROOT, "Admin1ROOT#");

            }

        }



    }
}
