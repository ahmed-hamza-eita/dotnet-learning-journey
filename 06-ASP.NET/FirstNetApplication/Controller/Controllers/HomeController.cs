using Microsoft.AspNetCore.Mvc;


public class HomeController(IHttpContextAccessor httpContextAccessor) : Controller
{
    [Route("home/index")]
    [Route("/")] //default route
    public string Index()
    {

        return "Hello world!";
    }

    [Route("home/about/{id:int}")]
    public ContentResult About()
    {
        var id = httpContextAccessor.HttpContext!.Request.RouteValues["id"]?.ToString();
        //return new ContentResult
        //{
        //    Content = $"About page for id: {id}",
        //    ContentType = "text/html"
        //};
        return Content($"About page for id: {id}", "text/html");
    }

    [Route("person-info")]
    public JsonResult GetPersonInfo()
    {
        var student = new Person { Id = 101, Name = "Ahmed Hamza" };

        return Json(student);
    }
}

