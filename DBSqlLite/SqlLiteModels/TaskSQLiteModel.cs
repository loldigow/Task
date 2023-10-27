using System;
using System.Collections.Generic;
using System.Text;

namespace DBSqlLite.SqlLiteModels
{
    public class TaskSQLiteModel : SqlModelbase
    {

        public bool Realizada { get; set; }
        public string NomeTask { get; set; }
        public string ObservacaoTask { get; set; }
        public DateTime DataInicioTask { get; set; }
        public DateTime DataFimTask { get; set; }
        public Guid InsertID { get; set; }
        public int Prioridade { get; set; }
    }
}
