using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBRealm.RealmModels
{
    public class UsuarioRealmModel : RealmObject
    {
        public string Id { get; set; }
        public string Nome {  get; set; }
        public bool IniciandoNoAplicativo { get; set; }
    }
}
