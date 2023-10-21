using System;
using System.Threading.Tasks;
using Android.Content.Res;
using Android.OS;
using Plugin.CurrentActivity;
using task.Core.Interfaces;

namespace task.Droid.implementacao
{
    internal class TemaMobileAndroidRequest : IThemeMode
    {
        public Theme GetOperatingSystemTheme()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Froyo)
            {
                var uiModelFlags = CrossCurrentActivity.Current.AppContext.Resources.Configuration.UiMode & UiMode.NightMask;

                switch (uiModelFlags)
                {
                    case UiMode.NightYes:
                        return Theme.Dark;

                    case UiMode.NightNo:
                        return Theme.Light;

                    default:
                        return Theme.Padrao;
                }
            }
            else
            {
                return Theme.Light;
            }
        }

        public Task<Theme> GetOperatingSystemThemeAsync() => Task.FromResult(GetOperatingSystemTheme());
    }
}