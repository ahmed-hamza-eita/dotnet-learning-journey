using ECommerce.API.Middleware;
using ECommerce.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//Add CORS
builder.Services.AddCors(op => op.AddPolicy("CORSPolicy", policy
    => policy
        .AllowAnyOrigin()//.WithOrigins("http://localhost:4200") 
        .AllowAnyMethod()
        .AllowAnyHeader()));

builder.Services.AddMemoryCache();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.InfrastructureConfiguration(builder.Configuration);

// Configure AutoMapper 
builder.Services.AddAutoMapper(cfg => { }, typeof(Program).Assembly);

var app = builder.Build();

app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CORSPolicy");
app.UseMiddleware<ExceptionsMiddleware>();

app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
