using System;
using System.Collections.Generic;
using DemoApp.Models.Base;

namespace DemoApp.Models.RegitstraCredit
{
    public class MAssetCredit
    {
        public string Id { get; set; }
        public string Rfid { get; set; }
        public string MaKhachHang { get; set; }
        public string TenTaiSan { get; set; }
        public string NhanHieu { get; set; }
        public string ThongSoKyThuat { get; set; }
        public decimal? DinhGiaTaiSan { get; set; }
        public decimal? SoTienChoVay { get; set; }
        public decimal? LaiXuatVay { get; set; }
        public decimal? ThoiHanTraNo { get; set; }
        public decimal? PhiTraNoTruocHan { get; set; }
        public int? TrangThai { get; set; }
        public string TenTrangThai { get; set; }
        public string LyDoKhongPheDuyet { get; set; }
        public string GhiChu { get; set; }
        public bool? IsCoFileHopDong { get; set; }
        public List<string> DanhSachHinhAnhTaiSan { get; set; }
        public List<string> DanhSachHinhAnhHopDong { get; set; }
    }

    public class MAssetCreditRQ
    {
        public string GuidUser { get; set; }
    }

    public class MAssetCreditRS : MBaseResponse<List<MAssetCredit>>
    {
        public string GuidUser { get; set; }
    }
}
