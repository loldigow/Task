using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task.Core;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace task.controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RepeteTask : ContentView
    {
        public static readonly BindableProperty ConfiguracoesDeRpeticaoProperty = BindableProperty.Create(nameof(ConfiguracoesDeRpeticao), typeof(ConfiguracoesDeRpeticao), typeof(RepeteTask));
        public ConfiguracoesDeRpeticao ConfiguracoesDeRpeticao
        {
            get { return (ConfiguracoesDeRpeticao)GetValue(ConfiguracoesDeRpeticaoProperty); }
            set { SetValue(ConfiguracoesDeRpeticaoProperty, value); }
        }
        public RepeteTask()
        {
            InitializeComponent();
        }
    }

    public partial class ConfiguracoesDeRpeticao : ObservableObject
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
        public ObservableCollection<MesesEnum> Meses;
        public ConfiguracoesDeRpeticao()
        {
            DataFim = DateTime.Now.AddDays(1);
            Dias = new ObservableCollection<DiasEnum>();
            Meses = new ObservableCollection<MesesEnum>();
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

        [RelayCommand]
        void AdicioneMes(object objeto)
        {
            if (int.TryParse(objeto.ToString(), out var mesInteiro))
            {
                var mes = (MesesEnum)mesInteiro;
                if (!Meses.Contains(mes))
                {
                    Meses.Add(mes);
                }
                else
                {
                    Meses.Remove(mes);
                }

            }
        }


    }
}