using System;
using Android.Graphics.Drawables;
using DemoApp.Controls;
using DemoApp.Droid.ControlsRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CTEditor), typeof(CTEditorRenderer))]
namespace DemoApp.Droid.ControlsRenderer
{
    public class CTEditorRenderer : EditorRenderer
    {
        public CTEditorRenderer() : base(Xamarin.Essentials.Platform.CurrentActivity) {}

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if(Control != null)
            {
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
            }
        }
    }
}
