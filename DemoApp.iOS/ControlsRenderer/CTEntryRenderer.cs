using System;
using System.ComponentModel;
using DemoApp.Controls;
using DemoApp.iOS.ControlsRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CTEntry), typeof(CTEntryRenderer))]
namespace DemoApp.iOS.ControlsRenderer
{
    public class CTEntryRenderer : EntryRenderer
    {
        public CTEntryRenderer()
        {
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Control != null)
            {
                Control.Layer.BorderWidth = 0;
                Control.BorderStyle = UIKit.UITextBorderStyle.None;
            }

        }
    }
}
