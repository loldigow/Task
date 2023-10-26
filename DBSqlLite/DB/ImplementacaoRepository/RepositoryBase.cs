using Core.Interfaces;
using DB.Repository;
using DBSqlLite.SqlLiteModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DB.ImplementacaoRepository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : SqlModelbase
    {
        protected new Context<TEntity> Tabela { get; set; }

        public RepositoryBase()
        {
            Tabela = new Context<TEntity>();
        }

        public void Delete(Guid id)
        {
            var entidade = Get(id);
            Tabela.Remove(entidade);
            Tabela.SaveChanges();
        }

        public TEntity Get(Guid id)
        {
           return Tabela.Contexto.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Tabela.Contexto.ToList();
        }

        public void Salve(TEntity entity)
        {
            Tabela.Contexto.Add(entity);
            Tabela.SaveChanges();
        }

        public void Update(TEntity entidade)
        {
            Tabela.Contexto.Update(entidade);
            Tabela.SaveChanges();
        }
    }
}
