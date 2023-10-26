using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task.Core;
using task.Core.AppModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace task.controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RepeteTask : ContentView
    {
        public static readonly BindableProperty ConfiguracoesDeRpeticaoProperty = BindableProperty.Create(nameof(ConfiguracoesDeRpeticao), typeof(ConfiguracoesDeRpeticaoModel), typeof(RepeteTask));
        public ConfiguracoesDeRpeticaoModel ConfiguracoesDeRpeticao
        {
            get { return (ConfiguracoesDeRpeticaoModel)GetValue(ConfiguracoesDeRpeticaoProperty); }
            set { SetValue(ConfiguracoesDeRpeticaoProperty, value); }
        }
        public RepeteTask()
        {
            InitializeComponent();
        }
    }
}