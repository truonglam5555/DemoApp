using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace DemoApp.Views.Popup
{
    public partial class OderPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        public OderPage()
        {
            InitializeComponent();
            Contentgird.WidthRequest = App.ScreenWidth / 2;
        }
    }
}
