using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChipIn.Models.Helpers
{
    public class UserPreference
    {
        public readonly Food Food;
        public int Volume { get; set; }
        public int Cost { get; private set; }
    }
}
