using System;
using System.Collections.Generic;
using DemoApp.ViewModels.RegistratCredit;
using Xamarin.Forms;

namespace DemoApp.Views.RegistratCredit
{
    public partial class ContractCreditPage : ContentPage
    {
        public VMContractCredit vMContractCredit;
        public ContractCreditPage()
        {
            InitializeComponent();
            vMContractCredit = new VMContractCredit();
            this.BindingContext = vMContractCredit;
        }
    }
}
