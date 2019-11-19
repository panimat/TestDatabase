using System;
using System.Collections.Generic;
using System.Text;
using DL.Context.Entities;
using DL.Context.Interfaces;
using DL.Context.Context;

namespace DL.Context.Repositories
{
    public class ResultRepository : Repository<Result>, IResultRepositories
    {
        public ResultRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
