using System;
using System.Threading.Tasks;
using System.Windows.Input;
using DemoApp.Services;
using Xamarin.CommunityToolkit.ObjectModel;

namespace DemoApp.ViewModels.Home
{
    public class VMMain : Xamarin.CommunityToolkit.ObjectModel.ObservableObject
    {
        public VMMain()
        {
            Init();
        }

        #region Properties

        #endregion
        #region Commands
        public ICommand Login { get; set; }
        public ICommand Scanr { get; set; }

        #endregion
        #region Actions
        async Task LoginAction()
        {
            if(App.dataBussiness.GetUserLogin() != null)
            {
                var homePage = new Views.Home.HomePage();
                await homePage.Transition(App.Current.MainPage as TransitionNavigationPage, App.transitionType);
            }
            else
            {
                var loginPage = new Views.Acount.LoginPage();
                await loginPage.Transition(App.Current.MainPage as TransitionNavigationPage, App.transitionType);
            }
        }

        async Task ScanrAction()
        {
            var scanrPage = new Views.Scanr.ScanrPage();
            await scanrPage.Transition(App.Current.MainPage as TransitionNavigationPage, App.transitionType);
        }
        #endregion
        #region Methods
        void Init()
        {
            Login = new AsyncCommand(LoginAction);
            Scanr = new AsyncCommand(ScanrAction);
        }
        #endregion
    }
}
