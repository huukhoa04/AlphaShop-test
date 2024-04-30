using Microsoft.AspNetCore.Mvc;

namespace AlphaShop.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
