using System;
using System.Collections.Generic;
using DemoApp.Models.Base;

namespace DemoApp.Models.Broker
{
    public class MBorkerRQ
    {
        public string HoDem { get; set; }
        public string Ten { get; set; }
        public string SoDienThoai { get; set; }
        public string TaiKhoanNganHang { get; set; }
        public string TenNganHang { get; set; }
        public string GuidUser { get; set; }
    }

    public class MBorker
    {
        public string GuidUser { get; set; }
        public string MaKhachHang { get; set; }
        public string MaCTV { get; set; }
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
    }

    public class MBorkerListRQ
    {
        public string GuidUser { get; set; }
    }

    public class MBorkerRS : MBaseResponse<List<MBorker>>
    {

    }
}
