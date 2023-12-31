﻿using Core.Interfaces;
using task.Core;
using task.View;
using Xamarin.Forms;

namespace task
{
    public partial class App : Application
    {
        IBancoDados _repoBanco;
        IUsuarioRepository _repoUsuarioRepository;
        public App()
        {
            Core.DependencyService.Registre();
            InitializeComponent();
            _repoBanco = Xamarin.Forms.DependencyService.Resolve<IBancoDados>();
            _repoUsuarioRepository = Xamarin.Forms.DependencyService.Resolve<IUsuarioRepository>();
            _repoBanco.Init();
            var usuario = _repoUsuarioRepository.GetUsuario();
            if (usuario == null)
            {
                MainPage = new WellcomePage();
            }
            else
            {
                MainPage = new NavigationPage(new TaskPage());
            }
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
