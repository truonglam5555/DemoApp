using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using DemoApp.Common.Utils;
using DemoApp.Models.RegitstraCredit;
using DemoApp.Views.RegistratCredit;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DemoApp.ViewModels.RegistratCredit
{
    public class VMCreatAssetCredit : VMNavigation.VMNavigationBar
    {
        public VMCreatAssetCredit()
        {
            Init();
        }
        #region Properties
        private int IdPlus = 0;

        public string MaKhachHang;

        private string _tenTaiSan;
        public string TenTaiSan
        {
            get => _tenTaiSan;
            set => SetProperty(ref _tenTaiSan, value);
        }

        private string _nhanHieu;
        public string NhanHieu
        {
            get => _nhanHieu;
            set => SetProperty(ref _nhanHieu, value);
        }

        private string _thongSoKyThuat;
        public string ThongSoKyThuat
        {
            get => _thongSoKyThuat;
            set => SetProperty(ref _thongSoKyThuat, value);
        }

        private string _giaTriTaiSan;
        public string GiaTriTaiSan
        {
            get => _giaTriTaiSan;
            set
            {
                _giaTriTaiSan = value.Length > 2 ? String.Format("{0:0,0}", double.Parse(value)) : value;
                OnPropertyChanged(nameof(GiaTriTaiSan));
            }
        }

        private string _soTienVay;
        public string SoTienVay
        {
            get => _soTienVay;
            set
            {
                _soTienVay = value.Length > 2 ? String.Format("{0:0,0}", double.Parse(value)) : value;
                OnPropertyChanged(nameof(SoTienVay));
            }
        }

        private string _laiXuatVay;
        public string LaiXuatVay
        {
            get => _laiXuatVay;
            set
            {
                //_laiXuatVay = value.Length > 2 ? String.Format("{0:0,0}", double.Parse(value)) : value;
                //OnPropertyChanged(nameof(LaiXuatVay));
                SetProperty(ref _laiXuatVay, value);
            }
        }

        private string _kyHanTraNo;
        public string KyHanTraNo
        {
            get => _kyHanTraNo;
            set
            {
                _kyHanTraNo = value;
                OnPropertyChanged(nameof(KyHanTraNo));
            }
        }

        private string _phiTraNoTruocHan;
        public string PhiTraNoTruocHan
        {
            get => _phiTraNoTruocHan;
            set
            {
                _phiTraNoTruocHan = value.Length > 2 ? String.Format("{0:0,0}", double.Parse(value)) : value;
                OnPropertyChanged(nameof(PhiTraNoTruocHan));
            }
        }

        private int _heightRequest = 0;
        public int HeightRequest
        {
            get => _heightRequest;
            set
            {
                _heightRequest = value;
                OnPropertyChanged(nameof(HeightRequest));
            }
        }

        private ObservableCollection<ImagesModel> _images;
        public ObservableCollection<ImagesModel> Images
        {
            get => _images;
            set
            {
                _images = value;
                OnPropertyChanged(nameof(Images));
            }
        }

        #endregion
        #region Commands
        public ICommand ThemAnh { get; set; }
        public ICommand ChonAnh { get; set; }
        public ICommand XoaAnh { get; set; }
        public ICommand DangKy { get; set; }
        #endregion
        #region Actions
        async void DangKyAction()
        {
            if (Vailidate())
            {
                var popup = new Views.Popup.BusyPopupPage();
                await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(popup);
                await Task.Run(async () => {

                    var listfile = App.request.UploadFileRequest(new Models.File.FileRequest_RQ
                    {
                        GuidUser = App.dataBussiness.GetUserLogin().Id
                    }, Images?.ToList()?.ConvertAll(m => m.ArrayHinh)) ;
                    if (listfile != null && listfile.isSuccess && listfile.data != null && listfile.data.Count > 0)
                    {
                        var model = new MRegitraCredit_RS();
                        var rs = App.request.Requests(ref model, "/api/TrueData/CreateHoSoTaiSanKhachHang", new MCreatAssetCredit_RQ
                        {
                            TenTaiSan = TenTaiSan,
                            MaKhachHang = MaKhachHang,
                            NhanHieu = NhanHieu,
                            ThongSoKyThuat = ThongSoKyThuat,
                            DinhGiaTaiSan = decimal.Parse(GiaTriTaiSan.Replace(",", "").Replace(",", "")),
                            SoTienChoVay = decimal.Parse(SoTienVay.Replace(",", "").Replace(",", "")),
                            LaiXuatVay = decimal.Parse(LaiXuatVay.Replace(",", "").Replace(",", "")),
                            ThoiHanTraNo = decimal.Parse(KyHanTraNo.Replace(",", "").Replace(",", "")),
                            PhiTraNoTruocHan = decimal.Parse(PhiTraNoTruocHan.Replace(",", "").Replace(",", "")),
                            DanhSachFileDinhKem = listfile.data.ConvertAll(x =>x.Id),
                            GuidUser = App.dataBussiness.GetUserLogin().Id,
                        });
                        Device.BeginInvokeOnMainThread(async () => {
                            await App.Current.MainPage.DisplayAlert("Thông báo", model.isSuccess ? "Đăng ký hồ sơ thành công" : model.message, "Đồng ý");
                            if(model.isSuccess)
                            {
                                await App.Current.MainPage.Navigation.PopAsync();
                                foreach(var page in App.Current.MainPage.Navigation.NavigationStack)
                                {
                                    if(page.GetType() == typeof(ListAssetProfilePage))
                                    {
                                        (page as ListAssetProfilePage).Refresh();
                                    }
                                }
                            }
                        });
                    }
                    await Rg.Plugins.Popup.Services.PopupNavigation.Instance.RemovePageAsync(popup);
                });
            }
        }


        private async void ThemAnhAction()
        {
            try
            {
                var result = await MediaPicker.CapturePhotoAsync();
                PickerResult(result?.FullPath);
            }
            catch { }
        }

        private async void ChonAnhAction()
        {
            try
            {
                var fileResult = await Xamarin.Essentials.MediaPicker.PickPhotoAsync(new MediaPickerOptions { Title = "Chọn Ảnh" });
                PickerResult(fileResult?.FullPath);
            }
            catch { }
        }

        private void PickerResult(string path)
         {
            IdPlus++;
            Images.Add(new ImagesModel
            {
                ID = IdPlus,
                Hinh = ImageSource.FromFile(path),
                ArrayHinh = File.ReadAllBytes(path)
            });
            HeightRequest = 150;
        }

        private void XoaAnhAction(ImagesModel image)
        {
            try
            {
                if (image != null)
                {
                    Images.Remove(Images.Where(x => x.ID == image.ID).FirstOrDefault());
                }

                HeightRequest = Images.Count <= 0 ? 0 : 150;
            }
            catch { }
        }

        #endregion
        #region Methods
        void Init()
        {
            ThemAnh = new Command(ThemAnhAction);
            ChonAnh= new Command(ChonAnhAction);
            XoaAnh = new Command<ImagesModel>(XoaAnhAction);
            DangKy = new Command(DangKyAction);
            Images = new ObservableCollection<ImagesModel>();
        }

        bool Vailidate()
        {
            if (string.IsNullOrEmpty(TenTaiSan))
            {
                App.Current.MainPage.DisplayAlert("Thông báo", "Vui lòng nhập tên tài sản!", "Đồng ý");
                return false;
            }

            if (string.IsNullOrEmpty(NhanHieu))
            {
                App.Current.MainPage.DisplayAlert("Thông báo", "Vui lòng nhập nhãn hiệu!", "Đồng ý");
                return false;
            }

            if (string.IsNullOrEmpty(GiaTriTaiSan) || decimal.Parse(GiaTriTaiSan.Replace(",", "").Replace(",", "")) < 0)
            {
                App.Current.MainPage.DisplayAlert("Thông báo", "Giá trị sản phẩm tróng hoặc không hợp lệ!", "Đồng ý");
                return false;
            }

            if (string.IsNullOrEmpty(SoTienVay) || decimal.Parse(SoTienVay.Replace(",", "").Replace(",", "")) < 0)
            {
                App.Current.MainPage.DisplayAlert("Thông báo", "Khoản vay tróng hoặc không hợp lệ!", "Đồng ý");
                return false;
            }

            if (string.IsNullOrEmpty(KyHanTraNo) || decimal.Parse(LaiXuatVay.Replace(",", "").Replace(",", "")) < 0)
            {
                App.Current.MainPage.DisplayAlert("Thông báo", "Kỳ hạn tróng hoặc không hợp lệ!", "Đồng ý");
                return false;
            }

            if (string.IsNullOrEmpty(PhiTraNoTruocHan) || decimal.Parse(KyHanTraNo.Replace(",", "").Replace(",", "")) < 0)
            {
                App.Current.MainPage.DisplayAlert("Thông báo", "Phí trả nợ trước hạn tróng hoặc không hợp lệ!", "Đồng ý");
                return false;
            }

            if (Images.Count <=1)
            {
                App.Current.MainPage.DisplayAlert("Thông báo", "Hình ảnh tài sản phải ít nhất 2 tấm!", "Đồng ý");
                return false;
            }

            //if (_MatTruoc == null || _MatSau == null)
            //{
            //    App.Current.MainPage.DisplayAlert("Thông báo", "Vui lòng nhập anh CMND/CCCD!", "Đồng ý");
            //    return false;
            //}

            //if (string.IsNullOrEmpty(SoTKNganHang))
            //{
            //    App.Current.MainPage.DisplayAlert("Thông báo", "Vui lòng nhập tài khoản ngân hàng!", "Đồng ý");
            //    return false;
            //}

            //if (string.IsNullOrEmpty(TenNganHang))
            //{
            //    App.Current.MainPage.DisplayAlert("Thông báo", "Vui lòng nhập tên ngân hàng!", "Đồng ý");
            //    return false;
            //}

            return true;
        }
        #endregion
    }

    public class ImagesModel
    {
        public int ID { get; set; }
        public ImageSource Hinh { get; set; }
        public byte[] ArrayHinh { get; set; }
    }
}
