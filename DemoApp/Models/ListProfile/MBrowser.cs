using System;
using System.Collections.Generic;
using DemoApp.Models.Base;

namespace DemoApp.Models.ListProfile
{
    public class MBrowserRQ
    {
        public string Id { get; set; }
        public int TrangThai { get; set; }
        public decimal SoTienChoVay { get; set; }
        public string GuidUser { get; set; }
    }

    public class MBrowserRS : MBaseResponse<List<MBrowProfile>>
    {

    }
}
