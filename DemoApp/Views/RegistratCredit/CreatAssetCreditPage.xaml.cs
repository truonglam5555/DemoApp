using System;
using System.Collections.Generic;
using DemoApp.ViewModels.RegistratCredit;
using Xamarin.Forms;

namespace DemoApp.Views.RegistratCredit
{
    public partial class CreatAssetCreditPage : ContentPage
    {
        VMCreatProfileCredit mCreatAssetCredit;
        public CreatAssetCreditPage()
        {
            InitializeComponent();
            mCreatAssetCredit = new VMCreatProfileCredit();
            this.BindingContext = mCreatAssetCredit;
        }
    }
}
