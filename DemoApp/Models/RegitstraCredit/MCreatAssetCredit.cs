using System;
using System.Collections.Generic;
using DemoApp.Models.Base;

namespace DemoApp.Models.RegitstraCredit
{
    public class MCreatAssetCredit_RQ
    {
        public string MaKhachHang { get; set; }
        public string TenTaiSan { get; set; }
        public string NhanHieu { get; set; }
        public string ThongSoKyThuat { get; set; }
        public decimal DinhGiaTaiSan { get; set; }
        public decimal SoTienChoVay { get; set; }
        public decimal LaiXuatVay { get; set; }
        public decimal ThoiHanTraNo { get; set; }
        public decimal PhiTraNoTruocHan { get; set; }
        public List<string> DanhSachFileDinhKem { get; set; }
        public string GuidUser { get; set; }
    }

    public class MCreatAssetCredit
    {
        public string Id { get; set; }
        public string RFID { get; set; }
        public string MaKhachHang { get; set; }
        public string TenTaiSan { get; set; }
        public string NhanHieu { get; set; }
        public string ThongSoKyThuat { get; set; }
        public decimal? DinhGiaTaiSan { get; set; }
        public decimal? SoTienChoVay { get; set; }
        public decimal? LaiXuatVay { get; set; }
        public decimal? ThoiHanTraNo { get; set; }
        public decimal? PhiTraNoTruocHan { get; set; }
        public int TrangThai { get; set; }
        public string TenTrangThai { get; set; }
        public string LyDoKhongPheDuyet { get; set; }
        public string GhiChu { get; set; }
    }

    public class MCreatAssetCredit_RS : MBaseResponse<List<MCreatAssetCredit>>
    {

    }
}
