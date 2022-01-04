using System;
using System.Threading.Tasks;
using System.Windows.Input;
using DemoApp.Models.Broker;
using DemoApp.Views.Broker;
using Xamarin.Forms;

namespace DemoApp.ViewModels.Broker
{
    public class VMRegistratBroker : ViewModels.VMNavigation.VMNavigationBar
    {
        public VMRegistratBroker()
        {
            Init();
        }

        #region Properties
        //private string _tenDangNhap;
        //public string TenDangNhap
        //{
        //    get => _tenDangNhap;
        //    set => SetProperty(ref _tenDangNhap, value);
        //}

        private string _hoDem;
        public string HoDem
        {
            get => _hoDem;
            set => SetProperty(ref _hoDem, value);
        }

        private string _ten;
        public string Ten
        {
            get => _ten;
            set => SetProperty(ref _ten, value);
        }

        private string _soDienThoai;
        public string SoDienThoai
        {
            get => _soDienThoai;
            set => SetProperty(ref _soDienThoai, value);
        }

        private string _sotkNganHang;
        public string SoTKNganHang
        {
            get => _sotkNganHang;
            set => SetProperty(ref _sotkNganHang, value);
        }

        private string _tenNganHang;
        public string TenNganHang
        {
            get => _tenNganHang;
            set => SetProperty(ref _tenNganHang, value);
        }

        #endregion
        #region Commands
        public ICommand DangKy { get; set; }
        #endregion
        #region Actions

        async void DangKyAction()
        {
            if (Vailidate())
            {
                var popup = new Views.Popup.BusyPopupPage();
                await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(popup);
                await Task.Run(async () =>
                {
                    var model = new MBorkerRS();
                    var rs = App.request.Requests(ref model, "/api/TrueData/CreateHoSoCongTacVien", new MBorkerRQ
                    {
                        Ten = Ten,
                        HoDem = HoDem,
                        SoDienThoai = SoDienThoai,
                        TaiKhoanNganHang = SoTKNganHang,
                        TenNganHang = TenNganHang,
                        GuidUser = App.dataBussiness.GetUserLogin().Id,
                    });

                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await App.Current.MainPage.DisplayAlert("Thông báo", rs ? "Đăng ký hồ sơ thành công" : model.message, "Đồng ý");
                        await App.Current.MainPage.Navigation.PopAsync();
                        foreach(var page in App.Current.MainPage.Navigation.NavigationStack)
                        {
                            if(page.GetType() == typeof(ListBorkerPage))
                            {
                                (page as ListBorkerPage).Refresh();
                            }
                        }
                    });
                    await Rg.Plugins.Popup.Services.PopupNavigation.Instance.RemovePageAsync(popup);
                });
            }
        }
        #endregion
        #region Methods
        void Init()
        { 
            DangKy = new Command(DangKyAction);
        }

        bool Vailidate()
        {
            //if (string.IsNullOrEmpty(TenDangNhap))
            //{
            //    App.Current.MainPage.DisplayAlert("Thông báo", "Vui lòng nhập tên đăng nhập!", "Đồng ý");
            //    return false;
            //}

            if (string.IsNullOrEmpty(HoDem))
            {
                App.Current.MainPage.DisplayAlert("Thông báo", "Vui lòng nhập họ đệm!", "Đồng ý");
                return false;
            }

            if (string.IsNullOrEmpty(Ten))
            {
                App.Current.MainPage.DisplayAlert("Thông báo", "Vui lòng nhập tên!", "Đồng ý");
                return false;
            }

            if (string.IsNullOrEmpty(SoDienThoai))
            {
                App.Current.MainPage.DisplayAlert("Thông báo", "Vui lòng nhập Số điện thoại!", "Đồng ý");
                return false;
            }

            if (string.IsNullOrEmpty(SoTKNganHang))
            {
                App.Current.MainPage.DisplayAlert("Thông báo", "Vui lòng nhập tài khoản ngân hàng!", "Đồng ý");
                return false;
            }

            if (string.IsNullOrEmpty(TenNganHang))
            {
                App.Current.MainPage.DisplayAlert("Thông báo", "Vui lòng nhập tên ngân hàng!", "Đồng ý");
                return false;
            }

            return true;
        }
        #endregion
    }
}
