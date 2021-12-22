using System;
using System.Collections.Generic;
using DemoApp.Models.Base;

namespace DemoApp.Models.RegitstraCredit
{
    public class MHistoryConfirm
    {
        public string GuidTaiSan { get; set; }
        public string ThoiGian { get; set; }
        public decimal? Lat { get; set; }
        public decimal? Lng { get; set; }
        public string TenThietBi { get; set; }
        public bool Isfrish { get; set; } = false;
    }

    public class MHistoryConfirmRQ
    {
        public string GuidTaiSan { get; set; }
    }

    public class MHistoryConfirmRS : MBaseResponse<List<MHistoryConfirm>>
    {

    }
}
