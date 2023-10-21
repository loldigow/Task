using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace task.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskPage : ContentPage
    {
        public TaskPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var taskViewModel = this.BindingContext as TaskViewModel;
            if (taskViewModel != null)
            {
                taskViewModel.OnAppearing();
            }
        }
    }
}