using Core.Interfaces;
using DB.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DB.ImplementacaoRepository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private BancoContexto<TEntity> _banco { get; set; }
        private DbConnection _conexao { get; set; }


        public RepositoryBase()
        {
            _banco = new BancoContexto<TEntity>();
            _conexao = _banco.Database.GetDbConnection();
        }

        public TEntity Get(Guid id)
        {
            return _banco.Database.SqlQuery<TEntity>(FormattableStringFactory.Create("")).First();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _banco.Database.SqlQuery<TEntity>(FormattableStringFactory.Create("")).ToList();
        }

        public void Update(TEntity id)
        {

        }

        public void Delete(Guid id)
        {

        }
    }
}
