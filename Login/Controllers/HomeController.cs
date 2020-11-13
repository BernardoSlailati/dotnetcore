using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Login.Models;
using Microsoft.AspNetCore.Identity;

namespace Login.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signinManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signinManager = signinManager;
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(ApplicationUser model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user != null)
            {
                var SignIn = await _signinManager.PasswordSignInAsync(user, model.Password, false, false);
                if (SignIn.Succeeded) {
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(ApplicationUser model)
        {
            var user = new ApplicationUser {
                Id="1001",
                UserName=model.UserName,
                Email=model.Email,
                FirstName=model.FirstName,
                LastName=model.LastName,
                Password=model.Password
            };
            var result = await _userManager.CreateAsync(user, user.Password);
            if (result.Succeeded) {
                var SignIn = await _signinManager.PasswordSignInAsync(user, user.Password, false, false);
                if (SignIn.Succeeded) {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }


        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
