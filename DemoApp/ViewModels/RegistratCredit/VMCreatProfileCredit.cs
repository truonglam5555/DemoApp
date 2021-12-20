using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using DemoApp.Common.Utils;
using DemoApp.Models.RegitstraCredit;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DemoApp.ViewModels.RegistratCredit
{
    public class VMCreatProfileCredit : ViewModels.VMNavigation.VMNavigationBar
    {
        public VMCreatProfileCredit()
        {
            Init();
        }
        #region Properties
        private string _tenDangNhap;
        public string TenDangNhap
        {
            get => _tenDangNhap;
            set => SetProperty(ref _tenDangNhap, value);
        }

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

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _diaChi;
        public string DiaChi
        {
            get => _diaChi;
            set => SetProperty(ref _diaChi, value);
        }

        private string _soCMND;
        public string SoCMND
        {
            get => _soCMND;
            set => SetProperty(ref _soCMND, value);
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

        private Xamarin.Forms.ImageSource _mattruoc;
        private byte[] _MatTruoc;

        public Xamarin.Forms.ImageSource MatTruoc
        {
            get => _mattruoc;
            set => SetProperty(ref _mattruoc, value);
        }

        private bool _isvisibleMatTruoc = true;

        public bool IsvisibleMatTruoc
        {
            get => _isvisibleMatTruoc;
            set => SetProperty(ref _isvisibleMatTruoc, value);
        }

        private Xamarin.Forms.ImageSource _matsau;
        private byte[] _MatSau;

        public Xamarin.Forms.ImageSource MatSau
        {
            get => _matsau;
            set => SetProperty(ref _matsau, value);
        }

        private bool _isvisibleMatSau = true;

        public bool IsvisibleMatSau
        {
            get => _isvisibleMatTruoc;
            set => SetProperty(ref _isvisibleMatSau, value);
        }

        #endregion
        #region Commands
        public ICommand ChupMatTruoc { get; set; }
        public ICommand ChupMatSau { get; set; }
        public ICommand DangKy { get; set; }
        #endregion
        #region Actions
        async void ChupMatTruocAction()
        {
            var result = await MediaPicker.CapturePhotoAsync();
            if (result != null)
            {
                var item = await result.OpenReadAsync();
                MatTruoc = ImageSource.FromFile(result.FullPath);
                _MatTruoc = CommonMethods.streamToByteArray(item);
                IsvisibleMatTruoc = false;
            }
        }

        async void ChupMatSauAction()
        {
            var result = await MediaPicker.CapturePhotoAsync();
            if (result != null)
            {
                var item = await result.OpenReadAsync();
                MatSau = ImageSource.FromFile(result.FullPath);
                _MatSau = CommonMethods.streamToByteArray(item);
                IsvisibleMatSau = false;
            }
        }

        async void DangKyAction()
        {
            if(Vailidate())
            {
                var popup = new Views.Popup.BusyPopupPage();
                await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(popup);
                await Task.Run(async () => {
                    var _listFile = new List<byte[]>();
                    _listFile.Add(_MatTruoc);
                    _listFile.Add(_MatSau);
                    var listfile = App.request.UploadFileRequest(new Models.File.FileRequest_RQ
                    {
                        GuidUser = App.dataBussiness.GetUserLogin().Id
                    }, _listFile);
                    if(listfile.isSuccess && listfile?.data.Count > 0)
                    {
                        var model = new MRegitraCredit_RS();
                        var rs = App.request.Requests(ref model, "/api/TrueData/CreateHoSoKhachHang", new MRegitraCredit_RQ{
                            TenDangNhap = TenDangNhap,
                            Ten = Ten,
                            HoDem = HoDem,
                            SoDienThoai = SoDienThoai,
                            Email = Email,
                            DiaChi = DiaChi,
                            SoCMND = SoCMND,
                            CMNDMatTruoc = listfile.data.FirstOrDefault().Id,
                            CMNDMatSau = listfile.data.LastOrDefault().Id,
                            TaiKhoanNganHang = SoTKNganHang,
                            TenNganHang = TenNganHang,
                            GuidUser = App.dataBussiness.GetUserLogin().Id,
                        });

                        Device.BeginInvokeOnMainThread(async () => {
                            await App.Current.MainPage.DisplayAlert("Thông báo", rs ? "Đăng ký hồ sơ thành công" : model.message, "Đồng ý");
                            await App.Current.MainPage.Navigation.PopAsync();
                        });
                    }
                    await Rg.Plugins.Popup.Services.PopupNavigation.Instance.RemovePageAsync(popup);
                });
            }
        }
        #endregion
        #region Methods
        void Init()
        {
            ChupMatTruoc = new Command(ChupMatTruocAction);
            ChupMatSau = new Command(ChupMatSauAction);
            DangKy = new Command(DangKyAction);
        }

        bool Vailidate()
        {
            if(string.IsNullOrEmpty(TenDangNhap))
            {
                App.Current.MainPage.DisplayAlert("Thông báo", "Vui lòng nhập tên đăng nhập!", "Đồng ý");
                return false;
            }
            if(string.IsNullOrEmpty(HoDem))
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

            if (string.IsNullOrEmpty(DiaChi))
            {
                App.Current.MainPage.DisplayAlert("Thông báo", "Vui lòng nhập dia chi!", "Đồng ý");
                return false;
            }

            if (string.IsNullOrEmpty(SoCMND))
            {
                App.Current.MainPage.DisplayAlert("Thông báo", "Vui lòng nhập CMND/CCCD!", "Đồng ý");
                return false;
            }

            if (_MatTruoc == null || _MatSau == null)
            {
                App.Current.MainPage.DisplayAlert("Thông báo", "Vui lòng nhập anh CMND/CCCD!", "Đồng ý");
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
