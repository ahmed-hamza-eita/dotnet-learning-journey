namespace ECommerce.API.Helper
{
    public class ApiExceptions : ResponseAPI
    {
        public string Details { set; get; }
        public ApiExceptions(int statusCode, string? message = null, string details = null) : base(statusCode, message)
        {
            Details = details;
        }
    }
}
