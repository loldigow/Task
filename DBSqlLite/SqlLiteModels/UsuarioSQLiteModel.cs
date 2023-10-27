using System;
using System.Collections.Generic;
using System.Text;

namespace DBSqlLite.SqlLiteModels
{
    public class UsuarioSQLiteModel : SqlModelbase
    {
        public string Nome { get; set; }
        public bool IniciandoNoAplicativo { get; set; }
    }
}
