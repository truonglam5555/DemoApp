using System;
namespace DemoApp.Models.Base
{
    public class MBaseResponse<T>
    {
        public T data { get; set; }
        public long totalRecord { get; set; }
        public bool isSuccess { get; set; }
        public string message { get; set; }
        public int errorCode { get; set; }
        public string exception { get; set; }

        #region for TrueData
        public string code { get; set; }
        public bool success { get; set; }
        #endregion
    }

    public class MBaseRequest
    {
        public int pageSize { get; set; } = 0;
        public int pageNumber { get; set; } = 0;
    }
}
