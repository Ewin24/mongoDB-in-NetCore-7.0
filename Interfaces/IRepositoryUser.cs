using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mongotest.Entities;

namespace mongotest.Interfaces
{
    public interface IRepositoryUser : IRepositoryBase<User>
    {
        Task<IEnumerable<User>> GetUsersAsync();

        Task<User> GetUserAsync(string id);
    }
}