using System;
using System.Threading.Tasks;
using System.Windows.Input;
using DemoApp.Services.Interface;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace DemoApp.ViewModels.VMNavigation
{
    public class VMNavigationBar : Xamarin.CommunityToolkit.ObjectModel.ObservableObject
    {
        public VMNavigationBar()
        {
            Navigattion = 40;
            if (Device.RuntimePlatform == Device.Android)
            {
                StatuBar = DependencyService.Get<IDeviceStatuBar>().GetHeight();
            }
            else
            {
                if (App.ScreenHeight > 800 && App.ScreenHeight < 1000)
                {
                    StatuBar = 30;
                }
                else
                {
                    StatuBar = 24;
                }
            }
            ClosePage = new AsyncCommand(ClosePageAction);
        }

        #region Properties
        public int StatuBar { get; set; }
        public int Navigattion { get; set; }
        #endregion

        #region Commnads
        public ICommand ClosePage { get; set; }
        #endregion

        #region Actions
        async Task ClosePageAction()
        {
            if (App.Current.MainPage.Navigation.ModalStack.Count > 0)
            {
                await App.Current.MainPage.Navigation.PopModalAsync();
            }
            else
            {
                await App.Current.MainPage.Navigation.PopAsync();
            }
        }
        #endregion
    }
}
