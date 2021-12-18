using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using DemoApp.Models.File;
using Newtonsoft.Json;

namespace DemoApp.Common.Bussiness
{
    public class Request
    {
        private Setting mSetting = Setting.Instance;

        private HttpClient ApiClient;
        private HttpClient mMediaClient;

        public Request()
        {
            ApiClient = NetClient.Instance(mSetting.ApiUrl).Client;
            mMediaClient = NetClient.Instance(mSetting.MediaUrl).Client;
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

                    HttpContent content = new StringContent(param, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = ApiClient.PostAsync(api, content).Result;
                    //HttpResponseMessage response = ApiClient.GetAsync(api).Result;
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

        public FileRequest_RS UploadFileRequest(FileRequest_RQ fileRequest, List<byte[]> Files)
        {
            if (Files == null || Files.Count <= 0)
            {
                return new FileRequest_RS
                {
                    errorCode = -1,
                    isSuccess = false,
                    message = "Không có file để tải lên!"
                };
            }
            try
            {
                if (mMediaClient != null)
                {
                    MultipartFormDataContent content = new MultipartFormDataContent();

                    //StringContent guidUser = new StringContent(fileRequest.GuidUser.ToString());
                    //content.Add(guidUser, "GuidUser");

                    //StringContent guidCompany = new StringContent(fileRequest.GuidCompany.ToString());
                    //content.Add(guidCompany, "GuidCompany");

                    StringContent forPhanHe = new StringContent(fileRequest.ForPhanHe.ToString());
                    content.Add(forPhanHe, "ForPhanHe");

                    StringContent strFolderName = new StringContent(fileRequest.FolderProject.ToString());
                    content.Add(strFolderName, "FolderProject");

                    int i = 0;
                    foreach (var file in Files)
                    {
                        HttpContent fileStreamContent = new StreamContent(new MemoryStream(file));
                        fileStreamContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data") { Name = "file", FileName = fileRequest.FolderProject + "-" + i.ToString() + ".jpg" };
                        fileStreamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                        content.Add(fileStreamContent);
                        i++;
                    }

                    var response = (mMediaClient.PostAsync("/api/Media/UploadFile", content)).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string strData = response.Content.ReadAsStringAsync().Result;
                        var data = JsonConvert.DeserializeObject<FileRequest_RS>(strData);
                        return data;
                    }
                    else
                    {
                        return new FileRequest_RS
                        {
                            errorCode = -1,
                            isSuccess = false,
                            message = "Lỗi, vui lòng thử lại!"
                        };
                    }
                }

            }
            catch (Exception ex)
            {
                return new FileRequest_RS
                {
                    errorCode = ex.HResult,
                    isSuccess = false,
                    message = ex.InnerException != null ? ex.InnerException.InnerException.ToString() : ex.Message
                };
            }

            return new FileRequest_RS
            {
                errorCode = -1,
                isSuccess = false,
                message = "Lỗi, vui lòng thử lại!"
            };
        }
    }
}
