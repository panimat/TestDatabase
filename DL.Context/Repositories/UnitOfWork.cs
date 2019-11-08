using System;
using System.Collections.Generic;
using System.Text;
using DL.Context.Entities;
using DL.Context.Interfaces;
using DL.Context.Context;
using Microsoft.Extensions.Logging;

namespace DL.Context.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private JsonEntitiRepository jsonEntityRepository;
        private readonly AppDbContext _dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IRepository<JsonEntity> JsonEntities
        {
            get
            {
                if (jsonEntityRepository == null)
                    jsonEntityRepository = new JsonEntitiRepository(_dbContext);
                return jsonEntityRepository;
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
