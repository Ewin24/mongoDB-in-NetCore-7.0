using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mongotest.Entities.Base;

namespace mongotest.Interfaces
{
    public interface IRepositoryBase<T> where T : BaseEntity
    {
        Task InsertAsync(T obj);

        Task UpdateAsync(T obj);

        Task DeleteAsync(string id);
    }
}