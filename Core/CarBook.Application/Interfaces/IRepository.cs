using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    public  interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T Entity);
       
    }
}
