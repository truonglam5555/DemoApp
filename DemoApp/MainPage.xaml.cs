using DemoApp.ViewModels;
using Xamarin.Forms;
using System.Linq;
using Xamarin.CommunityToolkit.UI.Views;
using System.Collections.Generic;
using DemoApp.Models;
using System.Threading.Tasks;
using DemoApp.Resources.Fonts;

namespace DemoApp
{
    public partial class MainPage : ContentPage
    {
        private VMMain vm;
        public List<Models.MenuItem> menuItems = new List<Models.MenuItem>();
        public MainPage(string _name)
        {
            InitializeComponent();
            txtName.Text = _name;
            vm = new VMMain();
            this.BindingContext = vm;
            CreatMenu();
        }

        void CreatMenu()
        {
            foreach(var header in vm.MMain)
            {
                Expander expander = new Expander() { IsExpanded = true };
                var Contentheader = new StackLayout
                {
                    Padding = new Thickness(10),
                    Orientation = StackOrientation.Horizontal
                };

                Contentheader.Children.Add(new Label { Text = header.Name, FontSize = 30,TextColor = Color.White ,HorizontalOptions = LayoutOptions.StartAndExpand});
                Contentheader.Children.Add(new Label { FontFamily = FontAssembly.SolidStyle,
                    TextColor = Color.White,
                    Text = FontAwesomeIcon.Icon.ChevronDown, VerticalOptions = LayoutOptions.Center, FontSize=20 });
                expander.Header = Contentheader;

                expander.Tapped += Expander_Tapped;

                List<VisualElement> ele = new List<VisualElement>();
                StackLayout content = new StackLayout();
                foreach(var Title in header.Details)
                {
                    Label label = new Label
                    {
                        Text = Title.detail,
                        FontSize = 25,
                        Padding = new Thickness(25,10,20,10),
                        BackgroundColor = Color.White,
                        TextColor = Color.White
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

        private void Expander_Tapped(object sender, System.EventArgs e)
        {
            var controlexpan = (sender as Expander);
            var label = (controlexpan.Header as StackLayout).Children.LastOrDefault() as Label;
            label.Text = controlexpan.IsExpanded ? FontAwesomeIcon.Icon.ChevronDown : FontAwesomeIcon.Icon.ChevronUp;
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
            var beakRun = false;
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
                            beakRun = true;
                            break;
                        }
                    }
                    if (beakRun)
                        break;
                }
            }
        }
    }
}
