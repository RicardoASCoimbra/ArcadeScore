using ArcadeScore.Domain.Interfaces.Infra.Data;
using ArcadeScore.Infra.Data.Context;
using System;
using System.Threading.Tasks;

namespace ArcadeScore.Infra.Data.Configuration
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ArcadeScoreDB _dbContext;

        public UnitOfWork(ArcadeScoreDB dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Commit()
        {
            int rowsAffected = await _dbContext.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public void Close()
        {
            Dispose();
        }

        public string GetContextId()
        {
            return _dbContext.GetHashCode().ToString();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }

}
