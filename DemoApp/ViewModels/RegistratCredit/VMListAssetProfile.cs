using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using DemoApp.Models.RegitstraCredit;
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

        async Task KichHoatAction()
        {
            var page = new Views.Scanr.ScanrPage(true);
            await App.Current.MainPage.Navigation.PushModalAsync(page);
            page.Result += Page_Result;
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

        private void Page_Result(object sender, string e)
        {
            
        }
        #endregion

        #region Methods
        void Init()
        {
            _list = new ObservableCollection<MAssetCredit>();
            TaoTaiSanVay = new AsyncCommand(TaoTaiSanVayAction);
            KichHoat = new AsyncCommand(KichHoatAction);
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
        #endregion
    }
}
