using _.UniveraHiringChallengeData.Context;
using _.UniveraHiringChallengeData.Repositories.Abstractions;
using _.UniveraHiringChallengeData.Repositories.Concretes;
using _.UniveraHiringChallengeData.UnitOfWorks.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _.UniveraHiringChallengeData.UnitOfWorks.Concretes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async ValueTask DisposeAsync()
        {
           await appDbContext.DisposeAsync();
        }

        public IRepository<T> GetRepository<T>() where T : class, new()
        {
            return new Repository<T>(appDbContext);
        }

        public int Save()
        {
           return appDbContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
           return await appDbContext.SaveChangesAsync();
        }
    }
}
