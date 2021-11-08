using ArcadeScore.Domain.Interfaces.Domain;
using ArcadeScore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArcadeScore.Infra.Data.Configuration
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected ArcadeScoreDB _context;
        protected readonly DbSet<TEntity> DbSet;

        public RepositoryBase(ArcadeScoreDB context)
        {
            _context = context;
            DbSet = _context.Set<TEntity>();
        }

        public void Insert(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
        }
        public void Add(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
        }

        public void Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(TEntity obj)
        {
            _context.Set<TEntity>().Remove(obj);
        }

        public async Task<IEnumerable<TEntity>> GetAll(bool @readonly = true)
        {
            if (@readonly)
                return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
            else
                return await _context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> Query(Expression<Func<TEntity, bool>> predicate, bool @readonly = true)
        {
            if (@readonly)
                return await _context.Set<TEntity>().Where(predicate).AsNoTracking().ToListAsync();
            else
                return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}