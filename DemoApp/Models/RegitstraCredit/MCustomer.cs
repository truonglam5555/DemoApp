using System;
using System.Collections.Generic;
using DemoApp.Models.Base;

namespace DemoApp.Models.RegitstraCredit
{
    public class MCustomer
    {
        public string GuidUser { get; set; }
        public string MaKhachHang { get; set; }
        public string HoDem { get; set; }
        public string Ten { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string SoCMND { get; set; }
        public string CmndMatTruoc { get; set; }
        public string CmndMatSau { get; set; }
        public string TaiKhoanNganHang { get; set; }
        public string TenNganHang { get; set; }
        public string FullName { get => HoDem + " " + Ten; }
    }

    public class MCustomer_RQ
    {
        public string GuidUser { get; set; }
    }

    public class MCustomer_RS : MBaseResponse<List<MCustomer>>
    {

    }
}
