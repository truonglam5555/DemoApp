using System;
using System.Collections.Generic;
using DemoApp.ViewModels.RegistratCredit;
using Xamarin.Forms;

namespace DemoApp.Views.RegistratCredit
{
    public partial class CreatAssetCreditPage : ContentPage
    {
        public VMCreatAssetCredit mCreatAssetCredit;
        public CreatAssetCreditPage()
        {
            InitializeComponent();
            mCreatAssetCredit = new VMCreatAssetCredit();
            this.BindingContext = mCreatAssetCredit;
        }
    }
}
