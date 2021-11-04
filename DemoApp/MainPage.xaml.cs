using DemoApp.Models;
using DemoApp.ViewModels;
using System.Diagnostics;
using Xamarin.Forms;

namespace DemoApp
{
    public partial class MainPage : ContentPage
    {
        private VMMain vm;

        public MainPage()
        {
            InitializeComponent();
            vm = new VMMain();
            this.BindingContext = vm;
            vm.Action += Action;
        }

        async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            var popupOrder = new Views.Popup.OderPage(vm.OrderedList, vm.OrderingList);
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(popupOrder);
        }

        private void Action(MonAnChiTiet item)
        {
            cvMonAn.ScrollTo(item, null, ScrollToPosition.Start, false);
        }

        void CollectionView_Scrolled(System.Object sender, Xamarin.Forms.ItemsViewScrolledEventArgs e)
        {
            var item = vm.MonAnList[e.LastVisibleItemIndex];
            vm.ScrollChangedSelect(item.IDGroup);

        }
    }
}
