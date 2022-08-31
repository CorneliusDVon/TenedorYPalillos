using System;


namespace TenedorYPalillos.Model.DTO.Resto
{

    [Serializable]
    public class RestoTipoRestoDTO
    {

        private long _iD_Resto;
        private long _iD_Tipo_Resto;
        private RestoDTO _restoDTO;
        private TipoRestoDTO _tipoRestoDTO;


        public RestoTipoRestoDTO()
        {


        }


        public long ID_Resto { get => _iD_Resto; set => _iD_Resto = value; }
        public long ID_Tipo_Resto { get => _iD_Tipo_Resto; set => _iD_Tipo_Resto = value; }
        public RestoDTO Resto { get => _restoDTO; set => _restoDTO = value; }
        public TipoRestoDTO Tipo_Resto { get => _tipoRestoDTO; set => _tipoRestoDTO = value; }
    }
}
