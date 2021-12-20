using System;
using System.Collections.Generic;
using DemoApp.ViewModels.RegistratCredit;
using Xamarin.Forms;

namespace DemoApp.Views.RegistratCredit
{
    public partial class ListCustomerPage : ContentPage
    {
        VMListCustomer vMListCustomer;
        public ListCustomerPage()
        {
            InitializeComponent();
            vMListCustomer = new VMListCustomer();
            this.BindingContext = vMListCustomer;
        }
    }
}
