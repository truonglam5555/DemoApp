using System;
using System.Collections.Generic;
using DemoApp.ViewModels.ListProfile;
using Xamarin.Forms;

namespace DemoApp.Views.ListProfile
{
    public partial class BrowsProfilePage : ContentPage
    {
        VMBrowsProfile vMBrowsProfile;
        public BrowsProfilePage()
        {
            InitializeComponent();
            vMBrowsProfile = new VMBrowsProfile();
            this.BindingContext = vMBrowsProfile;
        }

        public void Refresh()
        {
            vMBrowsProfile.RefreshData();
        }
    }
}
