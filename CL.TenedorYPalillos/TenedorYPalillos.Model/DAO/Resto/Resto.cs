using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TenedorYPalillos.Model.DAO.Resto
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
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }

        [ForeignKey("ID_Resto")]
        public ICollection<Resto_Tipo_Resto> Resto_Tipo_Resto { get => _restoTipoRestoDAO; set => _restoTipoRestoDAO = value; }

    }
}
