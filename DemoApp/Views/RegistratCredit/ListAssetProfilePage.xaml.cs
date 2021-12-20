using System;
using System.Collections.Generic;
using DemoApp.ViewModels.RegistratCredit;
using Xamarin.Forms;

namespace DemoApp.Views.RegistratCredit
{
    public partial class ListAssetProfilePage : ContentPage
    {
        public VMListAssetProfile vMListAssetProfile;
        public ListAssetProfilePage()
        {
            InitializeComponent();
            vMListAssetProfile = new VMListAssetProfile();
            this.BindingContext = vMListAssetProfile;
        }
    }
}
