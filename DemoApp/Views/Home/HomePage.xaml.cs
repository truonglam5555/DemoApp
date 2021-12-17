using System;
using System.Collections.Generic;
using DemoApp.ViewModels.Home;
using Xamarin.Forms;

namespace DemoApp.Views.Home
{
    public partial class HomePage : ContentPage
    {
        VMHome vMHome;
        public HomePage()
        {
            InitializeComponent();
            vMHome = new VMHome();
            this.BindingContext = vMHome;
        }
    }
}
