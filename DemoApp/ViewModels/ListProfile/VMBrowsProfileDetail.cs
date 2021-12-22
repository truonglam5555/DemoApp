using System;
using System.Threading.Tasks;
using DemoApp.Models.Base;
using DemoApp.Models.ListProfile;
using Xamarin.Forms;

namespace DemoApp.ViewModels.ListProfile
{
    public class VMBrowsProfileDetail :ViewModels.VMNavigation.VMNavigationBar
    {
        public VMBrowsProfileDetail()
        {
            Init();
        }

        #region Properties
        public int _TrangThai = 1;

        private string _tienChoVay;
        public string TienChoVay
        {
            get => _tienChoVay;
            set
            {
                _tienChoVay = value.Length > 2 ? String.Format("{0:0,0}", double.Parse(value)) : value;
                OnPropertyChanged(nameof(TienChoVay));
            }
        }

        private MBrowProfile _browProfile;

        public MBrowProfile BrowProfile
        {
            get => _browProfile;
            set => SetProperty(ref _browProfile, value);
        }
        #endregion

        #region Command
        public Command Duyet { get; set; }
        #endregion

        #region Actions
        async void DuyetAction()
        {
            if(Validate())
            {
                var popup = new Views.Popup.BusyPopupPage();
                await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(popup);
                await Task.Run(async () => {
                    var model = new MBrowserRS();
                    var rs = App.request.Requests(ref model, "/api/TrueData/PheDuyetHoSoTaiSanQuanTri", new MBrowserRQ
                    {
                        Id = BrowProfile.Id,
                        SoTienChoVay = decimal.Parse(TienChoVay.Replace(",", "").Replace(",", "")),
                        TrangThai = _TrangThai,
                        GuidUser = App.dataBussiness.GetUserLogin().Id
                    });
                    await Task.Delay(500);
                    await Rg.Plugins.Popup.Services.PopupNavigation.Instance.RemovePageAsync(popup);
                    if (rs && model?.data != null)
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            App.Current.MainPage.Navigation.PopAsync();
                        });
                    }
                });
            }
        }
        #endregion

        #region Methods
        void Init()
        {
            Duyet = new Command(DuyetAction);
        }

        bool Validate()
        {
            if(_TrangThai == 1)
            {
                if(string.IsNullOrEmpty(TienChoVay))
                {
                    App.Current.MainPage.DisplayAlert("Thông báo", "Vui lòng nhập tiền cho vay!", "Đồng ý");
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}
