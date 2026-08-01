using System.Diagnostics;


namespace Assignment_4.Middlewares
{
    public class RequestTimeMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestTimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var stopWatch = Stopwatch.StartNew();

            await _next(context);

            stopWatch.Stop();

            var path = $"Method: {context.Request.Method}" +
                $" Path: {context.Request.Path}" +
                $" take time: {stopWatch.ElapsedMilliseconds}";
            context.Response.WriteAsync(path);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RequestTimeMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestTimeMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestTimeMiddleware>();
        }
    }
}
