using ChipIn.Models;
using ChipIn.Services.DbManagers.ServicesInterfaces;
using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChipIn.Models.Helpers;

namespace ChipIn.Services.DbManagers
{
    public class GroupsManagerService
    {
        private IMongoCollection<Group> collection;

        public GroupsManagerService(IDatabaseConnectionService dbConnectionService, string usersCollectionName)
        {
            var collection = dbConnectionService.Database.GetCollection<Group>(usersCollectionName);

            if (collection == null)
            {
                dbConnectionService.Database.CreateCollection("Groups");
            }

            this.collection = dbConnectionService.Database.GetCollection<Group>(usersCollectionName);
        }

        public async Task<bool> CreateGroupAsync(Group group)
        {
            try
            {
                await collection.InsertOneAsync(group);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Group> GetGroupAsync(string groupId)
        {
            try
            {
                var group = await collection.FindAsync(gr => gr.Id == ObjectId.Parse(groupId));
                return group.Single();
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> AddUserAsync(string groupId, User user)
        {
            try
            {
                var groupUsersUpdate = Builders<Group>.Update.AddToSet(gr => gr.Users, user);
                var result = await collection.UpdateOneAsync(gr => gr.Id == ObjectId.Parse(groupId), groupUsersUpdate);
                return result.IsAcknowledged;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> AddItemAsync(string groupId, Item item)
        {
            try
            {
                var itemUpdate = Builders<Group>.Update.AddToSet(gr => gr.GroupItems, item);
                var result = await collection.UpdateOneAsync(gr => gr.Id == ObjectId.Parse(groupId), itemUpdate);
                return result.IsAcknowledged ;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Item> GetItemAsync(string groupId, string itemId)
        {
            try
            {
                var group = await collection.FindAsync(gr => gr.Id == ObjectId.Parse(groupId));
                return group
                    .SingleOrDefault()
                    .GroupItems
                    .Where(it => it.Id == ObjectId.Parse(itemId))
                    .SingleOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> AddPreferenceAsync(string groupId, UserPreference preference)
        {
            try
            {
                var preferenceUpdate = Builders<Group>.Update.AddToSet(gr => gr.UsersPreferences, preference);
                var result = await collection.UpdateOneAsync(gr => gr.Id == ObjectId.Parse(groupId), preferenceUpdate);
                return result.IsAcknowledged;
            }
            catch
            {
                return false;
            }
        }

        public async Task<UserPreference> GetPreferenceAsync(string groupId, string userId, string itemId)
        {
            try
            {
                var group = await collection.FindAsync(gr => gr.Id == ObjectId.Parse(groupId));
                return group
                    .SingleOrDefault()
                    .UsersPreferences
                    .Where(pref => pref.User.Id == userId && pref.Item.Id == ObjectId.Parse(itemId))
                    .SingleOrDefault();
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeletePreferenceAsync(string groupId, UserPreference preference)
        {
            try
            {
                var preferenceUpdate = Builders<Group>.Update.Pull(gr => gr.UsersPreferences, preference);
                var result = await collection.UpdateOneAsync(gr => gr.Id == ObjectId.Parse(groupId), preferenceUpdate);
                return result.IsAcknowledged;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteItemAsync(string groupId, Item item)
        {
            try
            {
                var itemUpdate = Builders<Group>.Update.Pull(gr => gr.GroupItems, item);
                var result = await collection.UpdateOneAsync(gr => gr.Id == ObjectId.Parse(groupId), itemUpdate);
                return result.IsAcknowledged;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteGroupAsync(string groupId)
        {
            try
            {
                var result = await collection.DeleteOneAsync(gr => gr.Id == ObjectId.Parse(groupId));
                return result.IsAcknowledged;
            }
            catch
            {
                return false;
            }
        }
    }
}
