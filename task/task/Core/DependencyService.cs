using Core.Interfaces;
using DBSqlLite;
using DBSqlLite.Repository;

namespace task.Core
{
    public static class DependencyService
    {
        public static void Registre()
        {
            //Xamarin.Forms.DependencyService.RegisterSingleton<IBancoDados>(new BancoRealm());
            //Xamarin.Forms.DependencyService.RegisterSingleton<ITaskRepository>(new TaskRealmRepository());
            //Xamarin.Forms.DependencyService.RegisterSingleton<IUsuarioRepository>(new UsuarioRealmRepository());
            
            Xamarin.Forms.DependencyService.RegisterSingleton<IBancoDados>(new BancoSqlite());
            Xamarin.Forms.DependencyService.RegisterSingleton<ITaskRepository>(new TaskSqliteRepository());
            Xamarin.Forms.DependencyService.RegisterSingleton<IUsuarioRepository>(new UsuarioSqliteRepository());
        }
    }
}
