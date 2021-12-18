using System;
using System.Collections.Generic;
using System.Linq;
using DemoApp.ViewModels.Home;
using DemoApp.Views.Scanr;
using Plugin.NFC;
using Xamarin.Forms;

namespace DemoApp.Views.Home
{
    public partial class MainPage : ContentPage
    {
        VMMain vMMain;
        public MainPage()
        {
            InitializeComponent();
            vMMain = new VMMain();
            this.BindingContext = vMMain;
            NFCHandlerInitialize();
        }

        private void NFCHandlerInitialize()
        {
            CrossNFC.Current.OnMessageReceived += Current_OnMessageReceived;
            CrossNFC.Current.OnMessagePublished += Current_OnMessagePublished;
        }

        private void Current_OnMessageReceived(ITagInfo tagInfo)
        {
            if (App.Current.MainPage.Navigation.NavigationStack?.LastOrDefault()?.GetType() == typeof(ScanrPage))
            {
                MessagingCenter.Instance.Send<byte[]>(tagInfo.Identifier, "NFCMessageReceived_ScanrPage");
            }
        }

        private void Current_OnMessagePublished(ITagInfo tagInfo)
        {

        }
    }
}
