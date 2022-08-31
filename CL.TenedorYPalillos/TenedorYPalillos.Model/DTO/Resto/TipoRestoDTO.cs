using System;
using System.Collections.Generic;


namespace TenedorYPalillos.Model.DTO.Resto
{

    [Serializable]
    public class TipoRestoDTO
    {

        private long _iD;
        private string _nombre;
        private List<RestoTipoRestoDTO> _restoTipoRestoDTO;


        public TipoRestoDTO()
        {


        }


        public long ID { get => _iD; set => _iD = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public List<RestoTipoRestoDTO> Resto_Tipo_Resto { get => _restoTipoRestoDTO; set => _restoTipoRestoDTO = value; }

    }
}
