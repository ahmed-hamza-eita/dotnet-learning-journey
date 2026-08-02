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
        public string About()
        {
            var id = httpContextAccessor.HttpContext!.Request.RouteValues["id"]?.ToString();
            return $"About page for id: {id}";
        }
    }
}
