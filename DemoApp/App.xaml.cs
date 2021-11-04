using System;
using System.Threading.Tasks;
using Vitaorga.Common.Bussiness;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoApp
{
    public partial class App : Application
    {
        public static int ScreenHeight;
        public static int ScreenWidth;
        public static DataBussiness dataBussiness;

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
            Task.Run(() => {
                if(dataBussiness == null)
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
