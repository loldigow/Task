using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace task.Core.Interfaces
{
    public interface IThemeMode
    {
        Theme GetOperatingSystemTheme();
        Task<Theme> GetOperatingSystemThemeAsync();
    }
    public enum Theme { Light, Dark, Padrao }
}
