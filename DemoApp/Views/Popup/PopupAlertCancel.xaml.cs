using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DemoApp.Views.Popup
{
    public partial class PopupAlertCancel : Rg.Plugins.Popup.Pages.PopupPage
    {
        public event EventHandler<bool> EventDelete;
        public PopupAlertCancel()
        {
            InitializeComponent();
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var button = sender as Button;
            if (button == btnDel)
            {
                EventDelete?.Invoke(sender, true);
            }
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.RemovePageAsync(this);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            EventDelete?.Invoke(null, false);
        }
    }
}
