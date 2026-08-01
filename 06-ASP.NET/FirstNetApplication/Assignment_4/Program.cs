using Assignment_4.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<AccessRestrictionMiddleware>();

var app = builder.Build();

app.UseRequestTimeMiddleware();
app.UseAccessRestrictionMiddleware();

app.Run();
