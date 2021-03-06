using System;
namespace DemoApp.Common.Bussiness
{
    public class Setting
    {
        public static Setting _instance = null;
        private static readonly object padlock = new object();

        public static Setting Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new Setting();
                    }
                    return _instance;
                }
            }
        }

        public Setting()
        {
            ApiUrl = "http://demo.truedata.vn/";
            MediaUrl = "http://upload.odbtruedata.com/";
            ApiUserUrl = "http://demouser.truedata.vn";
        }

        public string ApiUrl { get; set; }
        public string MediaUrl { get; set; }
        public string ApiUserUrl { get; set; }
    }
}
