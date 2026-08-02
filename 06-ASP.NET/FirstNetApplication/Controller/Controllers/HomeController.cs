using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers
{
    public class HomeController(IHttpContextAccessor httpContextAccessor)
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
            return new ContentResult
            {
                Content = $"About page for id: {id}",
                ContentType = "text/html"
            };
        }
    }
}
