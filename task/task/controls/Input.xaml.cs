using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace task.controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Input : ContentView
    {
        public static readonly BindableProperty DescricaoProperty = BindableProperty.Create(nameof(Descricao), typeof(string), typeof(Input));
        public static readonly BindableProperty TextoProperty = BindableProperty.Create(nameof(Texto), typeof(string), typeof(Input));
        public static readonly BindableProperty MultiLineProperty = BindableProperty.Create(nameof(MultiLine), typeof(bool), typeof(Input));
        public string Texto
        {
            get { return (string)GetValue(TextoProperty); }
            set { SetValue(TextoProperty, value); }
        }
        public string Descricao
        {
            get { return (string)GetValue(DescricaoProperty); }
            set { SetValue(DescricaoProperty, value); }
        }
        public bool MultiLine
        {
            get { return (bool)GetValue(MultiLineProperty); }
            set { SetValue(MultiLineProperty, value); }
        }

        public Input()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == nameof(Descricao))
            {
                LabelDescricao.Text = Descricao;
            }
            if(propertyName == nameof(Texto) && !string.IsNullOrEmpty(Texto))
            {
                LabelDescricao.FontSize = 10;
                LabelDescricao.Margin = new Thickness(5, 5, 0, 0);
            }
            if( propertyName == nameof(MultiLine))
            {
                LabelTexto.IsVisible = false;
                EditorTexto.IsVisible = true;
                EditorTexto.AutoSize = EditorAutoSizeOption.TextChanges;
                
            }
        }



        private void LabelTexto_Focused(object sender, FocusEventArgs e)
        {
            LabelDescricao.FontSize = 10;
            LabelDescricao.Margin = new Thickness(5, 5, 0, 0);
        }

        private void LabelTexto_Unfocused(object sender, FocusEventArgs e)
        {
            if (string.IsNullOrEmpty(LabelTexto.Text))
            {
                LabelDescricao.FontSize = 20;
                LabelDescricao.Margin = new Thickness(5, 15, 0, 0);
            }
        }

        //private void LabelTexto_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    Texto = e.NewTextValue;
        //}
    }
}