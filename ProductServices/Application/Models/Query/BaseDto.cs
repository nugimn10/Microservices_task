namespace ProductServices.Application.Models.Query
{
    public abstract class BaseDto
    {
        public bool Success { set; get; }
        public string Message { set; get; }
        
    }
    public class Auth
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class RequestData<T>
    {
        public Data<T> DataD { get; set; }
    }
    public class Data<T>
    {
        public T Attributes { get; set; }
    }
}