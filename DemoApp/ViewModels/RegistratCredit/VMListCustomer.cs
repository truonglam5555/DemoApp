using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using DemoApp.Models.RegitstraCredit;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace DemoApp.ViewModels.RegistratCredit
{
    public class VMListCustomer : ViewModels.VMNavigation.VMNavigationBar
    {
        public VMListCustomer()
        {
            Init();
        }

        #region Properties
        private ObservableCollection<MCustomer> _list;
        public ObservableCollection<MCustomer> List
        {
            get => _list;
            set => SetProperty(ref _list, value);
        }
        #endregion

        #region Actions
        async Task ChonKhanhHang(MCustomer customer)
        {
            if (customer != null)
            {
                var creatAsset = new Views.RegistratCredit.ListAssetProfilePage();
                creatAsset.vMListAssetProfile.Customer = customer;
                await App.Current.MainPage.Navigation.PushAsync(creatAsset);
            }
        }
        #endregion

        #region Commads
        public ICommand ChonKhach { get; set; }
        #endregion

        #region Methods
        void Init()
        {
            _list = new ObservableCollection<MCustomer>();
            ChonKhach = new AsyncCommand<MCustomer>(ChonKhanhHang);
            RequetData();
        }

        async void RequetData()
        {
            var popup = new Views.Popup.BusyPopupPage();
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(popup);
            await Task.Run(async () => {
                var model = new MCustomer_RS();
                var rs = App.request.Requests(ref model, "/api/TrueData/GetDanhSachHoSoKhachHang", new MCustomer_RQ {
                    GuidUser = App.dataBussiness.GetUserLogin().Id,
                });
                await Rg.Plugins.Popup.Services.PopupNavigation.Instance.RemovePageAsync(popup);
                if (rs && model?.data.Count > 0)
                {
                    Device.BeginInvokeOnMainThread(() => {
                        foreach(var item in model.data)
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
