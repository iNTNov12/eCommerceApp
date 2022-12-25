using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace eCommerceApp.Data.Base
{
    public interface IEntityBaseRepository<T> where T: class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllAsync(); // preia toti actorii din db

        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);

        Task<T> GetByIdAsync(int id); // intoarce un sg actor

        Task AddAsync(T entity); // adauga date in db

        Task UpdateAsync(int id, T entity); // updateaza data in bd

        Task DeleteAsync(int id); //sterge data din bd
    }
}
