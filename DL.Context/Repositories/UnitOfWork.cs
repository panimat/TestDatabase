using DL.Context.Interfaces;
using DL.Context.Context;

namespace DL.Context.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private JsonEntitiRepository jsonEntityRepository;
        private ResultRepository resultRepository;

        private readonly AppDbContext _dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IJsonEntityRepository JsonEntities
        {
            get
            {
                if (jsonEntityRepository == null)
                    jsonEntityRepository = new JsonEntitiRepository(_dbContext);
                return jsonEntityRepository;
            }
        }
        public IResultRepositories ResultEntities
        {
            get
            {
                if (resultRepository == null)
                    resultRepository = new ResultRepository(_dbContext);
                return resultRepository;
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
