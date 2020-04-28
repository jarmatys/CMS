using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Infrastructure.Helpers;
using CMS.Models.Db.Account;
using CMS.Models.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // [ GET ] - <domain>/Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // [ POST ] - <domain>/Account/Register
        [HttpPost]
        public async Task<IActionResult> Register(RegisterView result)
        {
            if (ModelState.IsValid)
            {
                var user = new User() { Email = result.Email, UserName = result.Login };
                var register = await _userManager.CreateAsync(user, result.Password);

                if (register.Succeeded)
                {
                    // rejestracja nowego użytkownika
                    await _signInManager.SignInAsync(user, false);
                    // nadanie mu roli "user"
                    // await _userManager.AddToRoleAsync(user, "user");

                    return RedirectToAction("List", "Account");
                }

                foreach (var error in register.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(result);
        }

        // [ GET ] - <domain>/Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        // [ POST ] - <domain>/Account/Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginView result)
        {
            if (ModelState.IsValid)
            {
                var login = await _signInManager.PasswordSignInAsync(result.Login, result.Password, false, false);

                if (login.Succeeded)
                    return RedirectToAction("Index", "Admin");

                ModelState.AddModelError("", "Nieprawidłowa próba logowania!");
            }

            return View(result);
        }

        // [ GET ] - <domain>/Account/Logout
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        // [ GET ] - <domain>/Account/List
        [HttpGet]
        public async Task<IActionResult> List()
        {
            // ZAPYTAĆ jak pobrać includem artykuły tego usera jak menadżer jest już gotowy (?)
            var users = await _userManager.Users.ToListAsync();
            return View(users);
        }

        // [ GET ] - <domain>/Account/Edit
        [HttpGet]
        public async Task<IActionResult> Edit(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            return View(AccountHelpers.ConvertToView(user));
        }

        // [ POST ] - <domain>/Account/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(UserView result)
        {
            if (!ModelState.IsValid)
            {
                return View(result);
            }

            var user = await _userManager.FindByIdAsync(result.Id);
            await _userManager.UpdateAsync(AccountHelpers.MergeViewWithModel(user, result));

            return RedirectToAction("List", "Account");
        }

        // [ POST ] - <domain>/Page/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            await _userManager.DeleteAsync(user);
            return RedirectToAction("List", "Page");
        }

    }
}