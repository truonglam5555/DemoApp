using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DemoApp.Models
{
    public class MenuItem
    {
        public VisualElement ExpandItem { get; set; }
        public List<VisualElement> Menu { get; set; }
        public MenuItem()
        {
        }
    }
}
