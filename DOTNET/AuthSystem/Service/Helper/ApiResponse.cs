namespace AuthSystem.Service.Helper
{
    public class ApiResponse
    {
        public ApiResponse(object? data, int statusCode, string? message = null)
        {
            Data = data;
            StatusCode = statusCode;
            Message = message;
        }
        public Object? Data { get; set; }
        public int StatusCode { get; set; }
        public string? Message { get; set; }
    }
}