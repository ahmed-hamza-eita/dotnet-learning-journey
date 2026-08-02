using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers
{
    public class HomeController
    {
        [Route("home/index")]
        [Route("/")] //default route
        public string Index()
        {
            return "Hello world!";
        }
    }
}
