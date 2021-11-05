using DemoApp.Controls;
using DemoApp.Models;
using DemoApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
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

        private async void StepperControl_TapEventAsync(object sender, Controls.StepperControl.EvenStepper e)
        {
            var item = (sender as StepperControl).BindingContext as MMonDat;
            item.SoLuong = e.Value;
            if (item.SoLuong == 0)
            {
                var requestPopup = new Views.Popup.PopupAlertCancel();
                await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(requestPopup);
                requestPopup.EventDelete += (s, ev) => {
                    if (ev)
                    {
                        vm.DeleteOrderAction(item);
                    }
                    else
                    {
                        item.SoLuong++;
                        (sender as StepperControl).Value = item.SoLuong;
                    }
                };
                
            }
            else
            {
                App.dataBussiness.UpdateRow(item);
            }
        }

        void TabView_SelectionChanged(System.Object sender, Xamarin.CommunityToolkit.UI.Views.TabSelectionChangedEventArgs e)
        {
            if (e.NewPosition == 1 && vm.isChanged)
            {
                vm.LoadDataOeder();
                vm.isChanged = false;
            }

            if (e.NewPosition == 0)
            {
                vm.isChanged = true;
            }
        }
    }
}
