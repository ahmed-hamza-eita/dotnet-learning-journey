var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async (HttpContext httpContext) =>
{
    if (httpContext.Request.Method == "GETt")
    {
        httpContext.Response.StatusCode = 200;
        await httpContext.Response.WriteAsync("My Response");
    }
    else
    {
        httpContext.Response.StatusCode = 401;
        await httpContext.Response.WriteAsync("Error \n");
    }

    string method = httpContext.Request.Method;
    string url = httpContext.Request.Path;
    string? userAgent = null;
    await httpContext.Response.WriteAsync($"method is {method} and url is {url}");

    //User Agent
    if (httpContext.Request.Headers.ContainsKey("user-agent"))
    {
        userAgent = httpContext.Request.Headers["user-agent"];
    }
    userAgent = userAgent ?? "user agent does not exits";
    await httpContext.Response.WriteAsync($"userAgent is {userAgent}");
});

app.Run();
