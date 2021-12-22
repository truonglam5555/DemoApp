using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DemoApp.ViewModels.RegistratCredit
{
    public class VMContractCredit : ViewModels.VMNavigation.VMNavigationBar
    {
        public VMContractCredit()
        {
            Init();
        }

        #region Properties
        private int IdPlus = 0;
        public string _IDTaiSan;
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

        #endregion

        #region Commands
        public ICommand ThemAnh { get; set; }
        public ICommand ChonAnh { get; set; }
        public ICommand XoaAnh { get; set; }
        #endregion

        #region Actions
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
            //HeightRequest = 150;
        }

        private void XoaAnhAction(ImagesModel image)
        {
            try
            {
                if (image != null)
                {
                    Images.Remove(Images.Where(x => x.ID == image.ID).FirstOrDefault());
                }
                //HeightRequest = Images.Count <= 0 ? 0 : 150;
            }
            catch { }
        }
        #endregion

        #region Methods
        async void PustContrack()
        {
            var popup = new Views.Popup.BusyPopupPage();
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(popup);
            await Task.Run(async () => {

                var listfile = App.request.UploadFileRequest(new Models.File.FileRequest_RQ
                {
                    GuidUser = App.dataBussiness.GetUserLogin().Id
                }, Images?.ToList()?.ConvertAll(m => m.ArrayHinh));
                if (listfile != null && listfile.isSuccess && listfile.data != null && listfile.data.Count > 0)
                {
                    Device.BeginInvokeOnMainThread(async () => {
                        //await App.Current.MainPage.DisplayAlert("Thông báo", model.isSuccess ? "Đăng ký hồ sơ thành công" : model.message, "Đồng ý");
                        //if (model.isSuccess)
                        //{
                        //}
                    });
                }
                await Rg.Plugins.Popup.Services.PopupNavigation.Instance.RemovePageAsync(popup);
            });
        }

        void Init()
        {
            _images = new ObservableCollection<ImagesModel>();
            ThemAnh = new Command(ThemAnhAction);
            ChonAnh = new Command(ChonAnhAction);
            XoaAnh = new Command<ImagesModel>(XoaAnhAction);
        }
        #endregion
    }
}
