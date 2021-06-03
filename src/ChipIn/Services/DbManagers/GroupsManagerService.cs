using ChipIn.Models;
using ChipIn.Services.DbManagers.ServicesInterfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            this.collection = collection;
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
    }
}
