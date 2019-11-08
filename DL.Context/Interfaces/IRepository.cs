using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

namespace DL.Context.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        Task Create(T item);
        void Update(T item);
        void Delete(int id);
        double FindByJson(string _findVal);
        double FindByString(string _findVal);
        int Count();
    }
}
