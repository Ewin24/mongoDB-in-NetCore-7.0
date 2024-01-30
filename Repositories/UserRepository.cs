using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using mongotest.Entities;
using mongotest.Interfaces;

namespace mongotest.Repositories.Base
{
    public class UserRepository : BaseRepository<User>, IRepositoryUser
    {
        public UserRepository(
            IMongoClient mongoClient,
            IClientSessionHandle clientSessionHandle) : base(mongoClient, clientSessionHandle, "user")
        {
        }

        public async Task<User> GetUserAsync(string id)
        {
            var filter = Builders<User>.Filter.Eq(f => f.Id, id);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetUsersAsync() =>
            await Collection.AsQueryable().ToListAsync();
    }
}