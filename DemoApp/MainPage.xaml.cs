using DemoApp.ViewModels;
using Xamarin.Forms;
using System.Linq;
using Xamarin.CommunityToolkit.UI.Views;
using System.Collections.Generic;
using DemoApp.Models;
using System.Threading.Tasks;

namespace DemoApp
{
    public partial class MainPage : ContentPage
    {
        private VMMain vm;
        public List<Models.MenuItem> menuItems = new List<Models.MenuItem>();
        public MainPage()
        {
            InitializeComponent();
            vm = new VMMain();
            this.BindingContext = vm;
            CreatMenu();
        }

        void CreatMenu()
        {
            foreach(var header in vm.MMain)
            {
                Expander expander = new Expander() { IsExpanded = true };
                expander.Header = new Label { Text = header.Name, FontSize = 20,Padding = new Thickness(0,10) };

                List<VisualElement> ele = new List<VisualElement>();
                StackLayout content = new StackLayout();
                foreach(var Title in header.Details)
                {
                    Label label = new Label
                    {
                        Text = Title.detail,
                        Padding = new Thickness(20,50),
                        BackgroundColor = Color.White,
                    };
                    ele.Add(label);
                    label.BindingContext = Title;
                    label.SetBinding(Label.BackgroundColorProperty, nameof(Title.BgItem));
                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += (s, e) =>
                    {
                        var item = (s as Label).BindingContext as Models.Detail;
                        Device.BeginInvokeOnMainThread(() => {
                            var selectedItem = vm.MonAnList.Where(x => x.IDGroup.Equals(item.ID)).FirstOrDefault();
                            Action(selectedItem);
                            vm.ScrollChangedSelect(item.ID);
                        });
                    };
                    label.GestureRecognizers.Add(tapGestureRecognizer);
                    content.Children.Add(label);
                }
                expander.Content = content;
                NameMenu.Children.Add(expander);

                menuItems.Add(new Models.MenuItem
                {
                    ExpandItem = expander,
                    Menu = ele
                });
            }
        }

        async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            var popupOrder = new Views.Popup.OderPage();
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(popupOrder);
        }

        private void Action(MonAnChiTiet item)
        {
            cvMonAn.ScrollTo(item, null, ScrollToPosition.Start, false);
        }

        async void CollectionView_Scrolled(System.Object sender, Xamarin.Forms.ItemsViewScrolledEventArgs e)
        {
            var item = vm.MonAnList[e.FirstVisibleItemIndex];
            vm.ScrollChangedSelect(item.IDGroup);
            if(menuItems != null)
            {
                foreach (var itemM in menuItems)
                {
                    foreach (Label ci in itemM.Menu)
                    {
                        if ((ci.BindingContext as Detail).ID == item.IDGroup)
                        {
                            (itemM.ExpandItem as Expander).IsExpanded = true;
                            await controlScroll.ScrollToAsync(ci, ScrollToPosition.MakeVisible, true);
                        }
                    }
                }
            }
        }
    }
}
