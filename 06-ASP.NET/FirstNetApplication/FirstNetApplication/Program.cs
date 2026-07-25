var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async (HttpContext httpContext) =>
{
    if (httpContext.Request.Method == "GETt")
    {
        httpContext.Response.StatusCode = 200;
        await httpContext.Response.WriteAsync("My Response");
    }
    else {
        httpContext.Response.StatusCode = 401;
        await httpContext.Response.WriteAsync("Error");
    }
    
});

app.Run();
