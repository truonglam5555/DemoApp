using System;
using System.Collections.Generic;
using DemoApp.Resources.Fonts;
using DemoApp.ViewModels.Acount;
using Xamarin.Forms;

namespace DemoApp.Views.Acount
{
    public partial class LoginPage : ContentPage
    {
        VMSignIn vMSignIn;
        public LoginPage()
        {
            InitializeComponent();
            vMSignIn = new VMSignIn();
            this.BindingContext = vMSignIn;
            vMSignIn.ValidateName += FocusName;
            vMSignIn.ValidatePass += FocusPass;
            vMSignIn.RemovePage += RemovePage;
        }

        void FocusName()
        {
            lblUsernamePower.IsVisible = true;
            entryUserName.Focus();
        }

        void FocusPass()
        {
            lblPasswordPower.IsVisible = true;
            entryPassWord.Focus();
        }

        void RemovePage()
        {
            App.Current.MainPage.Navigation.RemovePage(this);
        }

        private void ShowPassWord_Tapped(object sender, EventArgs e)
        {
            entryPassWord.IsPassword = !entryPassWord.IsPassword;
            var label = sender as Label;
            if (entryPassWord.IsPassword)
            {
                label.Text = FontAwesomeIcon.Icon.EyeSlash;
            }
            else
            {
                label.Text = FontAwesomeIcon.Icon.Eye;
            }
        }

        void entryUserName_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            lblUsernamePower.IsVisible = false;
        }

        void entryPassWord_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            lblPasswordPower.IsVisible = false;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private void entryPassWord_Unfocused(object sender, FocusEventArgs e)
        {
            lblPasswordPower.IsVisible = string.IsNullOrEmpty(entryPassWord.Text);
        }
    }
}
