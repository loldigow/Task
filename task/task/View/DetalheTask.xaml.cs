using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task.Core.AppModel;
using task.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace task.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalheTask : ContentPage
	{
		public DetalheTask (TaskModel model = null)
		{
			InitializeComponent ();
			BindingContext = new DetalheTaskViewModel(model);
		}
        public DetalheTask(DateTime data)
        {
            InitializeComponent();
            BindingContext = new DetalheTaskViewModel(data);
        }
    }
}