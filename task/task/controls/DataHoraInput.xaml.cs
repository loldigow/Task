using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace task.controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataHoraInput : ContentView
    {
        public static readonly BindableProperty DataProperty = BindableProperty.Create(nameof(Data), typeof(DateTime), typeof(DataHoraInput));
        public static readonly BindableProperty HoraProperty = BindableProperty.Create(nameof(Hora), typeof(TimeSpan), typeof(DataHoraInput));
        public static readonly BindableProperty DescricaoInputProperty = BindableProperty.Create(nameof(DescricaoInput), typeof(string), typeof(DataHoraInput));
        public DateTime Data
        {
            get { return (DateTime)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }
        public TimeSpan Hora
        {
            get { return (TimeSpan)GetValue(HoraProperty); }
            set { SetValue(HoraProperty, value); }
        }
        public string DescricaoInput
        {
            get { return (string)GetValue(DescricaoInputProperty); }
            set { SetValue(DescricaoInputProperty, value); }
        }

        public DataHoraInput()
        {
            InitializeComponent();
        }


        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == nameof(Data))
            {
                LabelData.Text = Data.ToString("dd/MM/yyyy");
            };
            if (propertyName == nameof(Hora))
            {
                LabelHora.Text = Hora.ToString(@"hh\:mm");
                HoraPicker.Time = TimeSpan.Parse(LabelHora.Text);
            }
            if (propertyName == nameof(DescricaoInput))
            {
                LabelDescricaoInput.Text = DescricaoInput;
            }
        }

        private void DataAcionada(object sender, EventArgs e)
        {
            DataPicker.Focus();
        }

        private void HoraEspecifica(object sender, EventArgs e)
        {
            HoraPicker.Focus();
        }

        private void DataPicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            Data = e.NewDate;
        }

        private void HoraPicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (sender is TimePicker input)
            {
                if (e.PropertyName == nameof(TimePicker.Time))
                {
                    Hora = input.Time;
                }
            }
        }
    }
}