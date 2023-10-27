using Core.Enuns;
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

        internal static Color ProcesseCorPrioridade(NivelDePrioridadeEnum prioridade)
        {
            switch(prioridade)
            {
                case NivelDePrioridadeEnum.Baixo: return Color.Green;
                case NivelDePrioridadeEnum.Medio: return Color.Yellow;
                case NivelDePrioridadeEnum.Alto: return Color.Red;
                default: return Color.White;
            }
        }
    }
}
