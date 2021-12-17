﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace DemoApp.Common.Bussiness
{
    class NetClient
    {
        private static List<NetClient> _instance = new List<NetClient>();

        private NetClient() { }

        private NetClient(string urlBase)
        {
            Client = new HttpClient(new System.Net.Http.HttpClientHandler());
            Client.BaseAddress = new Uri(urlBase);
            UriApi = urlBase;
        }

        public static NetClient Instance(string url)
        {
            if (_instance != null && _instance.Where(m => m.UriApi == url).Count() > 0)
            {
                return _instance.Where(m => m.UriApi == url).ToList().First();
            }

            NetClient _net = new NetClient(url);
            _instance.Add(_net);

            return _net;
        }

        public string UriApi { get; set; }

        public HttpClient Client { get; set; }
    }
}
