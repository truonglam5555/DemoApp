using DemoApp.Models;
using System;
using System.Collections.ObjectModel;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;
using System.Linq;
using DemoApp.Common.Bussiness;

namespace DemoApp.ViewModels
{
    public class VMMain : ObservableObject
    {
        public Action<MonAnChiTiet> Action;
        public VMMain()
        {
            _mMain = new ObservableCollection<MMain>();
            _monAnList = new ObservableCollection<MonAnChiTiet>();
            ThemMonGoiCmd = new Command<MonAnChiTiet>(ThemVaoMonDangGoi);
            DangXuatCmd = new Command(DangXuatAction);
            GhostData();
        }

        #region Props
        private ObservableCollection<MMain> _mMain;
        public ObservableCollection<MMain> MMain { get => _mMain; set { SetProperty(ref _mMain, value); } }
        private ObservableCollection<MonAnChiTiet> _monAnList;
        public ObservableCollection<MonAnChiTiet> MonAnList { get => _monAnList; set { SetProperty(ref _monAnList, value); } }
        #endregion

        #region Cmds
        public Command ThemMonGoiCmd { get; set; }
        public Command DangXuatCmd { get; set; }
        #endregion

        #region Acts
        //public void DetailAct(Detail obj)
        //{
        //    foreach (var header in MMain)
        //    {
        //        foreach (var item in header.Details)
        //        {
        //            item.isSelected = false;
        //            item.BgItem = Color.Transparent;
        //        }
        //    }

        //    obj.isSelected = true;
        //    obj.BgItem = Color.LightGoldenrodYellow;
        //    var selectedItem = MonAnList.Where(x => x.IDGroup.Equals(obj.ID)).FirstOrDefault();
        //    Action.Invoke(selectedItem);
        //}

        void ThemVaoMonDangGoi(MonAnChiTiet monAn)
        {
            if(monAn!= null)
            {
                if (App.dataBussiness == null)
                    App.dataBussiness = new DataBussiness();
                var item = App.dataBussiness.GetAllRowMonDat().Where(x=>x.ID == monAn.ID).FirstOrDefault();
                if(item == null)
                {
                    App.dataBussiness.AddRow(new MMonDat
                    {
                        ID = monAn.ID,
                        IDGroup = monAn.IDGroup,
                        Tittle = monAn.Tittle,
                        Price = monAn.Price,
                        SoLuong = 1,
                        isOrder = false,
                    });
                }
                else
                {
                    item.SoLuong = item.SoLuong++;
                    App.dataBussiness.UpdateRow(item);
                }
            }
        }

        async void DangXuatAction()
        {
            var ok = await App.Current.MainPage.DisplayAlert("Thông báo", "Bạn có muốn đăng xuất?", "Đồng ý", "Hủy");
            if(ok)
            {
                App.Current.MainPage = new Views.Acount.LoginPage();
            }
        }
        #endregion

        #region Methods
        private void GhostData()
        {
            var buffet = new MMain();
            buffet.Name = "BUFFET";
            buffet.Details.Add(new Detail { detail = "BF. Cơm", ID = "004" });
            buffet.Details.Add(new Detail { detail = "BF. Món truyền thông", ID = "005" });
            buffet.Details.Add(new Detail { detail = "BF. Canh", ID = "006" });
            buffet.Details.Add(new Detail { detail = "BF. Lẩu", ID = "007" });
            buffet.Details.Add(new Detail { detail = "BF. Rau mì", ID = "008" });
            buffet.Details.Add(new Detail { detail = "BF. Tráng miệng", ID = "009" });

            buffet.Details.Add(new Detail { detail = "BF. Thịt bò", ID = "001", BgItem = Color.Orange });
            buffet.Details.Add(new Detail { detail = "BF. Thịt heo", ID = "002" });
            buffet.Details.Add(new Detail { detail = "BF. Salad", ID = "003" });

            var alacarte = new MMain();
            alacarte.Name = "ALACARTE";
            alacarte.Details.Add(new Detail { detail = "ALC. Best Seller", ID = "010" });
            alacarte.Details.Add(new Detail { detail = "ALC. SET", ID = "011" });
            alacarte.Details.Add(new Detail { detail = "ALC. Thịt bò", ID = "012" });

            _mMain.Add(buffet);
            _mMain.Add(alacarte);

            //DetailCmd = new Command<Detail>(DetailAct);

            MonAnList.Add(new MonAnChiTiet
            {
                Tittle = "Thịt bò 1",
                Price = "109",
                IDGroup = "001",
                ID ="001",
            });
            MonAnList.Add(new MonAnChiTiet
            {
                Tittle = "Thịt bò 2",
                Price = "109",
                IDGroup = "001",
                ID = "002",
                isImageOff = true,
            });
            MonAnList.Add(new MonAnChiTiet
            {
                Tittle = "Thịt bò 3",
                Price = "109",
                IDGroup = "001",
                ID = "003",
            });
            MonAnList.Add(new MonAnChiTiet
            {
                Tittle = "Thịt bò 4",
                Price = "109",
                IDGroup = "001",
                ID = "004",
            });
            MonAnList.Add(new MonAnChiTiet
            {
                Tittle = "Thịt bò 5",
                Price = "109",
                IDGroup = "001",
                ID = "005",
            });
            MonAnList.Add(new MonAnChiTiet
            {
                Tittle = "Thịt heo 1",
                Price = "109",
                IDGroup = "002",
                ID = "006",
                isImageOff = true,
            });
            MonAnList.Add(new MonAnChiTiet
            {
                Tittle = "Thịt heo 2",
                Price = "109",
                IDGroup = "002",
                ID = "007",
            });
            MonAnList.Add(new MonAnChiTiet
            {
                Tittle = "Thịt heo 3",
                Price = "109",
                IDGroup = "002",
                ID = "008",
            });
            MonAnList.Add(new MonAnChiTiet
            {
                Tittle = "Thịt heo 4",
                Price = "109",
                IDGroup = "002",
                 ID = "009",
            });
            MonAnList.Add(new MonAnChiTiet
            {
                Tittle = "Thịt heo 5",
                Price = "109",
                IDGroup = "002",
                ID = "010",
            });
            MonAnList.Add(new MonAnChiTiet
            {
                Tittle = "Salad 1",
                Price = "109",
                IDGroup = "003",
                ID = "011",
            });
            MonAnList.Add(new MonAnChiTiet
            {
                Tittle = "Salad 2",
                Price = "109",
                IDGroup = "003",
                ID = "012",
            });
            MonAnList.Add(new MonAnChiTiet
            {
                Tittle = "Salad 3",
                Price = "109",
                IDGroup = "003",
                ID = "013",
                isImageOff = true,
            });
            MonAnList.Add(new MonAnChiTiet
            {
                Tittle = "Salad 4",
                Price = "109",
                IDGroup = "003",
                ID = "014",
            });
        }

        public void ScrollChangedSelect(string ID)
        {
            foreach (var header in MMain)
            {
                foreach (var item in header.Details)
                {
                    item.isSelected = false;
                    item.BgItem = Color.Transparent;
                }
            }

            foreach (var header in MMain)
            {
                foreach (var item in header.Details)
                {
                    if (item.ID == ID)
                    {
                        item.isSelected = true;
                        item.BgItem = Color.Orange;
                    }
                }
            }
        }
        #endregion
    }
}
