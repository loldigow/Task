using Core.Interfaces;
using DB.Repository;
using DBRealm.ImplementacaoRepository;
using DBSqlLite.DB.ImplementacaoRepository;
using DBSqlLite.SqlLiteModels;

namespace task.Core
{
    public static class DependencyService
    {
        public static void Registre()
        {
            Xamarin.Forms.DependencyService.RegisterSingleton<IBancoDados>(new BancoSqlite());
            Xamarin.Forms.DependencyService.RegisterSingleton<ITaskRepository>(new TaskSqliteRepository());
            Xamarin.Forms.DependencyService.RegisterSingleton<IUsuarioRepository>(new UsuarioSqliteRepository());
        }
    }
}
