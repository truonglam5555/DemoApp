using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using DemoApp.Models.RegitstraCredit;
using DemoApp.Models.UpdateRFID;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace DemoApp.ViewModels.RegistratCredit
{
    public class VMListAssetProfile : ViewModels.VMNavigation.VMNavigationBar
    {
        public VMListAssetProfile()
        {
            Init();
        }

        #region Properties
        public MCustomer Customer;
        private ObservableCollection<MAssetCredit> _list;
        public ObservableCollection<MAssetCredit> List
        {
            get => _list;
            set => SetProperty(ref _list, value);
        }
        #endregion

        #region Commands
        public ICommand TaoTaiSanVay { get; set; }
        public ICommand KichHoat { get; set; }
        public ICommand Refresh { get; set; }
        #endregion

        #region Actions
        async Task TaoTaiSanVayAction()
        {
            var creatAsset = new Views.RegistratCredit.CreatAssetCreditPage();
            creatAsset.mCreatAssetCredit.MaKhachHang = Customer.MaKhachHang;
            await App.Current.MainPage.Navigation.PushAsync(creatAsset);
        }

        async Task KichHoatAction(MAssetCredit assetCredit)
        {
            if (!assetCredit.IsCoFileHopDong.Value && (assetCredit.DanhSachHinhAnhHopDong == null || assetCredit.DanhSachHinhAnhHopDong.Count <= 0) && assetCredit.TrangThai == 1)
            {
                var page = new Views.RegistratCredit.ContractCreditPage();
                page.vMContractCredit._IDTaiSan = assetCredit.Id;
                await App.Current.MainPage.Navigation.PushAsync(page);
            } else if (assetCredit.TrangThai == 1 && string.IsNullOrEmpty(assetCredit.Rfid))
            {
                var page = new Views.Scanr.ScanrPage(true);
                await App.Current.MainPage.Navigation.PushModalAsync(page);
                page.Result += (s, e) => {
                    Page_Result(e, assetCredit.Id);
                };
            } else if(!string.IsNullOrEmpty(assetCredit.Rfid))
            {
                var page = new Views.RegistratCredit.HistoryConfirmAssetPage();
                page.vMHistoryConfirmAsset._IDTaiSan = assetCredit.Id;
                await App.Current.MainPage.Navigation.PushAsync(page);
            } 
        }

        void RefreshAction(RefreshView refresh)
        {
            if(refresh != null)
            {
                refresh.IsRefreshing = false;
                List.Clear();
                RequetData();
            }
        }


        private async void Page_Result(string _Idtag,string _TaiSan)
        {
            var popup = new Views.Popup.BusyPopupPage();
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(popup);
            await Task.Run(async () => {
                var model = new MAssetCreditRS();
                var rs = App.request.Requests(ref model, "/api/TrueData/UpdateRFIDHoSoTaiSanKhachHang", new MUpdateRFIDRQ
                {
                    GuidUser = App.dataBussiness.GetUserLogin().Id,
                    GuidTaiSan = _TaiSan,
                    Rfid = _Idtag
                });
                await Rg.Plugins.Popup.Services.PopupNavigation.Instance.RemovePageAsync(popup);
                Device.BeginInvokeOnMainThread(() => {
                    App.Current.MainPage.DisplayAlert("Thông báo", model.isSuccess ? "Kích hoạt thành công!" : model.message, "Đồng ý");
                    List.Clear();
                    RequetData();
                });
            });
        }
        #endregion

        #region Methods
        void Init()
        {
            _list = new ObservableCollection<MAssetCredit>();
            TaoTaiSanVay = new AsyncCommand(TaoTaiSanVayAction);
            KichHoat = new AsyncCommand<MAssetCredit>(KichHoatAction);
            Refresh = new Command<RefreshView>(RefreshAction);
            RequetData();
        }

        async void RequetData()
        {
            var popup = new Views.Popup.BusyPopupPage();
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(popup);
            await Task.Run(async () => {
                var model = new MAssetCreditRS();
                var rs = App.request.Requests(ref model, "/api/TrueData/GetDanhSachHoSoTaiSanKhachHang", new MAssetCreditRQ
                {
                    GuidUser = Customer.GuidUser,
                });
                await Rg.Plugins.Popup.Services.PopupNavigation.Instance.RemovePageAsync(popup);
                if (rs && model?.data.Count > 0)
                {
                    Device.BeginInvokeOnMainThread(() => {
                        foreach (var item in model.data)
                        {
                            List.Add(item);
                        }
                    });
                }
            });
        }

        public void RefreahData()
        {
            List.Clear();
            RequetData();
        }
        #endregion
    }
}
