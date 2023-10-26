using Core.Interfaces;
using DB.Repository;
using System.Data.Common;

namespace DB.ImplementacaoRepository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private BancoContexto<TEntity> _banco { get; set; }
        private DbConnection _conexao { get; set; }


        public RepositoryBase()
        {
            throw new NotImplementedException();
            //_banco = new BancoContexto<TEntity>();
            //_conexao = _banco.Database.GetDbConnection();
        }

        public TEntity Get(Guid id)
        {
            throw new NotImplementedException();
            // _banco.Database.SqlQuery<TEntity>(FormattableStringFactory.Create("")).First();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
            //_banco.Database.SqlQuery<TEntity>(FormattableStringFactory.Create("")).ToList();
        }

        public void Update(TEntity id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Salve(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
