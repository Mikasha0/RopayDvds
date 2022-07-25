using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RopayDvd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RopayDvd.Controllers
{
    public class HomeController : Controller
    {
        private RopayDatabaseContext ctx;
        public HomeController(RopayDatabaseContext ctx)
        {
            this.ctx = ctx;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            RopayUser user = ctx.RopayUsers.Where(u => u.UserName.ToUpper().Equals(login.LoginId.ToUpper()) && u.UserPassword.Equals(login.LoginCode)).FirstOrDefault();
            if(user!=null)//if user exists then login is successful
            {
                var claims =new List<Claim>{
                    new Claim(ClaimTypes.NameIdentifier,user.UserNumber.ToString()),
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(ClaimTypes.Role,user.UserType)
                };
                ClaimsIdentity identity = new ClaimsIdentity(claims, "login");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(identity));
                return RedirectToAction(nameof(Index));
            }
            return View(login);
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Index));
        }
    }
}
