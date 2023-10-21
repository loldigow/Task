using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Svg;
using Xamarin.Forms.Xaml;

namespace task.controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckBoxControl : ContentView
    {
        bool _check;
        public CheckBoxControl()
        {
            InitializeComponent();
            _check = false;
            var imageSource = SvgImageSource.FromSvgResource("Resource/Images/uncheck.svg", 50d,50d ,Color.Black);
            image.Source = imageSource;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var source = _check ? "Resource/Images/check.svg" : "Resource/Images/uncheck.svg";
            var imageSource = SvgImageSource.FromSvgResource(source, 50d, 50d, Color.Black);
            image.Source = imageSource;
        }
    }
}