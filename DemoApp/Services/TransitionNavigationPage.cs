using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemoApp.Services
{
    public class TransitionNavigationPage : NavigationPage
    {
        public static readonly BindableProperty TransitionTypeProperty = BindableProperty.Create("TransitionType", typeof(TransitionType), typeof(TransitionNavigationPage), TransitionType.SlideFromLeft);

        public TransitionType TransitionType
        {
            get { return (TransitionType)GetValue(TransitionTypeProperty); }
            set { SetValue(TransitionTypeProperty, value); }
        }
        public TransitionNavigationPage() : base()
        {
            //this.BarBackgroundColor = App.MainBackgruond;
        }

        public TransitionNavigationPage(Page root) : base(root)
        {
            //this.BarBackgroundColor = App.MainBackgruond;
        }
    }

    public enum TransitionType
    {
        None = -1,
        Default = 0,
        Fade = 1,
        Flip = 2,
        Scale = 3,
        SlideFromLeft = 4,
        SlideFromRight = 5,
        SlideFromTop = 6,
        SlideFromBottom = 7
    }

    public static class TransitionNavigationPageExtension
    {
        private static bool IsHas = false;
        public static async Task Transition(this Page Page, TransitionNavigationPage ParentNavigationPage, TransitionType TransitionType)
        {
            if (ParentNavigationPage != null)
            {
                if (!IsHas)
                {
                    ParentNavigationPage.TransitionType = TransitionType;
                    IsHas = true;
                }
                await ParentNavigationPage.PushAsync(Page);
            }
        }
    }
}
