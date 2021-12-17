using System;
using DemoApp.iOS.Service;
using DemoApp.Services.Interface;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(DeviceStatusBar))]
namespace DemoApp.iOS.Service
{
    public class DeviceStatusBar : IDeviceStatuBar
    {
        public int GetHeight()
        {
            return(int)UIApplication.SharedApplication.StatusBarFrame.Height;
        }
    }
}
