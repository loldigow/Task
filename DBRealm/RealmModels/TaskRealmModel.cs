using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBRealm.RealmModels
{
    public class TaskRealmModel : RealmObject
    {
        [PrimaryKey]
        public string Id { get ; set; }
        public bool Realizada { get; set; }
        public string NomeTask { get; set; }
        public string ObservacaoTask { get; set; }
        public string DataInicioTask { get; set; }
        public string HoraInicioTask { get; set; }
        public string DataFimTask { get; set; }
        public string HoraFimTask { get; set; }
    }
}
