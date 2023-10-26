using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Core.Interfaces;
using Core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
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
        DateTime dataTask;

        [ObservableProperty]
        TimeSpan horaInicio;

        [ObservableProperty]
        TimeSpan horaFim;

        [ObservableProperty]
        ConfiguracoesDeRpeticaoModel configuracoesDerRpeticao;

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
            DataTask = task.DataInicioTask.Date;
            HoraInicio = task.DataInicioTask.TimeOfDay;
            HoraFim = task.DataFimTask.TimeOfDay;
            ObservacaoTask = task.ObservacaoTask;
            DescricaoBotao = task.Realizada ? FuncaoTaskEnum.Fechar : FuncaoTaskEnum.Concluir;
            Finalizado = task.Realizada;
        }

        private void CrieNovaTask(DateTime? data = null)
        {
            NomeTela = "Nova task";

            DataTask = data.HasValue ? data.Value : DateTime.Now.Date;
            HoraInicio = new TimeSpan(DateTime.Now.Ticks);
            HoraFim = new TimeSpan(DateTime.Now.Ticks + 2600);

            DescricaoBotao = FuncaoTaskEnum.Salvar;
            ConfiguracoesDerRpeticao = new();
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
                        if (ConfiguracoesDerRpeticao.Repete)
                        {
                            SalveLoteDeTasks();
                        }
                        else
                        {
                            SalveTaskUnica();

                        }
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

        private void SalveLoteDeTasks()
        {
            List<Task> tasks = new List<Task>();
            if (ConfiguracoesDerRpeticao.Diariamente)
            {
                var dataReferencia = DataTask.Date;
                while (dataReferencia <= ConfiguracoesDerRpeticao.DataFim.Date)
                {
                    var task = MapeieModel(dataReferencia);
                    tasks.Add(task);
                    dataReferencia = dataReferencia.AddDays(1);
                }
            }
            if (ConfiguracoesDerRpeticao.Semanalmente)
            {
                var dataReferencia = DataTask.Date;
                while (dataReferencia <= ConfiguracoesDerRpeticao.DataFim.Date)
                {
                    if (ConfiguracoesDerRpeticao.Dias.Any(x => (int)x == (int)dataReferencia.DayOfWeek))
                    {
                        var task = MapeieModel(dataReferencia);
                        tasks.Add(task);
                    }
                    dataReferencia = dataReferencia.AddDays(1);
                }
            }
            if (ConfiguracoesDerRpeticao.Mensalmente)
            {
                var dataReferencia = DataTask.Date;
                while (dataReferencia <= ConfiguracoesDerRpeticao.DataFim.Date)
                {
                    var task = MapeieModel(dataReferencia);
                    tasks.Add(task);
                    dataReferencia = dataReferencia.AddMonths(1);
                }
            }

            var contador = 1;
            foreach (var task in tasks)
            {
                task.NomeTask += $" {contador}/{tasks.Count()}";
                contador++;
            }

            SalveVariasTasks(tasks);
        }

        private void SalveTaskUnica()
        {
            var model = MapeieModel();
            _taskRepository.Salve(model);
            new Notificacao().AgendeNotificacao("Task", model.NomeTask, model.DataInicioTask);
        }

        private void SalveVariasTasks(List<Task> tasks)
        {
            _taskRepository.SalveVariasTasks(tasks);
            foreach (var task in tasks)
            {
                new Notificacao().AgendeNotificacao("Task", task.NomeTask, task.DataInicioTask);
            }
        }

        [RelayCommand]
        void Exclua()
        {
            try
            {
                _taskRepository.Delete(_id);
                Application.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                MensagemPopup.ShowMessage("Erro", ex.Message);
            }
        }

        private bool ModelEhValida()
        {
            if (string.IsNullOrEmpty(DescricaoTask))
            {
                MensagemPopup.ShowMessage("Erro", "Descrição de atividade não pode estar vazia");
                return false;
            }
            var dataInicioTask = DataTask.Date.AddHours(HoraInicio.Hours).AddMinutes(HoraInicio.Minutes);
            var dataFim = ConfiguracoesDerRpeticao.DataFim.Date.AddHours(HoraInicio.Hours).AddMinutes(HoraInicio.Minutes);

            if (ConfiguracoesDerRpeticao.Repete)
            {
                if (ConfiguracoesDerRpeticao.Diariamente)
                {
                    if (dataFim < dataInicioTask.AddDays(1))
                    {
                        MensagemPopup.ShowMessage("Erro", "Data de termino para repetição deve conter pelo menos um dia de repetição");
                        return false;
                    }
                }
                else if (ConfiguracoesDerRpeticao.Semanalmente)
                {
                    if (!ConfiguracoesDerRpeticao.Dias.Any())
                    {
                        MensagemPopup.ShowMessage("Erro", "Selecione pelo menos um dia da semanda");
                        return false;
                    }

                    if (dataFim < dataInicioTask.AddDays(7))
                    {
                        MensagemPopup.ShowMessage("Erro", "Data de termino para repetição deve conter pelo menos uma semana de repetição");
                        return false;
                    }
                }
                else if (ConfiguracoesDerRpeticao.Mensalmente)
                {
                    if (dataFim < dataInicioTask.AddMonths(1))
                    {
                        MensagemPopup.ShowMessage("Erro", "Data de termino para repetição deve conter pelo menos um ano para repetição");
                        return false;
                    }
                }
                else
                {
                    MensagemPopup.ShowMessage("Erro", "Configure algum tipo de repetição");
                    return false;
                }
            }

            return true;
        }

        private Task MapeieModel(DateTime? dataReferencia = null)
        {
            var data = dataReferencia ?? DataTask;
            return new Task()
            {
                Id = _id,
                NomeTask = DescricaoTask,
                Realizada = false,
                DataInicioTask = data.Date.AddHours(HoraInicio.Hours).AddMinutes(HoraInicio.Minutes),
                DataFimTask = data.Date.AddHours(HoraFim.Hours).AddMinutes(HoraFim.Minutes),
                ObservacaoTask = ObservacaoTask
            };
        }
    }
}
