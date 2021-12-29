using System;
using System.Collections.Generic;
using DemoApp.Models.RegitstraCredit;
using Xamarin.Forms;

namespace DemoApp.Views.RegistratCredit
{
    public partial class DetailAssetCreditPage : ContentPage
    {
        public DetailAssetCreditPage(MAssetCredit assetCredit)
        {
            InitializeComponent();
            SetTitle(assetCredit);
        }

        void SetTitle(MAssetCredit assetCredit)
        {
            this.BindingContext = assetCredit;
            ContentLyDo.IsVisible = !string.IsNullOrEmpty(assetCredit.LyDoKhongPheDuyet);
            ContentAnhTaiSan.IsVisible = assetCredit.DanhSachHinhAnhTaiSan?.Count > 0;
            ContentHopDong.IsVisible = assetCredit.DanhSachHinhAnhHopDong?.Count > 0;
        }

        void btnNavBarBack_Clicked(System.Object sender, System.EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}
