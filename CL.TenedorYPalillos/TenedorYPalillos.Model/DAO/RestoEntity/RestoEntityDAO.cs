using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace TenedorYPalillos.Model.DAO.RestoEntity
{

    [Serializable]
    public class Resto
    {

        private long _iD;
        private string _nombre;
        private string _descripcion;
        private ICollection<Resto_Tipo_Resto> _restoTipoRestoDAO;


        public Resto()
        {
            //ID = 0;
            //Nombre = string.Empty;
            //Descripcion = string.Empty;
            //Resto_Tipo_Resto = new List<RestoTipoRestoDAO>();
        }


        [Key]
        public long ID { get => _iD; set => _iD = value; }

        [Column(TypeName = "nvarchar(200)")]
        public string Nombre { get => _nombre; set => _nombre = value; }

        [Column(TypeName = "nvarchar(200)")]
        public string Descripcion { get => _descripcion; set => _descripcion = value; }

        [ForeignKey("ID_Resto")]
        public ICollection<Resto_Tipo_Resto> Resto_Tipo_Resto { get => _restoTipoRestoDAO; set => _restoTipoRestoDAO = value; }

    }


    [Serializable]
    public class Resto_Tipo_Resto
    {

        private long _iD_Resto;
        private long _iD_Tipo_Resto;

        //ANCLAS
        private Resto _resto;
        private Tipo_Resto _tipoResto;


        public Resto_Tipo_Resto()
        {
            //Resto = new RestoDAO();
            //ID_Resto = 0;
            //ID_Tipo_Resto = 0;
            //Tipo_Resto = new TipoRestoDAO();
        }


        public long ID_Resto { get => _iD_Resto; set => _iD_Resto = value; }
        public long ID_Tipo_Resto { get => _iD_Tipo_Resto; set => _iD_Tipo_Resto = value; }

        public Resto Resto { get => _resto; set => _resto = value; }
        public Tipo_Resto Tipo_Resto { get => _tipoResto; set => _tipoResto = value; }

    }


    [Serializable]
    public class Tipo_Resto
    {

        private long _iD;
        private string _nombre;
        private ICollection<Resto_Tipo_Resto> _restoTipoRestoDAO;


        public Tipo_Resto()
        {
            //ID = 0;
            //Nombre = string.Empty;
            //Resto_Tipo_Resto = new RestoTipoRestoDAO();
        }


        [Key]
        public long ID { get => _iD; set => _iD = value; }

        [Column(TypeName = "nvarchar(200)")]
        public string Nombre { get => _nombre; set => _nombre = value; }

        [ForeignKey("ID_Tipo_Resto")]
        public ICollection<Resto_Tipo_Resto> Resto_Tipo_Resto { get => _restoTipoRestoDAO; set => _restoTipoRestoDAO = value; }


    }

}
