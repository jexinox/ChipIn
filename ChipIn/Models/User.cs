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
        public string Id { get; private set; }

        public User(string id)
        {
            Id = id;
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            return (obj as User).Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
