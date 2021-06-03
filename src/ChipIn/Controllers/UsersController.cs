using ChipIn.Models;
using ChipIn.Services.DbManagers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace ChipIn.Controllers
{

    public class UsersController : Controller
    {
        private UsersManagerService usersManager;
        
        public UsersController(UsersManagerService usersManager)
        {
            this.usersManager = usersManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<string> CreateUserAsync(string id)
        {
            var newUser = new User(id);

            if (await usersManager.CreateUserAsync(newUser))
            {
                return "Success!";
            }

            return "Oh, something went wrong!";
        }
    }
}
