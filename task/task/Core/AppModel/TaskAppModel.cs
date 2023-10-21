using System;
using Xamarin.Forms;

namespace task.Core.AppModel
{
    public class TaskModel
    {
        public Guid Id { get; set; }
        public bool Realizada { get; set; }
        public string NomeTask { get; set; }
        public string ObservacaoTask { get; set; }
        public DateTime DataInicioTask { get; set; }
        public DateTime DataFimTask { get; set; }
        public Color CorTask { get; set; }
        public string HorarioFormatado => $"Das {DataInicioTask.ObtenhaDescricaoIntervalo()} às {DataFimTask.ObtenhaDescricaoIntervalo()}";
    }
}
