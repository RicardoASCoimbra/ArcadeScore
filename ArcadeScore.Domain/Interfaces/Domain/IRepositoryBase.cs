﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ArcadeScore.Domain.Interfaces.Domain
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Insert(TEntity obj);
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);
        Task SaveChangesAsync();
        Task<IEnumerable<TEntity>> GetAll(bool @readonly = true);
        Task<IEnumerable<TEntity>> Query(Expression<Func<TEntity, bool>> predicate, bool @readonly = true);
    }
}
