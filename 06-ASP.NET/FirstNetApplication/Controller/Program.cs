var builder = WebApplication.CreateBuilder(args);

//register all controller
builder.Services.AddControllers();

var app = builder.Build();

/*
app.UseRouting();
app.UseEndpoints(endPoints =>
{
    //endPoints("url1,actionMethod); instead write each endpoint use app.MapControllers();
    app.MapControllers();
});
Or USe */
app.MapControllers();

app.Run();
