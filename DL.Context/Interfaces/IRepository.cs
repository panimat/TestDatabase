using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq.Expressions;

namespace DL.Context.Interfaces
{
    public interface IRepository<T> : IDisposable 
                            where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        Task Create(T item);
        void Update(T item);
        void Delete(T item);
        void DeleteAllData();
        
    }
}
