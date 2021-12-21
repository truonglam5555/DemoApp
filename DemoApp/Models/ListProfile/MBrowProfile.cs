using System;
using System.Collections.Generic;
using DemoApp.Models.Base;

namespace DemoApp.Models.ListProfile
{
    public class MBrowProfile
    {
        public string Id { get; set; }
        public string Rfid { get; set; }
        public string MaKhachHang { get; set; }
        public string TenTaiSan { get; set; }
        public decimal? DinhGiaTaiSan { get; set; }
        public decimal? SoTienChoVay { get; set; }
        public decimal? PhiTraNoTruocHan { get; set; }
        public int? TrangThai { get; set; }
        public string TenTrangThai { get; set; }
        public string NguoiTaoHoSo { get; set; }
        public string NgayTaoHoSo { get; set; }
    }


    public class MBrowProfileRQ
    {
        public int TrangThai { get; set; }
    }

    public class MBrowProfileRS : MBaseResponse<List<MBrowProfile>>
    {

    }
}
