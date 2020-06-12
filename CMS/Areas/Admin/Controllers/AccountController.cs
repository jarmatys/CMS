using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CMS.Areas.Admin.Models.Db.Account;
using CMS.Areas.Admin.Models.View.Account;
using CMS.Infrastructure.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS.Controllers
{
    [Area("admin")]
    [Route("admin/{controller}/{action=login}")]
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
                    // await _signInManager.SignInAsync(user, false);
                    // nadanie mu roli "user"
                    // await _userManager.AddToRoleAsync(user, "user");

                    return RedirectToAction("List", "Account", new { Area = "Admin" });
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
                return RedirectToAction("Index", "Home", new { Area = "Admin" });
            }
            return View();
        }


        // [ POST ] - <domain>/Account/Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginView result)
        {
            if (ModelState.IsValid)
            {
                var login = await _signInManager.PasswordSignInAsync(result.Login, result.Password, result.RemberMe, false);

                if (login.Succeeded)
                    return RedirectToAction("Index", "Home", new { Area = "Admin" });

                ModelState.AddModelError("", "Nieprawidłowa próba logowania!");
            }

            return View(result);
        }

        // [ GET ] - <domain>/Account/Logout
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { Area = "Home" });
        }

        // [ GET ] - <domain>/Account/List
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var users = await _userManager.Users.Include(u => u.Articles).ToListAsync();
            return View(users);
        }

        // [ GET ] - <domain>/Account/Edit
        [HttpGet]
        public async Task<IActionResult> Edit(string Id)
        {
            User user = null;
            if (string.IsNullOrEmpty(Id))
            {
                user = await _userManager.GetUserAsync(HttpContext.User);
            }
            else
            {
                user = await _userManager.FindByIdAsync(Id);
            }
            return View(AccountHelpers.ConvertToView(user));
        }

        // [ GET ] - <domain>/Account/ChangePassword
        [HttpGet]
        public async Task<IActionResult> ChangePassword(string Id)
        {
            var changePassword = new ChangePasswordView();

            if (string.IsNullOrEmpty(Id))
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                changePassword.Id = user.Id;
            }
            else
            {
                changePassword.Id = Id;
            }

            return View(changePassword);
        }

        // [ POST ] - <domain>/Account/ChangePassword
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordView result)
        {
            if (!ModelState.IsValid)
            {
                return View(result);
            }

            var user = await _userManager.FindByIdAsync(result.Id);
            if (user == null)
            {
                ModelState.AddModelError("", "Nie odnaleziono takiego użytkownika.");
            }

            var checkCurrentPassword = await _userManager.CheckPasswordAsync(user, result.CurrentPassword);
            if (!checkCurrentPassword)
            {
                ModelState.AddModelError("", "Podane aktualne hasło nie jest zgodne");
                return View(result);
            }

            var newPassword = _userManager.PasswordHasher.HashPassword(user, result.Password);
            user.PasswordHash = newPassword;
            var res = await _userManager.UpdateAsync(user);

            if (res.Succeeded)
            {
                return RedirectToAction("List", "Account", new { Area = "Admin" });
            }
            else
            {
                ModelState.AddModelError("", "Problem z zapisem nowego hasła.");
            }

            return View(result);

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

            return RedirectToAction("List", "Account", new { Area = "Admin" });
        }

        // [ POST ] - <domain>/Account/Delete
        [HttpPost]
        public async Task<IActionResult> Delete(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            await _userManager.DeleteAsync(user);
            return RedirectToAction("List", "Account", new { Area = "Admin" });
        }

    }
}