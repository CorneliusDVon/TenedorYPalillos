using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TenedorYPalillos.Model.DAO.LoginEntity
{

    [Serializable]
    public  class LoginEntityDAO
    {

        private string _iD;
        private string _usuario;
        private string _password;


        public LoginEntityDAO()
        {
            Usuario = string.Empty;
            Password = string.Empty;
        }


        [Key]
        [Column(TypeName = "nvarchar(450)")]
        public string ID { get => _iD; set => _iD = value; }

        [Column(TypeName = "nvarchar(256)")]
        public string Usuario { get => _usuario; set => _usuario = value; }

        [Column(TypeName = "nvarchar(256)")]
        public string Password { get => _password; set => _password = value; }

    }


}
