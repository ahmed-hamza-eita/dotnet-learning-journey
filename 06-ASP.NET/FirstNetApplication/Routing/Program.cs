var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.UseRouting(); //enable routing (select match endpoint)

//excute selected endpoint
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("mapGet1", async context => //url + httpMethod 
    {
        await context.Response.WriteAsync("Map get 1");
    });

    endpoints.MapPost("mapPost1", async context =>
    {
        await context.Response.WriteAsync("Map post 1");
    });

    endpoints.Map("mapMethod", async context =>
    {
        var endPoint = context.GetEndpoint();
        await context.Response.WriteAsync($"Selected end point is: {endPoint.DisplayName}");
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync("Default Routing");
});

app.Run();
