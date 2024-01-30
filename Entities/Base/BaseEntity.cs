using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace mongotest.Entities.Base
{
    public class BaseEntity
    {
        [BsonElement("_id")]
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public virtual string Id { get; private set; }

        public void SetId(string id) =>
            Id = id;
    }
}