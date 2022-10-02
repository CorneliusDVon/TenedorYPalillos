using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;


namespace TenedorYPalillos.Model.DAO.UsuarioEntity
{

    [Serializable]
    public class User : IdentityUser
    {

        private string _nombre_1;
        private string _nombre_2;
        private string _nombre_3;
        private string _apellido_1;
        private string _apellido_2;


        public User()
        {
            Nombre_1 = string.Empty;
            Nombre_2 = string.Empty;
            Nombre_3 = string.Empty;
            Apellido_1 = string.Empty;
            Apellido_2 = string.Empty;
        }


        [Column(TypeName = "nvarchar(200)")]
        public string Nombre_1 { get => _nombre_1; set => _nombre_1 = value; }

        [Column(TypeName = "nvarchar(200)")]
        public string Nombre_2 { get => _nombre_2; set => _nombre_2 = value; }

        [Column(TypeName = "nvarchar(200)")]
        public string Nombre_3 { get => _nombre_3; set => _nombre_3 = value; }

        [Column(TypeName = "nvarchar(200)")]
        public string Apellido_1 { get => _apellido_1; set => _apellido_1 = value; }

        [Column(TypeName = "nvarchar(200)")]
        public string Apellido_2 { get => _apellido_2; set => _apellido_2 = value; }


    }

}
