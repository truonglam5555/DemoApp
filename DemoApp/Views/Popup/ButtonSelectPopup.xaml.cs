using System;
using System.Collections.Generic;
using DemoApp.Models.RegitstraCredit;
using Xamarin.Forms;

namespace DemoApp.Views.Popup
{
    public partial class ButtonSelectPopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        public event EventHandler<string> Result;
        MAssetCredit _assetCredit;
        public ButtonSelectPopup(MAssetCredit assetCredit)
        {
            InitializeComponent();
            _assetCredit = assetCredit;
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.RemovePageAsync(this);
        }

        async void Button_Clicked_1(System.Object sender, System.EventArgs e)
        {
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.RemovePageAsync(this);
            Result?.Invoke(sender, _assetCredit.Id);
        }
    }
}
