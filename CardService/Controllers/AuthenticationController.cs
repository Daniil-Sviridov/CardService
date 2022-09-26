using Microsoft.AspNetCore.Mvc;

namespace CardService.Controllers
{
    public class AuthenticationController : Controller
    {
        public AuthenticationController()
        { 
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
