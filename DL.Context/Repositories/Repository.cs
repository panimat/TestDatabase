using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DL.Context.Context;
using DL.Context.Interfaces;
using System.Linq.Expressions;

namespace DL.Context.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected AppDbContext _dbContext;
        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(T item)
        {
            await _dbContext.Set<T>().AddAsync(item);
        }

        public void Delete(T item)
        {
            T existing = _dbContext.Set<T>().Find(item);

            if (existing != null)
                _dbContext.Set<T>().Remove(existing);
        }

        public void DeleteAllData()
        {
            _dbContext.Set<T>().Clear<T>();
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate).ToList<T>();
        }

        public T Get(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList<T>();
        }

        public void Update(T item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            _dbContext.Set<T>().Attach(item);
        }
    }
}
