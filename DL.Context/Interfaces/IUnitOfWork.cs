using System;

namespace DL.Context.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IJsonEntityRepository JsonEntities { get; }
        IResultRepositories ResultEntities { get; }
        void Save();
    }
}
