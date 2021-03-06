using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using DemoApp.Models.Broker;
using DemoApp.Models.Base;
using System.Collections.Generic;
using System.Linq;

namespace DemoApp.ViewModels.Home
{
    public class VMHome : ViewModels.VMNavigation.VMNavigationBar
    {
        public VMHome()
        {
            Init();
        }

        #region Properties
        private string _nameUser;
        public string NameUser
        {
            get => _nameUser;
            set => SetProperty(ref _nameUser, value);
        }

        private ObservableCollection<MFunctionOfUser> _list;

        public ObservableCollection<MFunctionOfUser> List
        {
            get => _list;
            set => SetProperty(ref _list, value);
        }
        #endregion

        #region Commands

        #endregion

        #region Actions
        async Task BrowseprofilesAction()
        {
            if (Common.Utils.CommonMethods.CheckInternet())
            {
                var page = new Views.ListProfile.BrowsProfilePage();
                await App.Current.MainPage.Navigation.PushAsync(page);
            }
        }

        async Task CreatProfileCredit()
        {
            if (Common.Utils.CommonMethods.CheckInternet())
            {
                var page = new Views.RegistratCredit.RsgistraCreditPage();
                await App.Current.MainPage.Navigation.PushAsync(page);
            }
        }

        async Task ListProfileCredit()
        {
            if (Common.Utils.CommonMethods.CheckInternet())
            {
                var page = new Views.RegistratCredit.ListCustomerPage();
                await App.Current.MainPage.Navigation.PushAsync(page);
            }
        }

        async Task LogoutAction()
        {
            if (Common.Utils.CommonMethods.CheckInternet())
            {
                App.dataBussiness.DeleteAllRow<Models.Accoun.MLogin>();
                await App.Current.MainPage.Navigation.PopAsync();
            }
        }


        async Task ShareAction()
        {
            var popup = new Views.Popup.BusyPopupPage();
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(popup);
            await Task.Run(async () => {
                var model = new MBaseResponse<List<string>>();
                var rs = App.request.Requests(ref model, "/api/TrueData/GetLinkChiaSeApp", new MBorkerListRQ
                {
                    GuidUser = App.dataBussiness.GetUserLogin().Id,
                });
                await Rg.Plugins.Popup.Services.PopupNavigation.Instance.RemovePageAsync(popup);
                if (rs && model?.data.Count > 0)
                {
                    await Share.RequestAsync(new ShareTextRequest
                    {
                        Uri = model.data.FirstOrDefault(),
                        Title = "Share Link"
                    });
                }
            });
        }

        async Task BorkerAction()
        {
            if (Common.Utils.CommonMethods.CheckInternet())
            {
                var page = new Views.Broker.ListBorkerPage();
                await App.Current.MainPage.Navigation.PushAsync(page);
            }
        }
        #endregion

        #region Methods
        void Init()
        {
            List = new ObservableCollection<MFunctionOfUser>();
            NameUser = App.dataBussiness.GetUserLogin().HoDem + " " + App.dataBussiness.GetUserLogin().Ten;
            switch (App.dataBussiness.GetUserLogin().ForGroup)
            {
                case "F73334B4-F6FE-4C64-A320-D0131F8F194E": // Quan tri vien
                    List.Add(new MFunctionOfUser
                    {
                        Name = "Danh sách hồ sơ",
                        Image = "subuser.png",
                        Function = new AsyncCommand(BrowseprofilesAction)
                    });
                    break;
                case "DC494581-D9D7-4627-A1BF-C9CF5CB66314": // nhan vien
                    List.Add(new MFunctionOfUser
                    {
                        Name = "Tạo hồ sơ vây",
                        Image = "subuser.png",
                        Function = new AsyncCommand(CreatProfileCredit)
                    });
                    List.Add(new MFunctionOfUser
                    {
                        Name = "Khách hàng",
                        Image = "subuser.png",
                        Function = new AsyncCommand(ListProfileCredit)
                    });
                    List.Add(new MFunctionOfUser
                    {
                        Name = "Cộng tác viên",
                        Image = "subuser.png",
                        Function = new AsyncCommand(BorkerAction)
                    });
                    break;
                case "501C9AE2-D892-4E55-8B2E-6BAF13B348A0": // nguoi dung
                    List.Add(new MFunctionOfUser
                    {
                        Name = "Xác thực",
                        Image = "subuser.png",
                        Function = new AsyncCommand(BrowseprofilesAction)
                    });
                    break;
                case "C0279290-9FAA-47FB-B37E-550552828EDF": // Cong tac vien
                    List.Add(new MFunctionOfUser
                    {
                        Name = "Chia sẻ",
                        Image = "subuser.png",
                        Function = new AsyncCommand(ShareAction)
                    });
                    break;
            }
            List.Add(new MFunctionOfUser
            {
                Name = "Đăng xuất",
                Image = "Icon2.png",
                Function = new AsyncCommand(LogoutAction)
            });
        }
        #endregion
    }

    public class MFunctionOfUser
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public ICommand Function { get; set; }
    }
}
