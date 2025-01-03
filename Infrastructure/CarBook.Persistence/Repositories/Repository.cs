using CarBook.Application.Interfaces;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CarBookContext _context;

        public Repository(CarBookContext context)
        {
            _context = context;
        }


        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();    
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await  _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdsync(int id)
        {
           return await _context.Set<T>().FindAsync(id);
        }

        public void Remove(T Entity)
        {
           _context.Set<T>().Remove(Entity); 
           _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
