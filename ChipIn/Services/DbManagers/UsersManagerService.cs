using MongoDB.Driver;
using ChipIn.Models;
using System.Threading.Tasks;
using ChipIn.Services.DbManagers.ServicesInterfaces;

namespace ChipIn.Services.DbManagers
{
    public class UsersManagerService
    {
        private IMongoCollection<User> collection;

        public UsersManagerService(IDatabaseConnectionService dbConnectionService, string usersCollectionName)
        {;
            var collection = dbConnectionService.Database.GetCollection<User>(usersCollectionName);

            if (collection == null)
            {
                dbConnectionService.Database.CreateCollection("Users");
            }

            this.collection = dbConnectionService.Database.GetCollection<User>(usersCollectionName);
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            try
            {
                await collection.InsertOneAsync(user);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
