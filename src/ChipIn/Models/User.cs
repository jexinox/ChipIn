using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChipIn.Models
{
    public class User
    {
        [BsonId]
        public string Id;

        public User(string Id)
        {
            this.Id = Id;
        }
    }
}
