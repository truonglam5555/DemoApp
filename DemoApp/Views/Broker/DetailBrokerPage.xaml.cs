using System;
using System.Collections.Generic;
using DemoApp.Models.Broker;
using Xamarin.Forms;

namespace DemoApp.Views.Broker
{
    public partial class DetailBrokerPage : ContentPage
    {
        public DetailBrokerPage(MBorker borker)
        {
            InitializeComponent();
            this.BindingContext = borker;
        }

        void btnNavBarBack_Clicked(System.Object sender, System.EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}
