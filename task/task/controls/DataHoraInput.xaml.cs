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
        public static readonly BindableProperty HoraInicioProperty = BindableProperty.Create(nameof(HoraInicio), typeof(TimeSpan), typeof(DataHoraInput));
        public static readonly BindableProperty HoraFimProperty = BindableProperty.Create(nameof(HoraFim), typeof(TimeSpan), typeof(DataHoraInput));
        public static readonly BindableProperty DescricaoInputProperty = BindableProperty.Create(nameof(DescricaoInput), typeof(string), typeof(DataHoraInput));
        public static readonly BindableProperty DesativaHoraInputProperty = BindableProperty.Create(nameof(DesativaHoraInput), typeof(bool), typeof(DataHoraInput));
        public DateTime Data
        {
            get { return (DateTime)GetValue(DataProperty); }
            set { SetValue(DataProperty, value); }
        }
        public TimeSpan HoraInicio
        {
            get { return (TimeSpan)GetValue(HoraInicioProperty); }
            set { SetValue(HoraInicioProperty, value); }
        }
        public TimeSpan HoraFim
        {
            get { return (TimeSpan)GetValue(HoraFimProperty); }
            set { SetValue(HoraFimProperty, value); }
        }
        public string DescricaoInput
        {
            get { return (string)GetValue(DescricaoInputProperty); }
            set { SetValue(DescricaoInputProperty, value); }
        }
        
        public bool DesativaHoraInput
        {
            get { return (bool)GetValue(DesativaHoraInputProperty); }
            set { SetValue(DesativaHoraInputProperty, value); }
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
            if (propertyName == nameof(HoraInicio))
            {
                LabelHoraInicio.Text = HoraInicio.ToString(@"hh\:mm");
                HoraInicioPicker.Time = TimeSpan.Parse(LabelHoraInicio.Text);
            }
            if (propertyName == nameof(HoraFim))
            {
                LabelHoraFim.Text = HoraFim.ToString(@"hh\:mm");
                HoraFimPicker.Time = TimeSpan.Parse(LabelHoraFim.Text);
            }
            if (propertyName == nameof(DescricaoInput))
            {
                LabelDescricaoInput.Text = DescricaoInput;
            }
            if(propertyName == nameof(DesativaHoraInput))
            {
                PainelHora.IsVisible = !DesativaHoraInput;
            }
        }

        private void DataAcionada(object sender, EventArgs e)
        {
            DataPicker.Focus();
        }

        private void HoraInicioEspecifica(object sender, EventArgs e)
        {
            HoraInicioPicker.Focus();
        }

        private void HoraFimEspecifica(object sender, EventArgs e)
        {
            HoraFimPicker.Focus();
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
                    HoraInicio = input.Time;
                }
            }
        }

        private void HoraFimPicker_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (sender is TimePicker input)
            {
                if (e.PropertyName == nameof(TimePicker.Time))
                {
                    HoraFim = input.Time;
                }
            }
        }
    }
}