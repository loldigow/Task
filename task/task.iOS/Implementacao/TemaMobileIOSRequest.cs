using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task.Core.Interfaces;
using UIKit;

namespace task.iOS.Implementacao
{
    internal class TemaMobileIOSRequest : IThemeMode
    {
        public Theme GetOperatingSystemTheme()
        {
            throw new NotImplementedException();
        }

        public Task<Theme> GetOperatingSystemThemeAsync()
        {
            throw new NotImplementedException();
        }
    }
}