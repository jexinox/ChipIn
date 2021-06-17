using ChipIn.Models.Helpers;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.Collections.Generic;

namespace ChipIn.Models
{
    public class Group
    {
        [BsonId]
        public ObjectId Id { get; private set; }

        public string Name { get; private set; }

        public List<User> Users { get; private set; }

        public List<UserPreference> UsersPreferences { get; private set; }

        public List<Item> GroupItems { get; private set; }

        public User Creator { get; private set; }

        public Group(string name, string creatorId)
        {
            Name = name;
            Creator = new User(creatorId);
            Users = new List<User> { Creator };
            GroupItems = new List<Item>();
            UsersPreferences = new List<UserPreference>();
        }
    }
}
