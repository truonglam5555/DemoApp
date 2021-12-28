using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using DemoApp.Models.ListProfile;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace DemoApp.ViewModels.ListProfile
{
    public class VMBrowsProfile :  ViewModels.VMNavigation.VMNavigationBar
    {
        public VMBrowsProfile()
        {
            Init();
        }

        #region Properties
        private int SaveSelect = 1;
        private ObservableCollection<MBrowProfile> _list;
        public ObservableCollection<MBrowProfile> List
        {
            get => _list;
            set => SetProperty(ref _list, value);
        }

        private string _nameSelect = "Chờ phê duyệt";

        public string NameSelect
        {
            get => _nameSelect;
            set => SetProperty(ref _nameSelect, value);
        }

        #endregion

        #region Commands
        public ICommand ChonLoai { get; set; }
        public ICommand Refresh { get; set; }
        public ICommand ChonDuyet { get; set; }
        #endregion

        #region Actions
        async Task ChonLoaiAction()
        {
            var chonloaiPopup = new Views.Popup.SelectTypePopup();
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(chonloaiPopup);
            chonloaiPopup.Result += ChonloaiPopup_Result; ;
        }

        async Task ChonDuyetAction(MBrowProfile browProfile)
        {
            if(browProfile != null && browProfile.TrangThai == (int)Enums.EnumList.TrangThaiHoSoTaiSanEnums.ChoPheDuyet)
            {
                var page = new Views.ListProfile.BrowsProfileDetailPage();
                page.vMBrowsProfileDetail.BrowProfile = browProfile;
                await App.Current.MainPage.Navigation.PushAsync(page);
            }
            else
            {
                var page = new Views.ListProfile.BrowsProfileDetailPage(false);
                page.vMBrowsProfileDetail.BrowProfile = browProfile;
                await App.Current.MainPage.Navigation.PushAsync(page);
            }
        }

        private void ChonloaiPopup_Result(object sender, Views.Popup.SelecType e)
        {
            NameSelect = e.Ten;
            SaveSelect = e.ID;
            RequetData(SaveSelect);
        }

        void RefreshAction(RefreshView refresh)
        {
            if(refresh != null)
            {
                refresh.IsRefreshing = false;
                RequetData(SaveSelect);
            }
        }
        #endregion

        #region Methods
        void Init()
        {
            _list = new ObservableCollection<MBrowProfile>();
            ChonLoai = new AsyncCommand(ChonLoaiAction);
            Refresh = new Command<RefreshView>(RefreshAction);
            ChonDuyet = new AsyncCommand<MBrowProfile>(ChonDuyetAction);
            RequetData(SaveSelect);
        }

        async void RequetData(int _TrangThai = 0)
        {
            List.Clear();
            var popup = new Views.Popup.BusyPopupPage();
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(popup);
            await Task.Run(async () => {
                var model = new MBrowProfileRS();
                var rs = App.request.Requests(ref model, "/api/TrueData/GetDanhSachHoSoTaiSanQuanTri", new MBrowProfileRQ
                {
                    TrangThai = _TrangThai,
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

        public void RefreshData()
        {
            RequetData(SaveSelect);
        }
        #endregion
    }
}
