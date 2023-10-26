﻿using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using task.Core.Interfaces;
using task.Droid.implementacao;
using Xamarin.Forms;

namespace task.Droid
{
    [Activity( MainLauncher = false)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SQLitePCL.Batteries.Init();
            SQLitePCL.raw.FreezeProvider();
            Xamarin.Forms.Svg.Droid.SvgImage.Init(this);
            Rg.Plugins.Popup.Popup.Init(this);
            Forms.Init(this, savedInstanceState);
            DependencyService.RegisterSingleton<IThemeMode>(new TemaMobileAndroidRequest());
            DependencyService.RegisterSingleton<INotificationManager>(new AndroidNotificationManager());
            LoadApplication(new App());
            CreateNotificationFromIntent(Intent);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        protected override void OnNewIntent(Intent intent)
        {
            CreateNotificationFromIntent(intent);
        }

        void CreateNotificationFromIntent(Intent intent)
        {
            if (intent?.Extras != null)
            {
                string title = intent.GetStringExtra(AndroidNotificationManager.TitleKey);
                string message = intent.GetStringExtra(AndroidNotificationManager.MessageKey);
                DependencyService.Get<INotificationManager>().ReceiveNotification(title, message);
            }
        }
    }
}