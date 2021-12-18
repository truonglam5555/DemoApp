using System;
using System.Collections.Generic;
using DemoApp.Models.Base;

namespace DemoApp.Models.RegitstraCredit
{
    public class MRegitraCredit_RQ
    {
        public string TenDangNhap { get; set; }
        public string HoDem { get; set; }
        public string Ten { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string SoCMND { get; set; }
        public string CMNDMatTruoc { get; set; }
        public string CMNDMatSau { get; set; }
        public string TaiKhoanNganHang { get; set; }
        public string TenNganHang { get; set; }
        public string GuidUser { get; set; }
    }

    public class MRegitraCredit_RS : MBaseResponse<List<MRegitraCredit_RQ>>
    {
       
    }
}
