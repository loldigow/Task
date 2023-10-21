using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Core.Interfaces;
using Core.Modelos;
using System;
using task.controls;
using task.Core;
using task.Core.AppModel;
using Xamarin.Forms;

namespace task.ViewModel
{
    public partial class DetalheTaskViewModel : ObservableObject
    {
        private readonly ITaskRepository _taskRepository = Xamarin.Forms.DependencyService.Resolve<ITaskRepository>();
        private Guid _id;


        [ObservableProperty]
        string nomeTela;

        [ObservableProperty]
        DateTime dataInicio;

        [ObservableProperty]
        TimeSpan horaInicio;

        [ObservableProperty]
        DateTime dataFim;

        [ObservableProperty]
        TimeSpan horaFim;

        [ObservableProperty]
        string descricaoTask;

        [ObservableProperty]
        string observacaoTask;

        [ObservableProperty]
        string descricaoBotao;

        [ObservableProperty]
        bool finalizado;








        public DetalheTaskViewModel(TaskModel task)
        {
            if (task == null)
            {
                CrieNovaTask();
            }
            else
            {
                CarregueTask(task);
            }
        }

        public DetalheTaskViewModel(DateTime data)
        {
            CrieNovaTask(data);
        }

        private void CarregueTask(TaskModel task)
        {
            _id = task.Id;
            NomeTela = "Visualizar";
            DescricaoTask = task.NomeTask;
            DataInicio = task.DataInicioTask.Date;
            HoraInicio = task.DataInicioTask.TimeOfDay;
            DataFim = task.DataFimTask.Date;
            HoraFim = task.DataFimTask.TimeOfDay;
            ObservacaoTask = task.ObservacaoTask;
            DescricaoBotao = task.Realizada ? FuncaoTaskEnum.Fechar : FuncaoTaskEnum.Concluir;
            Finalizado = task.Realizada;
        }

        private void CrieNovaTask(DateTime? data = null)
        {
            NomeTela = "Nova task";
            DataInicio = data.HasValue ? data.Value : DateTime.Now.Date;
            HoraInicio = new TimeSpan(DateTime.Now.Ticks);
            DataFim = data.HasValue ? data.Value : DateTime.Now.Date;
            HoraFim = new TimeSpan(DateTime.Now.Ticks + 2600);
            DescricaoBotao = FuncaoTaskEnum.Salvar;
            _id = Guid.Empty;
        }

        [RelayCommand]
        void Salve()
        {
            switch (DescricaoBotao)
            {
                case FuncaoTaskEnum.Salvar:
                    if (ModelEhValida())
                    {
                        var model = MapeieModel();
                        _taskRepository.Salve(ref model);
                        new Notificacao().AgendeNotificacao("Task", model.NomeTask, model.DataInicioTask);
                    }
                    else return;
                    break;
                case FuncaoTaskEnum.Concluir:
                    _taskRepository.ConcluaTarefa(_id);
                    break;
                default:
                    break;
            }
            Application.Current.MainPage.Navigation.PopAsync();
        }

        [RelayCommand]
        void Exclua()
        {
            try
            {
                _taskRepository.Delete(_id);
                Application.Current.MainPage.Navigation.PopAsync();
            }
            catch(Exception ex)
            {
                MensagemPopup.ShowMessage("Erro",ex.Message);
            }
        }

        private bool ModelEhValida()
        {
            if (string.IsNullOrEmpty(DescricaoTask))
            {
                MensagemPopup.ShowMessage("Erro","Descrição de atividade não pode estar vazia");
                return false;
            }
            var dataInicioTask = DataInicio.AddHours(HoraInicio.Hours).AddMinutes(HoraInicio.Minutes);
            var dataFimTask = DataFim.AddHours(HoraFim.Hours).AddMinutes(HoraFim.Minutes);
            if(dataFimTask < dataInicioTask)
            {
                MensagemPopup.ShowMessage("Erro","Data fim atividade menor que data de inicio");
                return false;
            }
            return true;
        }

        private Task MapeieModel()
        {
            return new Task()
            {
                Id = _id,
                NomeTask = DescricaoTask,
                Realizada = false,
                DataInicioTask = DataInicio.Date.AddHours(HoraInicio.Hours).AddMinutes(HoraInicio.Minutes),
                DataFimTask = DataFim.Date.AddHours(HoraFim.Hours).AddMinutes(HoraFim.Minutes),
                ObservacaoTask = ObservacaoTask
            };
        }
    }
}
