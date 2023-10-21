using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Core.Interfaces
{
    public interface IRepositoryBase<TEntity>
    {
        TEntity Get(Guid id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity id);
        void Delete(Guid id);
        void Salve(ref TEntity entity);        
    }
}
