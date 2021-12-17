using System;
namespace DemoApp.Services.Interface
{
    public interface IDeviceLocation
    {
        bool isGpsAvailable();

        void OpenSettings();
    }
}
