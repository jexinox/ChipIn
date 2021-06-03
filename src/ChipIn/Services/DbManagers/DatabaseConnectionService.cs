using ChipIn.Services.DbManagers.ServicesInterfaces;
using MongoDB.Driver;

namespace ChipIn.Services.DbManagers
{
    public class DatabaseConnectionService : IDatabaseConnectionService
    {
        public IMongoDatabase Database { get; private set; }

        public DatabaseConnectionService(string connectionString)
        {
            var connection = new MongoUrlBuilder(connectionString);

            var client = new MongoClient(connectionString);

            Database = client.GetDatabase(connection.DatabaseName);
        }
    }
}
