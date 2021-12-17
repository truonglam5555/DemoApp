using System;
using System.Threading.Tasks;
using DemoApp.Common.Bussiness;
using DemoApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoApp
{
    public partial class App : Application
    {
        public static int ScreenHeight;
        public static int ScreenWidth;
        public static DataBussiness dataBussiness;
        public static Request request;
        public static TransitionType transitionType;
        public App()
        {
            InitializeComponent();

            MainPage = new TransitionNavigationPage(new Views.Home.MainPage());
            transitionType = Device.RuntimePlatform == Device.Android ? TransitionType.Fade : TransitionType.Default;
            Task.Run(() => {
                if (request == null)
                    request = new Request();
                if (dataBussiness == null)
                    dataBussiness = new DataBussiness();
            });
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
