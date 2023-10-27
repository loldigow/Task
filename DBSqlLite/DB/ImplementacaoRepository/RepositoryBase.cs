using Core.Interfaces;
using DBSqlLite.SqlLiteModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DBSqlLite.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : SqlModelbase
    {
        protected AppDbContext DBbContext;

        public RepositoryBase()
        {
            this.DBbContext = new AppDbContext();
        }

        public void Delete(Guid id)
        {
            var entidade = Get(id);
            DBbContext.Set<TEntity>()
                      .Remove(entidade);
            DBbContext.SaveChanges();
        }

        public TEntity Get(Guid id)
        {
           return DBbContext.Set<TEntity>()
                            .Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DBbContext.Set<TEntity>()
                             .ToList();
        }

        public void Salve(TEntity entity)
        {
            DBbContext.Set<TEntity>()
                      .Add(entity);
            DBbContext.SaveChanges();
        }

        public void Update(TEntity entidade)
        {
            DBbContext.Set<TEntity>()
                      .Update(entidade);
            DBbContext.SaveChanges();
        }
    }
}
