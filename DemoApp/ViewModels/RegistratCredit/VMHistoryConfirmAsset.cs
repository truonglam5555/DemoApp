using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DemoApp.Models.RegitstraCredit;
using Xamarin.Forms;

namespace DemoApp.ViewModels.RegistratCredit
{
    public class VMHistoryConfirmAsset : ViewModels.VMNavigation.VMNavigationBar
    {
        public VMHistoryConfirmAsset()
        {
            Init();
        }
        #region Properties

        public string _IDTaiSan;

        private ObservableCollection<MHistoryConfirm> _list;
        public ObservableCollection<MHistoryConfirm> List
        {
            get => _list;
            set => SetProperty(ref _list, value);
        }
        #endregion

        #region Commands

        #endregion

        #region Actions

        #endregion

        #region Methods
        void Init()
        {
            _list = new ObservableCollection<MHistoryConfirm>();
            RequetData();
        }

        async void RequetData()
        {
            var popup = new Views.Popup.BusyPopupPage();
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(popup);
            await Task.Run(async () => {
                var model = new MHistoryConfirmRS();
                var rs = App.request.Requests(ref model, "/api/TrueData/GetDanhSachLichSuXacThucHoSoKhachHang", new MHistoryConfirmRQ
                {
                    GuidTaiSan = _IDTaiSan
                });
                await Rg.Plugins.Popup.Services.PopupNavigation.Instance.RemovePageAsync(popup);
                if (rs && model?.data.Count > 0)
                {
                    model.data.FirstOrDefault().Isfrish = true;
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
