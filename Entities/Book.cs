using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace mongotest.Entities.Base
{
    public class Book
    {
        public Book(string name, int year) =>
           (Name, Year) = (name, year);

        [BsonElement("name")]
        public string Name { get; }

        [BsonElement("year")]
        public int Year { get; }
    }
}