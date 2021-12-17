using System;
using Android.Content;
using DemoApp.Droid.Service;
using DemoApp.Services.Interface;
using Xamarin.Forms;

[assembly: Dependency(typeof(LocationShare))]
namespace DemoApp.Droid.Service
{
    public class LocationShare : IDeviceLocation
    {

        public bool isGpsAvailable()
        {
            Android.Locations.LocationManager manager = (Android.Locations.LocationManager)Android.App.Application.Context.GetSystemService(Android.Content.Context.LocationService);
            return manager.IsProviderEnabled(Android.Locations.LocationManager.GpsProvider);
        }

        public void OpenSettings()
        {
            Intent intent = new Intent(Android.Provider.Settings.ActionLocat‌​ionSourceSettings);
            intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.NewTask);

            try
            {
                Android.App.Application.Context.StartActivity(intent);

            }
            catch (ActivityNotFoundException activityNotFoundException)
            {
                System.Diagnostics.Debug.WriteLine(activityNotFoundException.Message);
                Android.Widget.Toast.MakeText(Android.App.Application.Context, "Lỗi: Gps", Android.Widget.ToastLength.Short).Show();
            }
        }
    }
}
