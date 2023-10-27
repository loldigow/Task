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
    public partial class PrioridadeSelection : ContentView
    {
        public static readonly BindableProperty PrioridadeProperty = BindableProperty.Create(nameof(Prioridade), typeof(int?), typeof(PrioridadeSelection));
        public int? Prioridade
        {
            get { return (int)GetValue(PrioridadeProperty); }
            set { SetValue(PrioridadeProperty, value); }
        }


        public PrioridadeSelection()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == nameof(Prioridade))
            {
                DesmarqueTodoss();
                switch (Prioridade)
                {
                    case 0:
                        Check0.BackgroundColor = Color.Green;
                        break;
                    case 1:
                        Check1.BackgroundColor = Color.Yellow;
                        break;
                    case 2:
                        Check2.BackgroundColor = Color.Red;
                        break;
                    default:
                        break;
                }
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (e != null && e is TappedEventArgs tappedEventArgs)
            {
                var parametro = int.Parse(tappedEventArgs.Parameter.ToString());
                Prioridade = parametro;
            }
        }

        private void DesmarqueTodoss()
        {
            Check0.BackgroundColor = Color.Transparent;
            Check1.BackgroundColor = Color.Transparent;
            Check2.BackgroundColor = Color.Transparent;
        }
    }
}