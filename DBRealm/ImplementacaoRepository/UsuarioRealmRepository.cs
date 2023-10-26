using Core.Interfaces;
using Core.Modelos;
using DBRealm.RealmModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBRealm.ImplementacaoRepository
{
    public class UsuarioRealmRepository : BaseRepository, IUsuarioRepository
    {
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
            var selectedStudent = _realm.All<UsuarioRealmModel>().ToList();
            if (selectedStudent.Any())
            {
                return Mapper.GetMapper().Map<Usuario>(selectedStudent.First());
            }
            return null;
        }

        public void Salve(Usuario entity)
        {
            var usuario = Mapper.GetMapper().Map<UsuarioRealmModel>(entity);
            _realm.Write(() =>
            {
                _realm.Add(usuario, true);
            });

        }

        public void Update(Usuario id)
        {
            var usuario = _realm.All<UsuarioRealmModel>().FirstOrDefault();
            if (usuario == null)
            {
                _realm.Write(() =>
                {
                    usuario.IniciandoNoAplicativo = false;
                    _realm.Add(usuario, true);
                });
            }
        }
    }
}
