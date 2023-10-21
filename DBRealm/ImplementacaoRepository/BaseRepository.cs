using Core.Interfaces;
using DBRealm.RealmModels;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBRealm.ImplementacaoRepository
{
    public class BaseRepository
    {
        protected Realm _realm;
        public BaseRepository()
        {
            _realm = Realm.GetInstance(Migration.config);
        }
    }

    public static class Migration
    {
        public static RealmConfiguration config =>
            new RealmConfiguration()
            {
                SchemaVersion = 2,
                MigrationCallback = (migration, oldSchemaVersion) =>
                {
                    // potentially lengthy data migration
                }
            };
    }
}
