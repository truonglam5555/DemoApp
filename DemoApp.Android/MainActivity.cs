using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using AndroidX.AppCompat.App;
using System.Threading.Tasks;
using Plugin.NFC;
using Android.Content;
using Android.Content.Res;
using FFImageLoading.Forms.Platform;

namespace DemoApp.Droid
{
    [Activity(Label = "DemoApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            AppCompatDelegate.DefaultNightMode = AppCompatDelegate.ModeNightNo;
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            Task.Run(() => {
                App.ScreenHeight = (int)(Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density);
                App.ScreenWidth = (int)(Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density);
                ZXing.Net.Mobile.Forms.Android.Platform.Init();
                Rg.Plugins.Popup.Popup.Init(this);
                CrossNFC.Init(this);
                CachedImageRenderer.Init(true);
            });
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override void OnBackPressed()
        {
            Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed);
        }

        protected override void AttachBaseContext(Context @base)
        {
            Configuration overrideConfiguration = new Configuration();
            overrideConfiguration = @base.Resources.Configuration;
            overrideConfiguration.SetToDefaults();
            Context context = @base.CreateConfigurationContext(overrideConfiguration);
            base.AttachBaseContext(context);
        }

        protected override void OnResume()
        {
            base.OnResume();
            CrossNFC.OnResume();
        }
        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            CrossNFC.OnNewIntent(intent);
        }
    }
}
