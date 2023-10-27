using Core.Enuns;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Modelos
{
    public class Task
    {
        public Guid Id { get; set; }
        public bool Realizada { get; set; }
        public string NomeTask { get; set; }
        public string ObservacaoTask { get; set; }
        public DateTime DataInicioTask { get; set; }
        public DateTime DataFimTask { get; set; }
        public Guid InsertID { get; set; }
        public NivelDePrioridadeEnum Prioridade{get;set;}

    }
}
