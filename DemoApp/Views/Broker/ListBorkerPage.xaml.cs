using System;
using System.Collections.Generic;
using DemoApp.ViewModels.Broker;
using Xamarin.Forms;

namespace DemoApp.Views.Broker
{
    public partial class ListBorkerPage : ContentPage
    {
        VMListBorker ViewModel;
        public ListBorkerPage()
        {
            InitializeComponent();
            ViewModel = new VMListBorker();
            this.BindingContext = ViewModel;
        }

        public void Refresh()
        {
            ViewModel.RefreshAction(null);
        }
    }
}
