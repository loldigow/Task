using Core.Interfaces;
using Core.Modelos;
using DBSqlLite.Mapper;
using DBSqlLite.SqlLiteModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DB.Repository
{
    public class UsuarioSqliteRepository : RepositoryBase<UsuarioSQLiteModel>, IUsuarioRepository
    {
        public Usuario GetUsuario()
        {
            var usuario = base.GetAll().FirstOrDefault();
            if (usuario != null)
            {
                Mapper.GetMapper().Map<Usuario>(usuario);
            }
            return null;
        }

        public void Salve(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario id)
        {
            throw new NotImplementedException();
        }

        Usuario IRepositoryBase<Usuario>.Get(Guid id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Usuario> IRepositoryBase<Usuario>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
