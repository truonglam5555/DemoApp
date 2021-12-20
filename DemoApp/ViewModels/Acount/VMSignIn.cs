using System;
using System.Threading.Tasks;
using System.Windows.Input;
using DemoApp.Models.Accoun;
using DemoApp.Services;
using DemoApp.ViewModels.VMNavigation;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace DemoApp.ViewModels.Acount
{
    public class VMSignIn : VMNavigationBar
    {
        public Action ValidateName;
        public Action ValidatePass;

        public Action RemovePage;

        public VMSignIn()
        {
            Login = new AsyncCommand(LoginAction);
        }

        #region Properties
        private string _nameSigin;
        public string NameSigin
        {
            get => _nameSigin;
            set { SetProperty(ref _nameSigin, value); }
        }

        private string _passSigin;

        public string PassSigin
        {
            get => _passSigin;
            set { SetProperty(ref _passSigin, value); }
        }

        #endregion

        #region Commnads
        public ICommand Login { get; set; }
        #endregion

        #region Actions
        async Task LoginAction()
        {
            if (Validate())
            {
                var popup = new Views.Popup.BusyPopupPage();
                await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(popup);
                await Task.Run(async () => {
                    var model = new MLogin_RS();
                    var rs = App.request.RequestsUser(ref model, "/api/User/Login", new MLogin_RQ {
                        username = NameSigin,
                        password = PassSigin,
                    });
                    await Rg.Plugins.Popup.Services.PopupNavigation.Instance.RemovePageAsync(popup);
                    if (rs && model?.data.Count>0)
                    {
                        Device.BeginInvokeOnMainThread(async () => {
                            App.dataBussiness.AddRow(model.data[0]);
                            var homePage = new Views.Home.HomePage();
                            await homePage.Transition(App.Current.MainPage as TransitionNavigationPage, App.transitionType);
                            RemovePage();
                        });
                    }
                });
               
            }
        }
        #endregion

        #region Mothers
        private bool Validate()
        {
            if (string.IsNullOrEmpty(NameSigin != null ? NameSigin.Trim() : NameSigin))
            {
                ValidateName.Invoke();
                return false;
            }

            if (string.IsNullOrEmpty(PassSigin))
            {
                ValidatePass.Invoke();
                return false;
            }
            return true;
        }
        #endregion
    }
}
