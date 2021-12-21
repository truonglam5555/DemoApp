using System;
using System.Collections.Generic;
using DemoApp.ViewModels.ListProfile;
using Xamarin.Forms;

namespace DemoApp.Views.ListProfile
{
    public partial class BrowsProfileDetailPage : ContentPage
    {
        public VMBrowsProfileDetail vMBrowsProfileDetail;
        public BrowsProfileDetailPage()
        {
            InitializeComponent();
            vMBrowsProfileDetail = new VMBrowsProfileDetail();
            this.BindingContext = vMBrowsProfileDetail;
        }

        void rbDuyet_CheckedChanged(System.Object sender, Xamarin.Forms.CheckedChangedEventArgs e)
        {
            if(e.Value)
            {
                vMBrowsProfileDetail._TrangThai = 1;
            }
            else
            {
                vMBrowsProfileDetail._TrangThai = -1;
            }
        }
    }
}
