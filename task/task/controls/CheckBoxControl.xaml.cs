using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace task.controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckBoxControl : ContentView
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(CheckBoxControl), defaultBindingMode: BindingMode.TwoWay);
        public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create(nameof(IsChecked), typeof(bool), typeof(CheckBoxControl), defaultBindingMode: BindingMode.TwoWay);
        public static readonly BindableProperty OnCheckedCommandProperty = BindableProperty.Create(nameof(OnCheckedCommand), typeof(ICommand), typeof(CheckBoxControl), defaultBindingMode: BindingMode.TwoWay);
        public static readonly BindableProperty OnCheckedCommandParameterProperty = BindableProperty.Create(nameof(OnCheckedCommandParameter), typeof(object), typeof(CheckBoxControl), defaultBindingMode: BindingMode.TwoWay);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }  
        }
        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }
        
        public ICommand OnCheckedCommand
        {
            get { return (ICommand)GetValue(OnCheckedCommandProperty); }
            set { SetValue(OnCheckedCommandProperty, value); }
        }

        public object OnCheckedCommandParameter
        {
            get { return (object)GetValue(OnCheckedCommandParameterProperty); }
            set { SetValue(OnCheckedCommandParameterProperty, value); }
        }

        public CheckBoxControl()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if(OnCheckedCommand?.CanExecute(OnCheckedCommandParameter) ?? false) {
                OnCheckedCommand.Execute(OnCheckedCommandParameter);
            }
        }
    }
}