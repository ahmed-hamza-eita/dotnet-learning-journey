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

    //// How to access parameters.
    endpoints.MapGet("products/{id=5}", async context =>
    {
        // way 1
        //var routeData = context.GetRouteData();
        //var id = Convert.ToInt32(routeData.Values["id"]);

        //way 2
        var id = Convert.ToInt32(context.Request.RouteValues["id"]);


        await context.Response.WriteAsync($"get products with id {id}");
    });

    endpoints.MapGet("users/{userId}/posts/{postName=hamza}", async context =>
    {
        var id = Convert.ToInt32(context.Request.RouteValues["userId"]);
        var postName = Convert.ToString(context.Request.RouteValues["postName"]);

        await context.Response.WriteAsync($"user Id: {id} \t Post Name: {postName}");
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync("Default Routing");
});

app.Run();
