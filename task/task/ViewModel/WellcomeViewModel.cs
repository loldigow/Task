using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Core.Interfaces;
using Core.Modelos;
using System;
using System.Collections.Generic;
using System.Text;
using task.View;
using Xamarin.Forms;

namespace task.ViewModel
{
    public partial class WellcomeViewModel : ObservableObject
    {
        IUsuarioRepository _repoUsuarioRepository = DependencyService.Resolve<IUsuarioRepository>();

        [ObservableProperty]
        string nome;

        [RelayCommand]
        void InicieApp()
        {
            var usuario = new Usuario()
            {
                Nome = Nome
            };
            _repoUsuarioRepository.Salve(usuario);
            App.Current.MainPage = new NavigationPage(new TaskPage());

        }
    }
}
