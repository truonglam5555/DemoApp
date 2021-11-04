using DemoApp.ViewModels;
using Xamarin.Forms;
using System.Linq;
using Xamarin.CommunityToolkit.UI.Views;
using System.Collections.Generic;

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
                        Text = header.Name,
                        Padding = new Thickness(20,10),
                        BackgroundColor = Color.White,
                        BindingContext = Title
                    };
                    label.BindingContext = Title;
                    label.SetBinding(Label.BackgroundColorProperty, nameof(Title.BgItem));
                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += (s,e) =>
                    {
                        var item = (s as Label).BindingContext as Models.Detail;
                        vm.DetailAct(item);
                    };
                    label.GestureRecognizers.Add(tapGestureRecognizer);
                    content.Children.Add(label);
                    ele.Add(label);
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

        void CollectionView_Scrolled(System.Object sender, Xamarin.Forms.ItemsViewScrolledEventArgs e)
        {
            var item = vm.MMonAn[e.LastVisibleItemIndex];
            var rs = vm.ScrollChangedSelect(item.IDGroup);
            if(rs != null)
            {
                //await controlScroll.ScrollToAsync(VisualElement, ScrollToPosition.MakeVisible, false);
            }
        }
    }
}
