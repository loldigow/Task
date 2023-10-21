using Core.Interfaces;
using task.Core;
using task.View;
using Xamarin.Forms;

namespace task
{
    public partial class App : Application
    {
        public App()
        {
            Core.DependencyService.Registre();
            Xamarin.Forms.DependencyService.Resolve<IBancoDados>().Init();
            InitializeComponent();

            MainPage = new NavigationPage(new TaskPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
