using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SQLite;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace DemoApp.Models
{
    public class MMain
    {
        public string Name { get; set; }
        public ObservableCollection<Detail> Details { get; set; } = new ObservableCollection<Detail>();
    }

    public class Detail: ObservableObject
    {
        public string ID { get; set; }
        public string detail { get; set; }
        public bool isSelected { get; set; } = false;
        public Color BgItem { get => _bgItem; set { SetProperty(ref _bgItem, value); } }

        private Color _bgItem = Color.Transparent;
    }
    public class MonAnChiTiet: ObservableObject
    {
        public string ID { get; set; }
        public string IDGroup { get; set; }
        public string HinhMonAn { get; set; }
        public string Price { get; set; }
        public string Tittle { get; set; }
    }

    public class MMonDat
    {
        [PrimaryKey, AutoIncrement]
        public long PK { get; set; }
        public string ID { get; set; }
        public string IDGroup { get; set; }
        public string HinhMonAn { get; set; }
        public string Price { get; set; }
        public string Tittle { get; set; }
        public int SoLuong { get; set; }
        public bool isOrder { get; set; }
        public MMonDat()
        {
            isOrder = false;
        }
    }

    public class MMonDaDat
    {
        [PrimaryKey, AutoIncrement]
        public long PK { get; set; }
        public string ID { get; set; }
        public string IDGroup { get; set; }
        public string HinhMonAn { get; set; }
        public string Price { get; set; }
        public string Tittle { get; set; }
        public int SoLuong { get; set; }
        public bool isOrder { get; set; }
        public MMonDaDat()
        {
            isOrder = false;
        }
    }
}
