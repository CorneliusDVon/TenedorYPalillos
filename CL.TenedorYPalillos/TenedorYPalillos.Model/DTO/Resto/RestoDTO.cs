using Newtonsoft.Json;

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



        public override bool Equals(object? obj)
        {
            return obj is RestoDTORequest request &&
                   Sociedad == request.Sociedad &&
                   ID == request.ID &&
                   Nombre == request.Nombre &&
                   Descripcion == request.Descripcion &&
                   EqualityComparer<List<TipoRestoDTORequest>>.Default.Equals(TipoResto, request.TipoResto);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Sociedad, ID, Nombre, Descripcion, TipoResto);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(base.MemberwiseClone());
        }

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



        public override bool Equals(object? obj)
        {
            return obj is TipoRestoDTORequest request &&
                   ID == request.ID &&
                   Nombre == request.Nombre;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID, Nombre);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(base.MemberwiseClone());
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(base.MemberwiseClone());
        }

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

        public override bool Equals(object? obj)
        {
            return obj is RestoDTOResponse response &&
                   ID == response.ID &&
                   Nombre == response.Nombre &&
                   Descripcion == response.Descripcion &&
                   EqualityComparer<List<TipoRestoDTOResponse>>.Default.Equals(TipoResto, response.TipoResto);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID, Nombre, Descripcion, TipoResto);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(base.MemberwiseClone());
        }

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



        public override bool Equals(object? obj)
        {
            return obj is TipoRestoDTOResponse response &&
                   ID == response.ID &&
                   Nombre == response.Nombre;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID, Nombre);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(base.MemberwiseClone());
        }

    }


    #endregion


}
