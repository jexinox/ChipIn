using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChipIn.Services.DbManagers.ServicesInterfaces
{
    public interface IDatabaseConnectionService
    {
        public IMongoDatabase Database { get; }
    }
}
