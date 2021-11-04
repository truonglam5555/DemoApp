using DemoApp.Controls;
using DemoApp.Models;
using DemoApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace DemoApp.Views.Popup
{
    public partial class OderPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        VMOrder vm; 
        public OderPage()
        {
            InitializeComponent();
            Contentgird.WidthRequest = App.ScreenWidth / 2;
            vm = new VMOrder();
            BindingContext = vm;
        }

        private void StepperControl_TapEvent(object sender, Controls.StepperControl.EvenStepper e)
        {
            var item = (sender as StepperControl).BindingContext as OrderList;
            item.SoLuong = e.Value;
            if (item.SoLuong == 0)
            {
                //vm.DeleteOrderAction(item);
            }
            //App.DataBussiness.UpdateRow(item);
        }

        void TabView_SelectionChanged(System.Object sender, Xamarin.CommunityToolkit.UI.Views.TabSelectionChangedEventArgs e)
        {
            if(e.NewPosition == 1)
            {
                vm.LoadDataOeder();
            }
        }
    }
}
