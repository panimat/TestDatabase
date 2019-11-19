using System;
using System.Collections.Generic;
using System.Text;
using DL.Context.Entities;

namespace DL.Context.Interfaces
{
    public interface IJsonEntityRepository : IRepository<JsonEntity>
    {
        IEnumerable<double> FindByJson(string _findVal);
        IEnumerable<double> FindByString(string _findVal);
        IEnumerable<double> FindByJsonEntity(string _findVal);
        IEnumerable<double> FindByJsonB(string _findVal);
        IEnumerable<JsonEntity> Find(Func<JsonEntity, bool> predicate);
        int Count();
        int GetLastIndex();
    }
}
