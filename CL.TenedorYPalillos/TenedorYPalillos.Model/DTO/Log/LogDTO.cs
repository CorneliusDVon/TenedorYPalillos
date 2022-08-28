using Newtonsoft.Json;


namespace TenedorYPalillos.Model.DTO.Log
{

    [JsonObject]
    [Serializable]
    public class LogResquestDTO
    {

        private string? _society;
        private string? _method;
        private string? _libraryClass;
        private string? _date;
        private string? _message;
        private string? _detail;
        private string? _comment;


        public LogResquestDTO()
        {
            Society = string.Empty;
            Method = string.Empty;
            LibraryClass = string.Empty;
            Date = string.Empty;
            Message = string.Empty;
            Detail = string.Empty;
            Comment = string.Empty;
        }

        public LogResquestDTO(string society, string method, string libraryClass, string date, string message, string detail, string comment)
        {
            Society = society ?? throw new ArgumentNullException(nameof(society));
            Method = method ?? throw new ArgumentNullException(nameof(method));
            LibraryClass = libraryClass ?? throw new ArgumentNullException(nameof(libraryClass));
            Date = date ?? throw new ArgumentNullException(nameof(date));
            Message = message ?? throw new ArgumentNullException(nameof(message));
            Detail = detail ?? throw new ArgumentNullException(nameof(detail));
            Comment = comment ?? throw new ArgumentNullException(nameof(comment));
        }

        public string? Society { get => _society; set => _society = value; }
        public string? Method { get => _method; set => _method = value; }
        public string? LibraryClass { get => _libraryClass; set => _libraryClass = value; }
        public string? Date { get => _date; set => _date = value; }
        public string? Message { get => _message; set => _message = value; }
        public string? Detail { get => _detail; set => _detail = value; }
        public string? Comment { get => _comment; set => _comment = value; }


        public override bool Equals(object? obj)
        {
            return obj is LogResquestDTO dTO &&
                   Society == dTO.Society &&
                   Method == dTO.Method &&
                   LibraryClass == dTO.LibraryClass &&
                   Date == dTO.Date &&
                   Message == dTO.Message &&
                   Detail == dTO.Detail &&
                   Comment == dTO.Comment;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Society, Method, LibraryClass, Date, Message, Detail, Comment);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(base.MemberwiseClone());
        }

    }


    [JsonObject]
    [Serializable]
    public class LogResponseDTO
    {

        private long? _id;
        private string? _society;
        private string? _method;
        private string? _libraryClass;
        private string? _date;
        private string? _message;
        private string? _detail;
        private string? _comment;


        public LogResponseDTO()
        {
            Id = 0;
            Society = string.Empty;
            Method = string.Empty;
            LibraryClass = string.Empty;
            Date = string.Empty;
            Message = string.Empty;
            Detail = string.Empty;
            Comment = string.Empty;
        }

        public LogResponseDTO(string society, long id, string method, string libraryClass, string date, string message, string detail, string comment)
        {
            Society = society;
            Id = id;
            Method = method;
            LibraryClass = libraryClass;
            Date = date;
            Message = message;
            Detail = detail;
            Comment = comment;
        }

        public string? Society { get => _society; set => _society = value; }
        public long? Id { get => _id; set => _id = value; }
        public string? Method { get => _method; set => _method = value; }
        public string? LibraryClass { get => _libraryClass; set => _libraryClass = value; }
        public string? Date { get => _date; set => _date = value; }
        public string? Message { get => _message; set => _message = value; }
        public string? Detail { get => _detail; set => _detail = value; }
        public string? Comment { get => _comment; set => _comment = value; }


        public override bool Equals(object? obj)
        {
            return obj is LogResponseDTO dTO &&
                   Id == dTO.Id &&
                   Society == dTO.Society &&
                   Method == dTO.Method &&
                   LibraryClass == dTO.LibraryClass &&
                   Date == dTO.Date &&
                   Message == dTO.Message &&
                   Detail == dTO.Detail &&
                   Comment == dTO.Comment;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Society,Id, Method, LibraryClass, Date, Message, Detail, Comment);
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(base.MemberwiseClone());
        }

    }


}
