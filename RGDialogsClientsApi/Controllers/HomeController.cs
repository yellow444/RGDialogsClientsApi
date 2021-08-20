using Microsoft.AspNetCore.Mvc;

namespace RGDialogsClientsApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }
}
