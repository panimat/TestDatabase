using System;
using DL.Context.Entities;
using System.Collections.Generic;
using System.Text;

namespace DL.Context.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<JsonEntity> JsonEntities { get; }
        void Save();
    }
}
