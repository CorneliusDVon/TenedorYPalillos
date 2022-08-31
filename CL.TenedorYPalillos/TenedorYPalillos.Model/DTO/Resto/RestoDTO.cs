using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace TenedorYPalillos.Model.DTO.Resto
{


    #region "REQUEST"


    [JsonObject]
    [Serializable]
    public class RestoDTORequest
    {

        private string _sociedad;
        private long _iD;
        private string _nombre;
        private string _descripcion;
        private List<TipoRestoDTORequest> _listaTipoResto;


        public RestoDTORequest()
        {
            Sociedad = string.Empty;
            ID = 0;
            Nombre = string.Empty;
            Descripcion = string.Empty;
            TipoResto = new List<TipoRestoDTORequest>();
        }


        public string Sociedad { get => _sociedad; set => _sociedad = value; }
        public long ID { get => _iD; set => _iD = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public List<TipoRestoDTORequest> TipoResto { get => _listaTipoResto; set => _listaTipoResto = value; }

    }


    [JsonObject]
    [Serializable]
    public class TipoRestoDTORequest
    {

        private long _iD;
        private string _nombre;


        public TipoRestoDTORequest()
        {
            ID = 0;
            Nombre = string.Empty;
        }


        public long ID { get => _iD; set => _iD = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }

    }




    #endregion





    #region "RESPONSE"


    [JsonObject]
    [Serializable]
    public class RestoDTOResponse
    {

        private long _iD;
        private string _nombre;
        private string _descripcion;
        private List<TipoRestoDTOResponse> _tipoResto;


        public RestoDTOResponse()
        {
            ID = 0;
            Nombre = string.Empty;
            Descripcion = string.Empty;
            TipoResto = new List<TipoRestoDTOResponse>();
        }


        public long ID { get => _iD; set => _iD = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public List<TipoRestoDTOResponse> TipoResto { get => _tipoResto; set => _tipoResto = value; }

    }


    [JsonObject]
    [Serializable]
    public class TipoRestoDTOResponse
    {

        private long _iD;
        private string _nombre;


        public TipoRestoDTOResponse()
        {
            ID = 0;
            Nombre = string.Empty;
        }


        public long ID { get => _iD; set => _iD = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }

    }


    #endregion





}
