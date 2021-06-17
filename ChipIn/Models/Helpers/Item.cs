using MongoDB.Bson;
using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ChipIn.Models.Helpers
{
    public class Item
    {
        [BsonId]
        public ObjectId Id { get; private set; }
        public string Name { get; private set; }
        public double? Volume { get; private set; }
        public double Cost { get; private set; }

        public Item(string name, double cost, double? volume)
        {
            Id = ObjectId.GenerateNewId();
            Name = name;
            Volume = volume;
            Cost = cost;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var item = obj as Item;
            return item.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
