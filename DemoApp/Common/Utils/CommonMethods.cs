using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DemoApp.Services.Interface;
using Plugin.NFC;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DemoApp.Common.Utils
{
    public static class CommonMethods
    {
        public static string GetDescription<T>(this T enumerationValue)
           where T : struct
        {
            var type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException($"{nameof(enumerationValue)} must be of Enum type", nameof(enumerationValue));
            }
            var memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo.Length > 0)
            {
                var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return enumerationValue.ToString();
        }

        public static bool IsPhoneNumber(string number)
        {

            try
            {
                if (string.IsNullOrEmpty(number))
                {
                    return false;
                }

                if (number[0] == '0' && number.Length > 10)
                {
                    return false;
                }

                if (number[0] == '8' && number.Length > 11)
                {
                    return false;
                }

                var r = new Regex(@"^((0[3|8|9|7|5])+([0-9]{8}))|((84[3|8|9|7|5])+([0-9]{8}))");

                return r.IsMatch(number);

            }
            catch
            {
                return false;
            }
        }

        public static string ByteArrayToHexString(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", "");
        }

        public static bool ValidateNFC()
        {
            if (CrossNFC.IsSupported && CrossNFC.Current.IsAvailable)
            {
                if (CrossNFC.Current.IsEnabled)
                {
                    return true;
                }
                else
                {
                    App.Current.MainPage.DisplayAlert("Thông báo", "Bạn chưa bật kết nối NFC, vui lòng vào cài đặt điện thoại để bật", "Đóng");
                }
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Thông báo", "Thiết bị của bạn không hỗ trợ kết nối NFC", "Đóng");
            }
            return false;
        }

        private static IDeviceLocation checkLocation = DependencyService.Get<IDeviceLocation>();
        public static async Task<(bool, double, double)> GetPosition(bool IslosePopup = true)
        {
            bool result = true;
            double Lat = 0, Lng = 0;
            try
            {
                var busyPage = new Views.Popup.BusyPopupPage();
                var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                if (status == PermissionStatus.Unknown || status == PermissionStatus.Denied)
                {
                    await Device.InvokeOnMainThreadAsync(async () =>
                    {
                        await App.Current.MainPage.DisplayAlert("Yêu cầu quyền truy cập"
                                                                , "Ứng dụng cần xác định vị trí thao tác của bạn\nVui lòng cấp quyền trong " + (Device.RuntimePlatform == Device.iOS ? "\"Setting -> Tên ứng dụng -> Location\"" : "\"Setting -> Apps\"")
                                                                , "Đóng");

                        var results = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

                        if (results == PermissionStatus.Granted)
                        {
                            await Device.InvokeOnMainThreadAsync(async () =>
                            {
                                await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(busyPage);

                                await Task.Run(async () =>
                                {
                                    var request = new Xamarin.Essentials.GeolocationRequest(Xamarin.Essentials.GeolocationAccuracy.Best);
                                    var location = await Xamarin.Essentials.Geolocation.GetLocationAsync(request);
                                    if (!location.IsFromMockProvider)
                                    {
                                        Lat = location.Latitude;
                                        Lng = location.Longitude;
                                    }
                                    else
                                    {
                                        await Device.InvokeOnMainThreadAsync(async () =>
                                        {
                                            await App.Current.MainPage.DisplayAlert("Thông báo", "Vui lòng sử dụng vị trí thật", "Đóng");
                                            if (IslosePopup)
                                                await Rg.Plugins.Popup.Services.PopupNavigation.Instance.RemovePageAsync(busyPage);
                                        });
                                    }
                                });
                            });
                        }
                        else
                        {
                            await App.Current.MainPage.DisplayAlert("Yêu cầu quyền truy cập"
                                                                , "Ứng dụng cần xác định vị trí thao tác của bạn\nVui lòng cấp quyền trong " + (Device.RuntimePlatform == Device.iOS ? "\"Setting -> Tên ứng dụng -> Location\"" : "\"Setting -> Apps\"")
                                                                , "Đóng");
                            result = false;
                        }
                    });

                }
                else
                {
                    if (checkLocation.isGpsAvailable())
                    {
                        var results = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
                        if (results == PermissionStatus.Granted)
                        {
                            await Device.InvokeOnMainThreadAsync(async () =>
                            {
                                await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(busyPage);

                                await Task.Run(async () =>
                                {
                                    var request = new Xamarin.Essentials.GeolocationRequest(Xamarin.Essentials.GeolocationAccuracy.Best);
                                    var location = await Xamarin.Essentials.Geolocation.GetLocationAsync(request);
                                    if (!location.IsFromMockProvider)
                                    {
                                        Lat = location.Latitude;
                                        Lng = location.Longitude;
                                    }
                                    else
                                    {
                                        await Device.InvokeOnMainThreadAsync(async () =>
                                        {
                                            await App.Current.MainPage.DisplayAlert("Thông báo", "Vui lòng sử dụng vị trí thật", "Đóng");
                                            if (IslosePopup)
                                                await Rg.Plugins.Popup.Services.PopupNavigation.Instance.RemovePageAsync(busyPage);
                                        });
                                    }
                                });
                            });
                        }
                        else
                        {
                            await App.Current.MainPage.DisplayAlert("Yêu cầu quyền truy cập"
                                                                , "Ứng dụng cần xác định vị trí thao tác của bạn\nVui lòng cấp quyền trong " + (Device.RuntimePlatform == Device.iOS ? "\"Setting -> Tên ứng dụng -> Location\"" : "\"Setting -> Apps\"")
                                                                , "Đóng");
                            result = false;
                        }
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Thông báo", "Ứng dụng cần xác định vị trí thao tác của bạn\n Vui lòng bật định vị (GPS)", "Đóng");
                        result = false;
                    }
                }
                if (IslosePopup)
                    await Rg.Plugins.Popup.Services.PopupNavigation.Instance.RemovePageAsync(busyPage);
            }
            catch
            {
                result = false;
            }
            return (result, Lat, Lng);
        }
    }
}
