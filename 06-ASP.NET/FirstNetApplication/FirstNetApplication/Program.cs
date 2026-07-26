using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

/*
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
    await httpContext.Response.WriteAsync($"method is {method} and url is {url} \n");

    //User Agent
    if (httpContext.Request.Headers.ContainsKey("user-agent"))
    {
        userAgent = httpContext.Request.Headers["user-agent"];
    }
    userAgent = userAgent ?? "user agent does not exits";
    await httpContext.Response.WriteAsync($"userAgent is {userAgent}");
});
*/

/*
//Post Method
app.MapPost("/employees/add-employee", async (HttpContext httpContext) =>
{
    using (StreamReader stream = new StreamReader(httpContext.Request.Body))
    {
        var body = await stream.ReadToEndAsync();
        var response = JsonSerializer.Deserialize<Employee>(body);
        await httpContext.Response.WriteAsync($"Name is {response?.name} Age is {response?.age}");
    }

});
*/



//MiddleWare
app.Use(async (httpContext, next) =>
{
    await httpContext.Response.WriteAsync("First MiddleWare \t");
    await next(httpContext); //call next middleware

    await httpContext.Response.WriteAsync("\n After Mid 1");
});

app.Use(async (httpContext, next) =>
{
    await httpContext.Response.WriteAsync("Second MiddleWare \t");
    await next(httpContext); //call next middleware

    await httpContext.Response.WriteAsync("\n After Mid 2");
});

app.Use(async (HttpContext httpContext, RequestDelegate next) =>
{
    await httpContext.Response.WriteAsync("Third MiddleWare");

    await httpContext.Response.WriteAsync("\n After Mid 3");
});
app.Run();

public class Employee
{
    public string name { set; get; }
    public int age { set; get; }
}