using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (HttpContext context) =>
{
    var query = context.Request.Query;

    var id = context.Request.Query["id"];
    var name = context.Request.Query["name"];
    var dept = context.Request.Query["dept"];
    var salary = context.Request.Query["salary"];

    if (!int.TryParse(id, out int employeeId) || employeeId <= 0)
    {
        return Results.BadRequest("Invalid Emp ID");
    }
    if (string.IsNullOrWhiteSpace(name))
    {
        return Results.BadRequest("Name is required.");
    }
    if (string.IsNullOrWhiteSpace(dept))
    {
        return Results.BadRequest("Invalid dept");
    }
    if (!decimal.TryParse(salary, out decimal _salary) || _salary <= 0)
    {
        return Results.BadRequest("Invalid Salary");
    }
    if (_salary < 1000)
    {
        return Results.BadRequest("Salary is too low.");
    }
    return Results.Ok(new
    {
        Id = id,
        Name = name,
        Department = dept,
        Salary = salary
    });
});

app.Run();
