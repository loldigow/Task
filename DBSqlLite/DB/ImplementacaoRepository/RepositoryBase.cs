using Core.Interfaces;
using DBSqlLite;
using DBSqlLite.SqlLiteModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DB.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : SqlModelbase
    {
        public DbContext DBbContext;
        public DbSet<TEntity> Contexto { get; set; }

        public RepositoryBase()
        {
            DBbContext = new PublicContext();
        }

        public void Delete(Guid id)
        {
            var entidade = Get(id);
            Contexto.Remove(entidade);
            DBbContext.SaveChanges();
        }

        public TEntity Get(Guid id)
        {
           return Contexto.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Contexto.ToList();
        }

        public void Salve(TEntity entity)
        {
            Contexto.Add(entity);
            DBbContext.SaveChanges();
        }

        public void Update(TEntity entidade)
        {
            Contexto.Update(entidade);
            DBbContext.SaveChanges();
        }
    }
}
