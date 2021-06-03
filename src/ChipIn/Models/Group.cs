using ChipIn.Models.Helpers;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChipIn.Models
{
    public class Group
    {
        public ObjectId Id { get; private set; }

        public string Name { get; private set; }

        public HashSet<User> Users { get; private set; }

        public Dictionary<string, HashSet<UserPreference>> UsersPreferences { get; private set; }

        public HashSet<Food> Food { get; private set; }

        public User Creator { get; private set; }

        public Group(string name, string creatorId)
        {
            Name = name;
            Creator = new User(creatorId);
            Users = new HashSet<User> { Creator };
        }

    }
}
