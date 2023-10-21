using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace task.controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MensagemPopup : PopupPage
    {
        public TaskCompletionSource<object> Source;

        public MensagemPopup(string titulo, string mensagem)
        {
            InitializeComponent();
            Info.Titulo = titulo;
            Info.Valor = mensagem;
            PainelOk.IsVisible = true;
            PainelSimNao.IsVisible = false;
        }
        public static void ShowMessage(string titulo, string mensagem)
        {
            App.Current.MainPage.Navigation.PushPopupAsync(new MensagemPopup(titulo, mensagem));
        }

        public MensagemPopup(string titulo, string mensagem, string mensagemSim, string mensagemNao) : this(titulo, mensagem)
        {
            Source = new TaskCompletionSource<object>();
            PainelOk.IsVisible = false;
            PainelSimNao.IsVisible = true;
            BotaoSim.Text = mensagemSim;
            BotaoNao.Text = mensagemNao;
        }


        internal static async Task<object> ShowSimNaoMensagemAsync(string titulo, string descricao, string mensagemSim, string mensagemNao)
        {
            var page = new MensagemPopup(titulo, descricao, mensagemSim, mensagemNao);
            await App.Current.MainPage.Navigation.PushPopupAsync(page);
            return await page.Source.Task;


            //page.PageDisapearing += (result) =>
            //{
            //    var res = (T)Convert.ChangeType(result, typeof(T));
            //    source.SetResult(res);
            //};


            //var result = await App.Current.MainPage.Navigation.ShowPopupAsync(popup);
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PopPopupAsync();
            if (PainelSimNao.IsVisible)
            {
                if (sender is Button botao)
                {
                    Source.SetResult(botao.Text);
                }
            }
        }
    }
}