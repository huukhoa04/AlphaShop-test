using Microsoft.AspNetCore.Mvc;

namespace AlphaShop.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DrinkInfo()
        {
            return View();
        }
    }
}
