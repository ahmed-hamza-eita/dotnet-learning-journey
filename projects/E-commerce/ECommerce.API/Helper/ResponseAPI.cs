namespace ECommerce.API.Helper
{
    public class ResponseAPI
    {
        public int StatusCode { set; get; }
        public string? Message { set; get; }
        public Object? Data { set; get; }
        private string GetMessageFromStatusCode(int statusCode)
        {
            return statusCode switch
            {
                200 => "Success",
                201 => "Created successfully",
                204 => "No content",
                400 => "Bad request",
                401 => "Unauthorized",
                403 => "Forbidden",
                404 => "Resource not found",
                409 => "Conflict",
                500 => "Server error",
                _ => "Unknown status"
            };
        }
        public ResponseAPI(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetMessageFromStatusCode(statusCode);
        }

    }
}
