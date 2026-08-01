

namespace Assignment_4.Middlewares
{
    public class AccessRestrictionMiddleware : IMiddleware
    {

        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var currentTime = DateTime.UtcNow.Hour + 2;
            if (currentTime < 9 || currentTime > 17)
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                context.Response.WriteAsync("Access Denied");
                return Task.CompletedTask;
            }
            return next(context);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AccessRestrictionMiddlewareExtensions
    {
        public static IApplicationBuilder UseAccessRestrictionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AccessRestrictionMiddleware>();
        }
    }
}
