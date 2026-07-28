namespace FirstNetApplication.Middlewares
{
    public class HeaderValidatorConventionalMiddleware
    {
        private readonly RequestDelegate _next;
        public HeaderValidatorConventionalMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            const string ValidToken = "MySecretToken123";

            if (!context.Request.Headers.TryGetValue("X-Auth-Token", out var token) || token != ValidToken)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Invalid or missing authentication token.");
                return;
            }
            await _next(context);
        }
    }
    public static class HeaderValidatorConventionalExtension
    {
        public static IApplicationBuilder UseHeaderValidatorConventional(this IApplicationBuilder app)
        {
            return app.UseMiddleware<HeaderValidatorConventionalMiddleware>();
        }
    }
}
