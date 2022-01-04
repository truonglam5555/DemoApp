using System;
using System.Collections.Generic;
using DemoApp.ViewModels.Broker;
using Xamarin.Forms;

namespace DemoApp.Views.Broker
{
    public partial class RegistratBrokerPage : ContentPage
    {
        VMRegistratBroker ViewModel;
        public RegistratBrokerPage()
        {
            InitializeComponent();
            ViewModel = new VMRegistratBroker();
            this.BindingContext = ViewModel;
        }
    }
}
