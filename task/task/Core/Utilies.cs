using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using task.Core.Interfaces;
using Xamarin.Forms;

namespace task.Core
{
    public static class Utilies
    {
        public static string ObtenhaDescricaoIntervalo(this DateTime data)
        {
            return $"{data.Hour} {(data.Minute > 0 ? $"e {data.Minute} " : string.Empty)}";
        }

        public static Color ProcessoERetorneCorDeTask(DateTime dataInicio, DateTime dataFim)
        {
            var theme = Xamarin.Forms.DependencyService.Resolve<IThemeMode>().GetOperatingSystemTheme();
            if (dataInicio < DateTime.Now)
            {
                if (DateTime.Now < dataFim)
                {
                    return theme == Theme.Dark ? Color.White : Color.FromHex("#7d0000");
                }
                return  theme == Theme.Dark ? Color.White : Color.Gray;
            }
            else
            {
                return theme == Theme.Dark ? Color.FromHex("#182f00") : Color.FromHex("#182f00"); 

            }
        }
    }
}
