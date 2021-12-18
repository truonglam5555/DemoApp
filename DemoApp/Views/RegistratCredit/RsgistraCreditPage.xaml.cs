using System;
using System.Collections.Generic;
using DemoApp.ViewModels.RegistratCredit;
using Xamarin.Forms;

namespace DemoApp.Views.RegistratCredit
{
    public partial class RsgistraCreditPage : ContentPage
    {
        VMCreatProfileCredit mCreatAssetCredit;
        public RsgistraCreditPage()
        {
            InitializeComponent();
            mCreatAssetCredit = new VMCreatProfileCredit();
            this.BindingContext = mCreatAssetCredit;
        }
    }
}
