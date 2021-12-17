using System;
using DemoApp.Droid.Service;
using DemoApp.Services.Interface;

[assembly: Xamarin.Forms.Dependency(typeof(DeviceStatusBar))]
namespace DemoApp.Droid.Service
{
    public class DeviceStatusBar : IDeviceStatuBar
    {
        public DeviceStatusBar(){}

        public int GetHeight()
        {
            int statusBarHeight = -1;
            try
            {
                int resourceId = Xamarin.Essentials.Platform.CurrentActivity.Resources.GetIdentifier("status_bar_height", "dimen", "android");
                if (resourceId > 0)
                {
                    statusBarHeight = (int)(Xamarin.Essentials.Platform.CurrentActivity.Resources.GetDimensionPixelOffset(resourceId) / Xamarin.Essentials.Platform.CurrentActivity.Resources.DisplayMetrics.Density);
                }
            }
            catch (Exception ex)
            {
                var exx = ex.Message;
            }
            return statusBarHeight;
        }
    }
}
