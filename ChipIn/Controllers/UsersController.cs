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

        public async Task<bool> CreateUserAsync(string id)
        {
            return await usersManager.CreateUserAsync(new User(id));
        }
    }
}
