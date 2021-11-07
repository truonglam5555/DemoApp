﻿using System;
using System.Threading.Tasks;
using DemoApp.Common.Bussiness;
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

            MainPage = new Views.Acount.LoginPage();
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
