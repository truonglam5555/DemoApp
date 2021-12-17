using System;
using Xamarin.Forms;

namespace DemoApp.Controls
{
    public class FrameCornerRadius : Xamarin.Forms.Frame
    {
        public static new readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(CornerRadius), typeof(FrameCornerRadius));
        public FrameCornerRadius()
        {
            base.CornerRadius = 0;
        }

        public new CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
    }
}
