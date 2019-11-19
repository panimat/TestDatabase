using System;
using System.Collections.Generic;
using System.Linq;
using DL.Context.Entities;
using DL.Context.Interfaces;
using DL.Context.Context;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace DL.Context.Repositories
{
    public class JsonEntitiRepository : Repository<JsonEntity>, IJsonEntityRepository
    {
        public JsonEntitiRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<JsonEntity> Find(Func<JsonEntity, bool> predicate)
        {
            return _dbContext.JsonEntities.Where(predicate).ToList();
        }

        public IEnumerable<double> FindByJson(string _findVal)
        {
            var listTime = new List<double>();

            for (int i = 0; i < 10; i++)
            {
                Stopwatch sw = Stopwatch.StartNew();
            var val = _dbContext.JsonEntities.Where(x => x.JsonValField.Value == _findVal).FirstOrDefault();
            sw.Stop();

                if (val != null)
                    listTime.Add(sw.Elapsed.TotalMilliseconds);
            }

            return listTime;
        }

        public IEnumerable<double> FindByString(string _findVal)
        {
            var listTime = new List<double>();

            for (int i = 0; i < 10; i++)
            {
                Stopwatch sw = Stopwatch.StartNew();
                var val = _dbContext.JsonEntities.Where(x => x.StringField == _findVal).FirstOrDefault();
                sw.Stop();

                if (val != null)
                    listTime.Add(sw.Elapsed.TotalMilliseconds);
            }

            return listTime;
        }

        public IEnumerable<double> FindByJsonEntity(string _findVal)
        {
            var listTime = new List<double>();

            for (int i = 0; i < 10; i++)
            {
                Stopwatch sw = Stopwatch.StartNew();
                var val = _dbContext.JsonEntities.Where(x => x.JsonVal.Value == _findVal).FirstOrDefault();
                sw.Stop();

                if (val != null)
                    listTime.Add(sw.Elapsed.TotalMilliseconds);
            }

            return listTime;
        }

        public int Count()
        {
            return _dbContext.JsonEntities.Count();
        }

        public IEnumerable<double> FindByJsonB(string _findVal)
        {
            var listTime = new List<double>();

            for (int i = 0; i < 10; i++)
            {
                Stopwatch sw = Stopwatch.StartNew();
                var val = _dbContext.JsonEntities.Where(x => x.TestJsonColumn.Value == _findVal).FirstOrDefault();
                sw.Stop();
             
                if (val != null)
                    listTime.Add(sw.Elapsed.TotalMilliseconds);
            }

            return listTime;
        }

        public int GetLastIndex()
        {
            return _dbContext.JsonEntities.OrderByDescending(x => x.Id).First().Id;
        }
    }
}
