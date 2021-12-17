using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;

namespace DemoApp.ViewModels.Home
{
    public class VMHome : Xamarin.CommunityToolkit.ObjectModel.ObservableObject
    {
        public VMHome()
        {
            Init();
        }

        #region Properties
        private string _nameUser = "ABC";
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

        }

        async Task LogoutAction()
        {

        }
        #endregion

        #region Methods
        void Init()
        {
            List = new ObservableCollection<MFunctionOfUser>();
            switch("")
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
                        Function = new AsyncCommand(BrowseprofilesAction)
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
