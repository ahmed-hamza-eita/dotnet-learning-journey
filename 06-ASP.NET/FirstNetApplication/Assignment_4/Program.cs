using Assignment_4.Middlewares;
using Assignment_4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddTransient<AccessRestrictionMiddleware>();

//handel Case sensitive
var jsonOptions = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true
};
builder.Services.AddSingleton(jsonOptions);

var app = builder.Build();

/*
app.UseRequestTimeMiddleware();
app.UseAccessRestrictionMiddleware();
*/

var loadCourses = LoadCourses();

app.UseRouting();
app.UseEndpoints(endPoint =>
{
    endPoint.MapGet("/", () => Results.Ok("Welcome to the Best Courses"));

    endPoint.MapGet("/courses", () => Results.Json(loadCourses));

    endPoint.MapGet("/course/{courseId:int}", async (HttpContext context) =>
    {
        var id = int.Parse(context.Request.RouteValues["courseId"].ToString());

        var course = loadCourses.FirstOrDefault(c => c.Id == id);

        return course is not null
        ? Results.Ok(course)
        : Results.NotFound($"Course with id {id} not found");
    });

    endPoint.MapPost("/course", async (HttpContext context) =>
    {
        //read body
        using var reader = new StreamReader(context.Request.Body);
        var body = await reader.ReadToEndAsync();

        //convert body to course type
        var newCourse = JsonSerializer.Deserialize<Course>(body, jsonOptions);

        //validation
        if (newCourse is null || (loadCourses.Any(c => c.Id == newCourse.Id)))
        {
            return Results.BadRequest("Invalid input or course already exists");
        }
        //Add new course 
        loadCourses.Add(newCourse);
        return Results.Created($"/courses/{newCourse.Id}", newCourse);
    });

    endPoint.MapGet("courses/course-fee/{courseId:Int}", async (HttpContext context) =>
    {
        var id = int.Parse(context.Request.RouteValues["courseId"].ToString());

        //if course not found
        var checkCourseExistence = loadCourses.FirstOrDefault(c => c.Id == id);
        if (checkCourseExistence is null)
        {
            return Results.NotFound($"Course with id {id} not found");
        }

        //read discount query parameter
        var discountQuery = context.Request.Query["discount"];
        if (!(int.TryParse(discountQuery, out int disount) && disount >= 0 && disount <= 100))
        {
            return Results.BadRequest("Invalid discount value");
        }

        //Apply discount
        decimal discountFee = checkCourseExistence.Fee * (1 - disount * 100);
        return Results.Ok(new
        {
            checkCourseExistence.Id,
            checkCourseExistence.Name,
            OriginalFee = checkCourseExistence.Fee,
            FeeAfterDicsount = discountFee
        });
    });

});



app.Run();


//Sample Data
List<Course> LoadCourses()
{
    return new List<Course> {
            new() {Id=101, Name ="C# for Beginners" , Fee = 250 , Duration="8 Weeks"},
            new() {Id=102, Name ="ASP.NET Core Fundamentals" , Fee = 300 , Duration="10 Weeks"},
            new() {Id=103, Name ="Entity Framework Core" , Fee = 200 , Duration="6 Weeks"}
    };

}

