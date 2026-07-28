namespace FirstNetApplication.Middlewares
{
    public class HeaderValidatorMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            const string ValidToken = "MySecretToken123";

            if (!context.Request.Headers.TryGetValue("X-Auth-Token", out var token) || token != ValidToken)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Invalid or missing authentication token.");
                return;
            }
            await next(context);
        }
    }
    public static class HeaderValidatorExtension
    {
        public static IApplicationBuilder UseHeaderValidator(this IApplicationBuilder app)
        {
            return app.UseMiddleware<HeaderValidatorMiddleware>();
        }
    }
}
