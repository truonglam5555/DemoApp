using System;
using System.Threading.Tasks;
using System.Windows.Input;
using DemoApp.ViewModels.VMNavigation;
using Xamarin.CommunityToolkit.ObjectModel;

namespace DemoApp.ViewModels.Acount
{
    public class VMSignIn : VMNavigationBar
    {
        public Action ValidateName;
        public Action ValidatePass;

        public VMSignIn()
        {
            Login = new AsyncCommand(LoginAction);
            Signup = new AsyncCommand(SignupAction);
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
        public ICommand Signup { get; set; }
        #endregion

        #region Actions
        async Task LoginAction()
        {
            if (Validate())
            {
                await Task.Delay(100);
                App.Current.MainPage = new MainPage(NameSigin);
            }
        }

        async Task SignupAction()
        {
            //var signUp = new Views.Acounts.SignUp();
            //await signUp.Transition(App.Current.MainPage as TransitionNavigationPage, App.transitionType);
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
