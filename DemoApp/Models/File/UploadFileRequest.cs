using System;
using System.Collections.Generic;
using DemoApp.Models.Base;

namespace DemoApp.Models.File
{
    public class FileRequest
    {
        public string Id { get; set; }
        public string FileName { get; set; }
        public string Url { get; set; }
        public long FileSize { get; set; }
    }

    public class FileRequest_RQ
    {
        //public string GuidUser { get; set; }
        //public string GuidCompany { get; set; }
        public string ForPhanHe { get; set; } = "8";
        public string FolderProject { get; set; } = "TrueCredit";
    }

    public class FileRequest_RS : MBaseResponse<List<FileRequest>>
    {

    }
}
