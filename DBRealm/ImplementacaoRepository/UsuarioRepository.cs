using Core.Interfaces;
using Core.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBRealm.ImplementacaoRepository
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        bool teste = true;
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Usuario Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetAll()
        {
            throw new NotImplementedException();
        }

        public Usuario GetUsuario()
        {
            return new Usuario() { IniciandoNoAplicativo = teste};

        }

        public void Salve(Usuario entity)
        {
            throw new NotImplementedException();
        }


        public void Update(Usuario id)
        {
            teste = !teste;
        }
    }
}
