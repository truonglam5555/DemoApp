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
            var popupOrder = new Views.Popup.OderPage();
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(popupOrder);
        }

        private void CollectionView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            Debug.WriteLine(e.FirstVisibleItemIndex);
            Debug.WriteLine(e.LastVisibleItemIndex);
            Debug.WriteLine("------------------");
        }

        private void Action(MonAnChiTiet item)
        {
            cvMonAn.ScrollTo(item, null, ScrollToPosition.Start, false);
        }
    }
}
