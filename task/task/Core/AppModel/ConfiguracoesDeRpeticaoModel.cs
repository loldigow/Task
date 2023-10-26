using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;

namespace task.Core.AppModel
{
    public partial class ConfiguracoesDeRpeticaoModel : ObservableObject
    {
        [ObservableProperty]
        public bool repete;
        [ObservableProperty]
        public RepeticaoEnum repeteEnum;
        [ObservableProperty]
        public DateTime dataFim;
        [ObservableProperty]
        bool diariamente = true;
        [ObservableProperty]
        bool semanalmente;
        [ObservableProperty]
        bool mensalmente;


        public ObservableCollection<DiasEnum> Dias;
        public ConfiguracoesDeRpeticaoModel()
        {
            DataFim = DateTime.Now.AddDays(1);
            Dias = new ObservableCollection<DiasEnum>();
        }

        [RelayCommand]
        void AdicioneDiaDaSemana(object objeto)
        {
            if (int.TryParse(objeto.ToString(), out var diaInteiro))
            {
                var dia = (DiasEnum)diaInteiro;
                if (!Dias.Contains(dia))
                {
                    Dias.Add(dia);
                }
                else
                {
                    Dias.Remove(dia);
                }

            }
        }
    }
}
