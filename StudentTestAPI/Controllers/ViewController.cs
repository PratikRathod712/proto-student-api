using Microsoft.AspNetCore.Mvc;

namespace StudentTestAPI.Controllers
{
    public class ViewController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
