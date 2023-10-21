using Core.Interfaces;
using DBRealm;
using DBRealm.ImplementacaoRepository;

namespace task.Core
{
    public static class DependencyService
    {
        public static void Registre()
        {
            Xamarin.Forms.DependencyService.RegisterSingleton<IBancoDados>(new BancoRealm());
            Xamarin.Forms.DependencyService.RegisterSingleton<ITaskRepository>(new TaskRepository());
            Xamarin.Forms.DependencyService.RegisterSingleton<IUsuarioRepository>(new UsuarioRepository());
        }
    }
}
