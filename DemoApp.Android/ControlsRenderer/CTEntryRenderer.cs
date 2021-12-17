using System;
using Android.Graphics.Drawables;
using DemoApp.Controls;
using DemoApp.Droid.ControlsRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CTEntry), typeof(CTEntryRenderer))]
namespace DemoApp.Droid.ControlsRenderer
{
    public class CTEntryRenderer : EntryRenderer
    {
        public CTEntryRenderer() : base(Xamarin.Essentials.Platform.CurrentActivity){}
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if(Control != null)
            {
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
            }
        }
    }
}
