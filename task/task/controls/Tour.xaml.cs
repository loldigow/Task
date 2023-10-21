using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace task.controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tour : ContentView
    {
        public Tour()
        {
            InitializeComponent();
        }

        public static async void InicieTour()
        {
            //TODO implementar opção
            //var opcao = await MensagemPopup.ShowSimNaoMensagemAsync("Tutorial", "Bem vindo ao App de tasks, Deseja ver um tour do app?", "Sim", "Não");
            //if(opcao != null && 
            //    opcao is string opcaoSelecionada &&
            //    opcaoSelecionada == "Sim")
            //{
            //    MensagemPopup.ShowMessage("AEEEE", "Ele digitou sim");
            //}
        }
    }
}