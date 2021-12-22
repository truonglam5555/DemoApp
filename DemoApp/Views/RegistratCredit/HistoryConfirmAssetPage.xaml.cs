using System;
using System.Collections.Generic;
using DemoApp.ViewModels.RegistratCredit;
using Xamarin.Forms;

namespace DemoApp.Views.RegistratCredit
{
    public partial class HistoryConfirmAssetPage : ContentPage
    {
        public VMHistoryConfirmAsset vMHistoryConfirmAsset;
        public HistoryConfirmAssetPage()
        {
            InitializeComponent();
            vMHistoryConfirmAsset = new VMHistoryConfirmAsset();
            this.BindingContext = vMHistoryConfirmAsset;
        }
    }
}
