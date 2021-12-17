using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace DemoApp.Common.Bussiness
{
    public class Request
    {
        private Setting mSetting = Setting.Instance;

        private HttpClient ApiClient;

        public Request()
        {
            ApiClient = NetClient.Instance(mSetting.ApiUrl).Client;
        }

        public bool Requests<DataResult, ParamRequest>(ref DataResult returnData, string api, ParamRequest requestParam)
        {
            if (ApiClient != null)
            {
                try
                {
                    string param = "{}";
                    if (!string.IsNullOrEmpty(requestParam.ToString()))
                    {
                        param = Newtonsoft.Json.Linq.JObject.FromObject(requestParam).ToString();
                    }

                    //HttpContent content = new StringContent(param, Encoding.UTF8, "application/json");
                    //HttpResponseMessage response = ApiClient.GetAsync(api, content).Result;
                    HttpResponseMessage response = ApiClient.GetAsync(api).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string strData = response.Content.ReadAsStringAsync().Result;
                        returnData = JsonConvert.DeserializeObject<DataResult>(strData);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
    }
}
