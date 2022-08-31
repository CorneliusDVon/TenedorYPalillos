using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TenedorYPalillos.Model.DAO.Resto
{

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
        public string Nombre { get => _nombre; set => _nombre = value; }

        [ForeignKey("ID_Tipo_Resto")]
        public ICollection<Resto_Tipo_Resto> Resto_Tipo_Resto { get => _restoTipoRestoDAO; set => _restoTipoRestoDAO = value; }


    }
}
