using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using DemoApp.Common.MarkupExtension;
using DemoApp.ViewModels.Scanr;
using Plugin.NFC;
using Xamarin.Forms;

namespace DemoApp.Views.Scanr
{
    public partial class ScanrPage : ContentPage
    {
        VMScanr vMScanr;
        public ScanrPage()
        {
            InitializeComponent();
            vMScanr = new VMScanr();
            this.BindingContext = vMScanr;
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() => {
                //vMScanr.ShowResult = false;
                if (vMScanr.ShowScanStageBarCode && CrossNFC.IsSupported && CrossNFC.Current.IsAvailable)
                {
                    if (CrossNFC.IsSupported && CrossNFC.Current.IsAvailable)
                    {
                        if (CrossNFC.Current.IsEnabled)
                        {
                            vMScanr.ShowScanStageBarCode = false;
                            vMScanr.ShowScanStage = true;
                            IconChanged.Source = ImageSource.FromResource("OB.TrueData.Resources.Images.qr_code_icon.jpg", typeof(EmbeddedImageResource).GetTypeInfo().Assembly);
                            IconChanged.WidthRequest = 32;
                            IconChanged.HeightRequest = 32;
                            Task.Run(() => {
                                if (Common.Utils.CommonMethods.ValidateNFC())
                                {
                                    Plugin.NFC.CrossNFC.Current.StartListening();
                                }
                            });
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
                }
                else
                {
                    vMScanr.ShowScanStageBarCode = true;
                    vMScanr.ShowScanStage = false;
                    if (CrossNFC.IsSupported && CrossNFC.Current.IsAvailable)
                    {
                        IconChanged.Source = ImageSource.FromResource("OB.TrueData.Resources.Images.NFC_CARDHAND.png", typeof(EmbeddedImageResource).GetTypeInfo().Assembly);
                        IconChanged.WidthRequest = 40;
                        IconChanged.HeightRequest = 40;
                        Task.Run(() => {
                            Plugin.NFC.CrossNFC.Current.StopListening();
                        });
                    }
                }
            });
        }

        void scanView_OnScanResult(ZXing.Result result)
        {
            vMScanr.ShowScanStageBarCode = false;
            vMScanr.StrStickID = result.Text;
            vMScanr.RequestdetailJoumey(vMScanr.StrStickID, () => {
                vMScanr.ShowScanStageBarCode = true;
            });
        }

        void btnNavBarBack_Clicked(System.Object sender, System.EventArgs e)
        {
        }
    }
}
