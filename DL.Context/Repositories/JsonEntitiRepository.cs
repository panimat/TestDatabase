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
    public class JsonEntitiRepository : IRepository<JsonEntity>
    {
        private AppDbContext _dbContext;
        public JsonEntitiRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(JsonEntity item)
        {
            await _dbContext.JsonEntities.AddAsync(item);
        }

        public void Delete(int id)
        {
            JsonEntity jsonEntity = _dbContext.JsonEntities.Find(id);
            if (jsonEntity != null)
                _dbContext.JsonEntities.Remove(jsonEntity);
        }

        public IEnumerable<JsonEntity> Find(Func<JsonEntity, bool> predicate)
        {
            return _dbContext.JsonEntities.Where(predicate).ToList();
        }

        public double FindByJson(string _findVal)
        {
            Stopwatch sw = Stopwatch.StartNew();
            var val = _dbContext.JsonEntities.Where(x => x.JsonValField.Value == _findVal).FirstOrDefault();
            sw.Stop();

            if (val != null)
                return sw.Elapsed.TotalMilliseconds;
            else return 0;
        }

        public double FindByString(string _findVal)
        {
            Stopwatch sw = Stopwatch.StartNew();
            var val = _dbContext.JsonEntities.Where(x => x.StringField == _findVal).FirstOrDefault();
            sw.Stop();

            if (val != null)
                return sw.Elapsed.TotalMilliseconds;
            else return 0;
        }

        public int Count()
        {
            return _dbContext.JsonEntities.Count();
        }

        public JsonEntity Get(int id)
        {
            return _dbContext.JsonEntities.Find(id);
        }

        public IEnumerable<JsonEntity> GetAll()
        {
            return _dbContext.JsonEntities;
        }

        public void Update(JsonEntity item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
