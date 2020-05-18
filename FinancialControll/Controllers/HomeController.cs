using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FinancialControll.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using FinancialControll.Models.ViewModels;
using System.Configuration;
using System.Net.Mail;
using System.Net;
namespace FinancialControll.Controllers
{
    public class HomeController : Controller
    {

        private readonly UserManager<Profile> userManager;
        private readonly IUserClaimsPrincipalFactory<Profile> userClaimsPrincipalFactory;
        private readonly SignInManager<Profile> signInManager;

        public HomeController(UserManager<Profile> _userManager,IUserClaimsPrincipalFactory<Profile> _UserClaimsPrincipalFactory,
            SignInManager<Profile> _signInManager)
        {
            userManager = _userManager;
            userClaimsPrincipalFactory = _UserClaimsPrincipalFactory;
            signInManager = _signInManager;
        }
       

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.UserName);
                var email = await userManager.FindByEmailAsync(model.Email);
                if (user == null && email == null)
                {
                    user = new Profile()
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserName = model.UserName,
                        Name = model.Name,
                        Email = model.Email,
                        Sallary = model.Sallary,
                        BirthDate = model.BirthDate
                    };
                    var Result = await this.userManager.CreateAsync(user, model.Password);
                    return View("Index");
                }
                if (user != null)
                {
                    ModelState.AddModelError("UserInvalido", "Usuário já existe, tente outro nome");
                }
                else
                {
                    ModelState.AddModelError("EmailInvalido", "Email Já está sendo utilizado");
                }
            }
            
            return View("Register");
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login Model)
        {
            if (ModelState.IsValid)
            {
                var user = await this.userManager.FindByNameAsync(Model.UserName);
                if (user != null && await userManager.CheckPasswordAsync(user,Model.Password))
                {
                    var Principal = await userClaimsPrincipalFactory.CreateAsync(user);

                  await HttpContext.SignInAsync("Identity.Application", Principal);
                //var SignIn = await signInManager.PasswordSignInAsync(Model.UserName, Model.Password, false, false);
                //if (SignIn.Succeeded)
                //{
                    return View("About");
                }
                ModelState.AddModelError("Usuario.SenhaInvalido", "Usuário ou senha inválida");
            }
            return View("Login");
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPassword model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);
                    var ResetUrl = Url.Action("ResetPassword","Home",new { token = token, Email = model.Email},Request.Scheme);

                   // await userManager.SendEmailAsync(user.UserName,)
                }
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPassword model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user.Email != null)
                {

                }
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Error(String message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }

    }
}
