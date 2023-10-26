using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace task.controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DateView : ContentView
    {
        public static readonly BindableProperty DataProperty = BindableProperty.Create(nameof(Data), typeof(DateTime), typeof(DateView));
        public static readonly BindableProperty OnDataChangedProperty = BindableProperty.Create(nameof(OnDataChanged), typeof(ICommand), typeof(DateView));
        public DateTime Data
        {
            get { return (DateTime)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }

        public ICommand OnDataChanged
        {
            get { return (ICommand)GetValue(OnDataChangedProperty); }
            set { SetValue(OnDataChangedProperty, value); }
        }
        public DateView()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if(propertyName == nameof(Data))
            {
                var idioma = CultureInfo.CurrentCulture; 
                LabelDia.Text = Data.ToString("dd");
                LabelMes.Text = Data.ToString("Y", idioma).Substring(0,3);
                if(OnDataChanged?.CanExecute(Data) ?? false)
                {
                    OnDataChanged.Execute(Data);
                }
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            SeletorData.Focus();
        }
    }
}