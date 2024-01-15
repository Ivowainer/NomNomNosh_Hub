namespace NomNomNosh.API.Config.Response
{
    public class GeneralResponse<T>
    {
        public T? value { get; set; }
        public string message { get; set; }
        public string statusCode { get; set; }
    }
}