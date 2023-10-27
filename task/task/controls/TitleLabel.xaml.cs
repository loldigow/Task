using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;

namespace task.controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TitleLabel : ContentView
    {
        public static readonly BindableProperty CorTextoProperty = BindableProperty.Create(nameof(CorTexto), typeof(Color), typeof(TitleLabel));
        public static readonly BindableProperty TituloProperty = BindableProperty.Create(nameof(Titulo), typeof(string), typeof(TitleLabel));
        public static readonly BindableProperty ValorProperty = BindableProperty.Create(nameof(Valor), typeof(string), typeof(TitleLabel));
        public static readonly BindableProperty IconTextAwesomeCorProperty = BindableProperty.Create(nameof(IconTextAwesomeCor), typeof(Color), typeof(TitleLabel));
        public Color CorTexto
        {
            get { return (Color)GetValue(CorTextoProperty); }
            set { SetValue(CorTextoProperty, value); }
        }
        public string Titulo
        {
            get { return (string)GetValue(TituloProperty); }
            set { SetValue(TituloProperty, value); }
        }
        public string Valor
        {
            get { return (string)GetValue(ValorProperty); }
            set { SetValue(ValorProperty, value); }
        }
        public Color IconTextAwesomeCor
        {
            get { return (Color)GetValue(IconTextAwesomeCorProperty); }
            set { SetValue(IconTextAwesomeCorProperty, value); }
        }


        public TitleLabel()
        {
            InitializeComponent();
        }
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(Titulo))
            {
                LabelTitulo.Text = Titulo;
            }

            if (propertyName == nameof(Valor))
            {
                LabelValor.Text = Valor;
            }

            if (propertyName == nameof(CorTexto))
            {
                LabelTitulo.TextColor = CorTexto;
                LabelValor.TextColor = CorTexto;
            }

            if (propertyName == nameof(IconTextAwesomeCor))
            {
                LabelIconAwesome.TextColor = IconTextAwesomeCor;
                LabelIconAwesome.IsVisible = true;
            }
        }
    }
}