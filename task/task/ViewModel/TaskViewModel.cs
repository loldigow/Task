using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using task.controls;
using task.Core;
using task.Core.AppModel;
using task.View;
using Xamarin.Forms;

namespace task.ViewModel
{
    public partial class TaskViewModel : ObservableObject
    {
        #region private properts
        readonly ITaskRepository _taskrepository = Xamarin.Forms.DependencyService.Resolve<ITaskRepository>();
        readonly IUsuarioRepository _usuarioRepository = Xamarin.Forms.DependencyService.Resolve<IUsuarioRepository>();
        #endregion

        #region publics properts       

        [ObservableProperty]
        DateTime data;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(DescricaoQuantidadeTasks))]
        IEnumerable<TaskModel> listaTasksDoDia;

        [ObservableProperty]
        string diaDaSemana;

        [ObservableProperty]
        string quantidadeDeTasks;

        public string DescricaoQuantidadeTasks => ListaTasksDoDia.Count() > 0 ? $"{ListaTasksDoDia.Count()} {(ListaTasksDoDia.Count() > 1 ? "Tasks" : "Task")}" : "Nenhuma task registrada";
        #endregion


        public TaskViewModel()
        {
            Data = DateTime.Now;
            ListaTasksDoDia = new List<TaskModel>();
        }


        private void CarregueData(DateTime data)
        {
            try
            {
                ListaTasksDoDia = new List<TaskModel>();
                var lista = _taskrepository.GetAllOnDay(data.Date)
                                           .OrderBy(x => x.DataInicioTask)
                                           .ToList();

                var idioma = CultureInfo.CurrentCulture;
                DiaDaSemana = Data.ToString("dddd", idioma);
                QuantidadeDeTasks = $"{lista.Count()} tasks";

                var listaConvertida = lista.Select(x => new TaskModel()
                {
                    Id = x.Id,
                    NomeTask = x.NomeTask,
                    ObservacaoTask = x.ObservacaoTask,
                    Realizada = x.Realizada,
                    DataFimTask = x.DataFimTask,
                    DataInicioTask = x.DataInicioTask,
                    CorTask = Utilies.ProcessoERetorneCorDeTask(x.DataInicioTask, x.DataFimTask)
                });

                ListaTasksDoDia = listaConvertida;
            }
            catch (Exception e)
            {
                MensagemPopup.ShowMessage("Erro", e.Message);
            }
        }

        internal void OnAppearing()
        {
            var usuario = _usuarioRepository.GetUsuario();
            if (usuario.IniciandoNoAplicativo)
            {
                usuario.IniciandoNoAplicativo = false;
                _usuarioRepository.Update(usuario);
                Tour.InicieTour();
            }
            CarregueData(Data);
        }
        #region Commands

        [RelayCommand]
        async Task CrieNovaTaskAsync()
        {
            var pagidaDeCadastro = new DetalheTask(Data);
            await Application.Current.MainPage.Navigation.PushAsync(pagidaDeCadastro);
        }

        [RelayCommand]
        async void AlterouData(object dataObject)
        {
            if (dataObject is DateTime data)
            {
                Data = data;
                CarregueData(data);
            }
        }

        [RelayCommand]
        async Task AbraTask(object objeto)
        {
            if (objeto is TaskModel model)
            {
                var pagidaDeCadastro = new DetalheTask(model);
                await Application.Current.MainPage.Navigation.PushAsync(pagidaDeCadastro);
            }
        }

        [RelayCommand]
        void ConcluaTarefa(object obj)
        {
            if (obj is TaskModel model)
            {
                try
                {
                    _taskrepository.ConcluaTarefa(model.Id);
                }
                catch (Exception e)
                {
                    MensagemPopup.ShowMessage("Erro", e.Message);
                }
            }
        }

        [RelayCommand]
        void Gesto(object direcaoObject)
        {
            if (direcaoObject is string direcao)
            {
                switch (direcao)
                {
                    case "Left":
                        Data = Data.AddDays(1);
                        break;
                    case "Right":
                        Data = Data.AddDays(-1);
                        break;
                }
                CarregueData(Data);
            }
        }

        #endregion
    }
}
