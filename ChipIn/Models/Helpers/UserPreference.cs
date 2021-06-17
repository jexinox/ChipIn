using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChipIn.Models.Helpers
{
    public class UserPreference
    {
        public User User { get; private set; }
        public Item Item { get; private set; }
        public double? Volume { get; private set; }

        public UserPreference(User user, Item item, double? preferenceVolume)
        {
            User = user;
            Item = item;
            Volume = preferenceVolume;
        }
    }
}
