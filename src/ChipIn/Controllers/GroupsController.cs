using ChipIn.Services.DbManagers;
using Microsoft.AspNetCore.Mvc;
using ChipIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChipIn.Controllers
{
    public class GroupsController : Controller
    {
        private GroupsManagerService groupsManager;

        public GroupsController(GroupsManagerService groupsManager)
        {
            this.groupsManager = groupsManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<string> CreateGroupAsync(string name, string creatorId)
        {
            var newGroup = new Group(name, creatorId);
            if (await groupsManager.CreateGroupAsync(newGroup))
            {
                return "Success!";
            }
            return "Oops, something went wrong!";
        }
    }
}
