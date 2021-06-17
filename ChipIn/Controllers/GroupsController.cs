using ChipIn.Services.DbManagers;
using Microsoft.AspNetCore.Mvc;
using ChipIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ChipIn.Models.Helpers;

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

        public IActionResult AddItem()
        {
            return View();
        }

        public IActionResult CreateGroup()
        {
            return View();
        }

        public IActionResult CountSum()
        {
            return View();
        }

        [HttpPost]
        public async Task<bool> CreateGroupAsync(string name, string creatorId)
        {
            var newGroup = new Group(name, creatorId);
            return await groupsManager.CreateGroupAsync(newGroup);
        }

        [HttpPost]
        public async Task<bool> AddUserAsync(string groupId, string userId)
        {
            return await groupsManager.AddUserAsync(groupId, new User(userId));
        }

        [HttpGet]
        public async Task<string> GetGroupAsync(string groupId)
        {
            return JsonConvert.SerializeObject(await groupsManager.GetGroupAsync(groupId));
        }

        [HttpPost]
        public async Task<bool> AddItemAsync(string groupId, string itemName, double cost, double? volume)
        {
            return await groupsManager.AddItemAsync(groupId, new Item(itemName, cost, volume));
        }

        [HttpGet]
        public async Task<string> GetItemAsync(string groupId, string itemId)
        {
            return JsonConvert.SerializeObject(await groupsManager.GetItemAsync(groupId, itemId));
        }

        [HttpPost]
        public async Task<bool> AddPreferenceAsync(string groupId, string userId, string itemId, double? preferenceVolume)
        {
            var item = await groupsManager.GetItemAsync(groupId, itemId);
            return await groupsManager.AddPreferenceAsync(groupId, new UserPreference(new User(userId), item, preferenceVolume));
        }

        [HttpGet]
        public async Task<string> GetPreferenceAsync(string groupId, string userId, string itemId)
        {
            return JsonConvert.SerializeObject(await groupsManager.GetPreferenceAsync(groupId, userId, itemId));
        }

        [HttpDelete]
        public async Task<bool> DeleteGroupAsync(string groupId)
        {
            return await groupsManager.DeleteGroupAsync(groupId);
        }

        [HttpDelete]
        public async Task<bool> DeleteItemAsync(string groupId, string itemId)
        {
            var item = await groupsManager.GetItemAsync(groupId, itemId);
            return await groupsManager.DeleteItemAsync(groupId, item);
        }

        [HttpDelete]
        public async Task<bool> DeletePreferenceAsync(string groupId, string userId, string itemId)
        {
            var preference = await groupsManager.GetPreferenceAsync(groupId, userId, itemId);
            return await groupsManager.DeletePreferenceAsync(groupId, preference);
        }

        [HttpGet]
        public async Task<string> CountUsersSum(string groupId)
        {
            var group = await groupsManager.GetGroupAsync(groupId);
            var sum = new Dictionary<string, double>();
            var count = new Dictionary<Item, int>();

            foreach (var preference in group.UsersPreferences)
            {
                if (count.ContainsKey(preference.Item))
                {
                    count[preference.Item]++;
                }
                else
                {
                    count[preference.Item] = 1;
                }
            }

            foreach (var preference in group.UsersPreferences)
            {
                if (sum.ContainsKey(preference.User.Id))
                {
                    sum[preference.User.Id] += preference.Volume == null ?
                        preference.Item.Cost / count[preference.Item] :
                        preference.Item.Cost * (double)(preference.Volume / preference.Item.Volume);
                }
                else
                {
                    sum[preference.User.Id] = preference.Volume == null ?
                        preference.Item.Cost / count[preference.Item] :
                        preference.Item.Cost * (double)(preference.Volume / preference.Item.Volume);
                }
            }

            return JsonConvert.SerializeObject(sum);
        }
    }
}
