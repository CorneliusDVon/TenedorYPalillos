using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TenedorYPalillos.Model.DAO.Resto
{

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
}
