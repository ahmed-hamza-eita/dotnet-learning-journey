using Microsoft.AspNetCore.Http.HttpResults;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string ValidToken = "MySecretToken123";
var blacklistedIps = new List<string> { "192.168.1.100", "10.0.0.5" };


app.Use(async (context, next) =>
{
    if (!context.Request.Headers.TryGetValue("X-Auth-Token", out var token) || token != ValidToken)
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        await context.Response.WriteAsync("Invalid or missing authentication token.");
        return;
    }
    await next(context);
});

app.Use(async (context, next) =>
{
    if (context.Request.Path.StartsWithSegments("/calculate"))
    {
        var num1Str = context.Request.Query["num1"];
        var num2Str = context.Request.Query["num2"];
        var op = context.Request.Query["op"];

        if (!double.TryParse(num1Str, out double num1) ||
        !double.TryParse(num2Str, out double num2) ||
        string.IsNullOrEmpty(op))
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsync("Invalid or missing num1, num2, or op query parameters.");
            return;
        }
        double result;
        switch (op.ToString())
        {
            case "+": result = num1 + num2; break;
            case "-": result = num1 - num2; break;
            case "*": result = num1 * num2; break;
            case "/":
                if (num2 == 0)
                {
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync("Cannot divide by zero.");
                    return;
                }
                result = num1 / num2;
                break;

            default:
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Invalid operation. Supported: + - * /");
                return;
        }
        context.Response.Headers.Append("X-Calculation-Result", result.ToString());
        await context.Response.WriteAsync($"Result: {result}");
        return;
    }

    await next(context);
});

app.Use(async (context, next) =>
{
    var stopwatch = Stopwatch.StartNew();
    context.Response.OnStarting(() =>
    {
        stopwatch.Stop();
        context.Response.Headers.Append("X-Processing-Time", $"{stopwatch.ElapsedMilliseconds}ms");
        return Task.CompletedTask;
    });

    await next(context);
});


app.Use(async (context, next) =>
{
    var remoteIp = context.Connection.RemoteIpAddress?.ToString();
    if (remoteIp is not null && blacklistedIps.Contains(remoteIp))
    {
        context.Response.StatusCode = StatusCodes.Status403Forbidden;
        await context.Response.WriteAsync("Access denied from this IP address.");
        return;
    }
    await next(context);
});
app.Run();
