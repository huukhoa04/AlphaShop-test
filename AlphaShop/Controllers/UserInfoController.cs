using Microsoft.AspNetCore.Mvc;

namespace AlphaShop.Controllers
{
    public class UserInfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
