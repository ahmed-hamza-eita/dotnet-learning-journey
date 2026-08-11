using ECommerce.API.Helper;
using Microsoft.Extensions.Caching.Memory;
using System.Net;
using System.Text.Json;

namespace ECommerce.API.Middleware
{
    public class ExceptionsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _enviroment;
        private readonly IMemoryCache _memoryCache;
        private readonly TimeSpan _rateLimitWindow = TimeSpan.FromSeconds(30);
        private const int _maxRequestsPerWindow = 8;

        public ExceptionsMiddleware(RequestDelegate next, IHostEnvironment enviroment, IMemoryCache memoryCache)
        {
            _next = next;
            _enviroment = enviroment;
            _memoryCache = memoryCache;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                if (IsRequestAllowed(context) == false)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.TooManyRequests;
                    context.Response.ContentType = "application/json";

                    var response =
                       new ApiExceptions((int)HttpStatusCode.TooManyRequests, "Too many requests. Please try again later.");

                    await context.Response.WriteAsJsonAsync(response);
                    return;
                }

                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var response = _enviroment.IsDevelopment()
                   ? new ApiExceptions((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace)
                   : new ApiExceptions((int)HttpStatusCode.InternalServerError, ex.Message);

                var json = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }

        }
        private bool IsRequestAllowed(HttpContext context)
        {
            var ip = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            var cachKey = $"Rate:{ip}";
            var dateNow = DateTime.UtcNow;

            var (timeSpan, count) = _memoryCache.GetOrCreate(cachKey, entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = _rateLimitWindow;
                return (timeSpan: dateNow, count: 0);
            });
            if (dateNow - timeSpan < _rateLimitWindow)
            {
                if (count >= _maxRequestsPerWindow)
                {
                    return false;
                }
                _memoryCache.Set(cachKey, (timeSpan, count + 1), _rateLimitWindow - (dateNow - timeSpan));
            }
            else
            {
                _memoryCache.Set(cachKey, (timeSpan: dateNow, count: 1), _rateLimitWindow);
            }
            return true;
        }
    }


    public static class ExceptionsMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionsMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionsMiddleware>();
        }
    }
}
