using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using DemoApp.Models.Broker;
using Xamarin.Forms;

namespace DemoApp.ViewModels.Broker
{
    public class VMListBorker : ViewModels.VMNavigation.VMNavigationBar
    {
        public VMListBorker()
        {
            Init();
        }


        #region Properties
        private ObservableCollection<MBorker> _list;
        public ObservableCollection<MBorker> List
        {
            get => _list;
            set => SetProperty(ref _list, value);
        }

        #endregion

        #region Commands
        public ICommand Refresh { get; set; }
        public ICommand ChonDuyet { get; set; }
        public ICommand DangKyBroker { get; set; }
        #endregion

        #region Actions

        public void RefreshAction(RefreshView refresh)
        {
            if (refresh != null)
            {
                refresh.IsRefreshing = false;
            }
            RequetData();
        }

        async void DangKyBrokerAction()
        {
            var page = new Views.Broker.RegistratBrokerPage();
            await App.Current.MainPage.Navigation.PushAsync(page);
        }
        #endregion

        #region Methods
        void Init()
        {
            _list = new ObservableCollection<MBorker>();
            Refresh = new Command<RefreshView>(RefreshAction);
            DangKyBroker = new Command(DangKyBrokerAction);
            RequetData();
        }

        async void RequetData()
        {
            List.Clear();
            var popup = new Views.Popup.BusyPopupPage();
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(popup);
            await Task.Run(async () => {
                var model = new MBorkerRS();
                var rs = App.request.Requests(ref model, "/api/TrueData/GetDanhSachHoSoCongTacVien", new MBorkerListRQ
                {
                    GuidUser = App.dataBussiness.GetUserLogin().Id,
                });
                await Rg.Plugins.Popup.Services.PopupNavigation.Instance.RemovePageAsync(popup);
                if (rs && model?.data.Count > 0)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
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
