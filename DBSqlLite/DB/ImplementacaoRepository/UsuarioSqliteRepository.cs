using Core.Interfaces;
using Core.Modelos;
using DBSqlLite.SqlLiteModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DBSqlLite.Repository
{
    public class UsuarioSqliteRepository : RepositoryBase<UsuarioSQLiteModel>, IUsuarioRepository
    {
        public Usuario GetUsuario()
        {
            var usuario = base.GetAll().FirstOrDefault();
            if (usuario != null)
            {
                return Mapper.Mapper.GetMapper().Map<Usuario>(usuario);
            }
            return null;
        }

        public void Salve(Usuario entity)
        {
            var usuario = Mapper.Mapper.GetMapper().Map<UsuarioSQLiteModel>(entity);
            Salve(usuario);
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
