using MediatR;
using Newtonsoft.Json;


namespace TenedorYPalillos.Model.DTO.Resto
{


    #region "REQUEST"


    public class RestoRequestDTO : BaseRequest, IRequest<List<RestoResponseDTO>>
    {

        private string _sociedad;
        private long _iD;
        private string _nombre;
        private string _descripcion;
        private List<TipoRestoRequestDTO> _listaTipoResto;


        public RestoRequestDTO()
        {
            Sociedad = string.Empty;
            ID = 0;
            Nombre = string.Empty;
            Descripcion = string.Empty;
            TipoResto = new List<TipoRestoRequestDTO>();
        }


        public string Sociedad { get => _sociedad; set => _sociedad = value; }
        public long ID { get => _iD; set => _iD = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public List<TipoRestoRequestDTO> TipoResto { get => _listaTipoResto; set => _listaTipoResto = value; }



        public override bool Equals(object? obj)
        {
            return obj is RestoRequestDTO request &&
                   Sociedad == request.Sociedad &&
                   ID == request.ID &&
                   Nombre == request.Nombre &&
                   Descripcion == request.Descripcion &&
                   EqualityComparer<List<TipoRestoRequestDTO>>.Default.Equals(TipoResto, request.TipoResto);
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


    public class TipoRestoRequestDTO
    {

        private long _iD;
        private string _nombre;


        public TipoRestoRequestDTO()
        {
            ID = 0;
            Nombre = string.Empty;
        }


        public long ID { get => _iD; set => _iD = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }



        public override bool Equals(object? obj)
        {
            return obj is TipoRestoRequestDTO request &&
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

    }


    #endregion





    #region "RESPONSE"


    public class RestoResponseDTO
    {

        private long _iD;
        private string _nombre;
        private string _descripcion;
        private List<TipoRestoResponseDTO> _tipoResto;


        public RestoResponseDTO()
        {
            ID = 0;
            Nombre = string.Empty;
            Descripcion = string.Empty;
            TipoResto = new List<TipoRestoResponseDTO>();
        }


        public long ID { get => _iD; set => _iD = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public List<TipoRestoResponseDTO> TipoResto { get => _tipoResto; set => _tipoResto = value; }

        public override bool Equals(object? obj)
        {
            return obj is RestoResponseDTO response &&
                   ID == response.ID &&
                   Nombre == response.Nombre &&
                   Descripcion == response.Descripcion &&
                   EqualityComparer<List<TipoRestoResponseDTO>>.Default.Equals(TipoResto, response.TipoResto);
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


    public class TipoRestoResponseDTO
    {

        private long _iD;
        private string _nombre;


        public TipoRestoResponseDTO()
        {
            ID = 0;
            Nombre = string.Empty;
        }


        public long ID { get => _iD; set => _iD = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }



        public override bool Equals(object? obj)
        {
            return obj is TipoRestoResponseDTO response &&
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
