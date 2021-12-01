using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace DemoApp.Views.Popup
{
    public partial class NotePage : PopupPage
    {
        public event EventHandler<string> Resutl;
        public NotePage(string Content = "")
        {
            InitializeComponent();
            ContentFrame.WidthRequest = App.ScreenWidth / 2;
            ContentFrame.HeightRequest = App.ScreenHeight * 0.7;
            ContentNote.Text = Content;
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.RemovePageAsync(this);
            Resutl?.Invoke(sender, ContentNote.Text);
        }
    }
}
