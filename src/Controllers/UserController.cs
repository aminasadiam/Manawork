using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Manawork.DTOs.Users;
using Manawork.Services.Interfaces;
using Manawork.Models.User;

namespace Manawork.Controllers
{
    public class UserController : Controller
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (_userService.IsUsernameExist(model.Username))
            {
                ModelState.AddModelError("Username", "Username is Exist, Please Enter other Username.");
                return View(model);
            }

            if (_userService.IsEmailExist(model.Email))
            {
                ModelState.AddModelError("Email", "Email is Exist, Please Enter other Email.");
                return View(model);
            }

            User user = new User()
            {
                Username = model.Username.ToLower(),
                Email = model.Email.ToLower(),
                IsDelete = false,
                Password = model.Password,
                RegisterDate = DateTime.Now
            };

            _userService.AddUser(user);

            return Redirect("/");
        }
    }
}
