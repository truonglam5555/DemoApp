using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace DemoApp.Views.Popup
{
    public partial class SelectTypePopup : PopupPage
    {
        public event EventHandler<SelecType> Result;
        public SelectTypePopup()
        {
            InitializeComponent();
            var list = new List<SelecType>();
            list.Add(new SelecType { ID = -1,Ten = "Không duyệt" });
            list.Add(new SelecType { ID = 1, Ten = "Chờ phê duyệt" });
            list.Add(new SelecType { ID = 2, Ten = "Đã duyệt" });
            this.BindingContext = list;
        }

        async void ListView_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.RemovePageAsync(this);
            Result?.Invoke(sender,e.Item as SelecType);
        }
    }

    public class SelecType
    {
        public int ID { get; set; }
        public string Ten { get; set; }
    }
}
