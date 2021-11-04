using DemoApp.ViewModels;
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
        }

        async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            var popupOrder = new Views.Popup.OderPage();
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(popupOrder);
        }

        void CollectionView_Scrolled(System.Object sender, Xamarin.Forms.ItemsViewScrolledEventArgs e)
        {
            var item = vm.MMonAn[e.LastVisibleItemIndex];
            if(controlsStack != null)
            {
                var a = controlsStack.Children;
                a.ToString();
            }
        }
    }
}
