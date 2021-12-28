using System;
using System.Collections.Generic;
using DemoApp.ViewModels.ListProfile;
using Xamarin.Forms;

namespace DemoApp.Views.ListProfile
{
    public partial class BrowsProfileDetailPage : ContentPage
    {
        public VMBrowsProfileDetail vMBrowsProfileDetail;
        public BrowsProfileDetailPage(bool isShow = true)
        {
            InitializeComponent();
            vMBrowsProfileDetail = new VMBrowsProfileDetail();
            this.BindingContext = vMBrowsProfileDetail;
            if(!isShow)
            {
                SelectView.IsVisible = isShow;
                InputVew.IsVisible = isShow;
                ButtonView.IsVisible = isShow;
            }
        }

        void rbDuyet_CheckedChanged(System.Object sender, Xamarin.Forms.CheckedChangedEventArgs e)
        {
            if(e.Value)
            {
                vMBrowsProfileDetail._TrangThai = (int)Enums.EnumList.TrangThaiHoSoTaiSanEnums.PheDuyet;
            }
            else
            {
                vMBrowsProfileDetail._TrangThai = (int)Enums.EnumList.TrangThaiHoSoTaiSanEnums.KhongPheDuyet;
            }
        }
    }
}
