using AlphaShop.Data;
using AlphaShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlphaShop.Controllers
{
    public class LogController : Controller
    {
        private readonly HahaContext _context;


        public LogController(HahaContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            var taikhoanForm = loginModel.Name;
            var matkhauForm = loginModel.Password;
            var usercheck = _context.Customers.SingleOrDefault(x => x.CtrLogusername == taikhoanForm && x.CtrPassword == matkhauForm);
            if (usercheck != null)
            {
                TempData["Account"] = usercheck;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.LoginFail = "Failed to log";
                return View();
            }
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterModel registerModel)
        {
            var usercheck = _context.Customers.SingleOrDefault(x => x.CtrUsername == registerModel.Username);
            if (usercheck != null)
            {
                ViewBag.RegisterFailed = "Failed to register, username has existed!";
                return View();
            }
            else if (registerModel.Password != registerModel.ConfirmPassword)
            {
                ViewBag.RegisterFailed = "Password is not synced";
                return View();
            }

            _context.Database.ExecuteSqlRawAsync($"set IDENTITY_INSERT dbo.CUSTOMER on;");
            _context.Customers.AddAsync(
                new Customer
                {
                    CtrLogusername = registerModel.LogUsername,
                    CtrUsername = registerModel.Username,
                    CtrPassword = registerModel.Password,
                    CtrEmail = registerModel.Email,
                    CtrPhonenumber = registerModel.PhoneNumber,
                    CtrGender = registerModel.Gender,
                    CtrAccess = 1,
                    CtrId = _context.Customers.Count(),
                    CtrUsed = 0,
                    CtrImage = null
                    

                }
            );
            _context.SaveChanges();
            _context.Database.ExecuteSqlRawAsync($"set IDENTITY_INSERT dbo.CUSTOMER off;");
            _context.Database.BeginTransaction();
            return RedirectToAction("Login");
        }
        public IActionResult Logout()
        {
            TempData["AccountName"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}
