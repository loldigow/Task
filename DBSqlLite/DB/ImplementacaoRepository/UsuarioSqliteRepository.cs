using Core.Interfaces;
using Core.Modelos;
using DB.ImplementacaoRepository;
using DBSqlLite.SqlLiteModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBSqlLite.DB.ImplementacaoRepository
{
    public class UsuarioSqliteRepository : RepositoryBase<UsuarioSQLiteModel>, IUsuarioRepository
    {
        public Usuario GetUsuario()
        {
            return new Usuario()
            {
                IniciandoNoAplicativo = false
            };
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
