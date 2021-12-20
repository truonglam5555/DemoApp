using System;
using System.Threading.Tasks;
using DemoApp.Common.Utils;
using Plugin.NFC;
using Xamarin.Forms;

namespace DemoApp.ViewModels.Scanr
{
    public class VMScanr : Xamarin.CommunityToolkit.ObjectModel.ObservableObject
    {
        public event EventHandler<string> ResultTag;
        public VMScanr()
        {
            MessagingCenter.Instance.Subscribe<byte[]>(this,"NFCMessageReceived_ScanrPage", RequestProductDetail);
            if (CrossNFC.IsSupported && CrossNFC.Current.IsAvailable)
            {
                if (CrossNFC.Current.IsEnabled)
                {
                    ShowScanStage = true;
                    ShowButtonSelect = true;
                    Task.Run(() =>
                    {
                        if (Common.Utils.CommonMethods.ValidateNFC())
                        {
                            CrossNFC.Current.StartListening();
                        }
                    });
                }
                else
                {
                    ShowScanStage = false;
                    ShowButtonSelect = true;
                    ShowScanStageBarCode = true;
                    App.Current.MainPage.DisplayAlert("Thông báo", "Bạn chưa bật kết nối NFC, vui long vào cài đặt điện thoại để bật", "Đóng");
                }
            }
            else
            {
                ShowButtonSelect = true;
                ShowScanStage = false;
                ShowScanStageBarCode = true;
            }
        }



        #region Properties

        public bool IsResult;

        private bool _showScanStage = false;
        public bool ShowScanStage
        {
            get => _showScanStage;
            set
            {
                SetProperty(ref _showScanStage, value);
            }
        }

        private bool _showScanStageBarCode = false;
        public bool ShowScanStageBarCode
        {
            get => _showScanStageBarCode;
            set
            {
                SetProperty(ref _showScanStageBarCode, value);
            }
        }

        private bool _showButtonSelect;
        public bool ShowButtonSelect
        {
            get => _showButtonSelect;
            set
            {
                SetProperty(ref _showButtonSelect, value);
            }
        }

        private byte[] _stickID;

        public byte[] StickID
        {
            get => _stickID;
            set
            {
                SetProperty(ref _stickID, value);
                StrStickID = Common.Utils.CommonMethods.ByteArrayToHexString(_stickID);
            }
        }

        public string StrStickID { get; set; }
        #endregion

        #region Commands
        #endregion

        #region Actions
        #endregion

        #region Method
        private void RequestProductDetail(byte[] tagID)
        {
            StickID = tagID;
        }

        public async void RequestdetailJoumey(string strStickID, Action action = null)
        {
            if(!IsResult)
            {
                var positionResponse = await CommonMethods.GetPosition(false);
                if (!positionResponse.Item1)
                {
                    positionResponse.Item2 = 10.762622;
                    positionResponse.Item3 = 106.660172;
                }
                await Task.Run(async () => {
                    //var model = new MMThongTinViewHanhTrinh_RS();
                    //var rs = App.request.RequestHanhTrinh(ref model, "/api/TrueData/ViewThongTinHanhTrinh", new MMThongTinViewHanhTrinh_RQ
                    //{
                    //    rfid = strStickID,
                    //    tenThietBi = Xamarin.Essentials.DeviceInfo.Name,
                    //    lat = positionResponse.Item2,
                    //    lng = positionResponse.Item3
                    //});
                    //await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAllAsync();
                    //Device.BeginInvokeOnMainThread(() => {
                    //    if (rs && model.Data != null && model.isSuccess && model.Data.Count > 0)
                    //    {
                    //        ThongTinHanhTrinh = model.Data.FirstOrDefault();
                    //        ShowScanStage = false;
                    //        ShowScanStageBarCode = false;
                    //        ShowResult = true;
                    //    }
                    //    else
                    //    {
                    //        ThongTinHanhTrinh = new MThongTinViewHanhTrinh
                    //        {
                    //            TrangThaiHanhTrinh = -1,
                    //        };
                    //        ShowScanStage = false;
                    //        ShowScanStageBarCode = false;
                    //        ShowResult = true;
                    //        action?.Invoke();
                    //    }
                    //});
                });
            }
            else
            {
                ResultTag?.Invoke(null, strStickID);
            }
        }
        #endregion
    }
}
