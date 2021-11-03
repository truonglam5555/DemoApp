using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace DemoApp.Models
{
    public class MMain
    {
        public string Name { get; set; }
        public ObservableCollection<Detail> Details { get; set; } = new ObservableCollection<Detail>();
    }

    public class Detail: ObservableObject
    {
        public string detail { get; set; }
        public bool isSelected { get; set; } = false;
        public Color BgItem { get => _bgItem; set { SetProperty(ref _bgItem, value); } }

        private Color _bgItem = Color.Transparent;
    }
}
