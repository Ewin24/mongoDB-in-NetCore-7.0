using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using mongotest.Entities.Base;
using mongotest.Interfaces;

namespace mongotest.Repositories.Base
{
    public class AuthorRepository : BaseRepository<Author>, IRepositoryAuthor
    {
        public AuthorRepository(
            IMongoClient mongoClient,
            IClientSessionHandle clientSessionHandle) : base(mongoClient, clientSessionHandle, "author")
        {
        }

        public async Task<Author> GetAuthorByIdAsync(string id)
        {
            var filter = Builders<Author>.Filter.Eq(s => s.Id, id);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync() =>
            await Collection.AsQueryable().ToListAsync();

        public async Task<IEnumerable<Book>> GetBooksAsync(string authorId)
        {
            var filter = Builders<Author>.Filter.Eq(s => s.Id, authorId);
            return await Collection.Find(filter).Project(p => p.Books).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Author>> GetAuthorsByNameAsync(string name)
        {
            var filter = Builders<Author>.Filter.Eq(s => s.Name, name);
            return await Collection.Find(filter).ToListAsync();
        }
    }
}