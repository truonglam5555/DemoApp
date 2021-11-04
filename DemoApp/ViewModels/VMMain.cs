using DemoApp.Models;
using System.Collections.ObjectModel;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;

namespace DemoApp.ViewModels
{
    public class VMMain : ObservableObject
    {
        bool isRunColor = true;
        public VMMain()
        {
            _mMain = new ObservableCollection<MMain>();
            _monAnList = new ObservableCollection<MonAnChiTiet>();
            GhostData();
        }

        #region Props
        private ObservableCollection<MMain> _mMain;
        public ObservableCollection<MMain> MMain { get => _mMain; set { SetProperty(ref _mMain, value); } }
        private ObservableCollection<Models.MonAnChiTiet> _monAnList;
        public ObservableCollection<Models.MonAnChiTiet> MonAnList { get => _monAnList; set { SetProperty(ref _monAnList, value); } }
        
        #endregion

        #region Cmds
        public Command DetailCmd { get; set; }
        #endregion

        #region Acts
        public void DetailAct(Detail obj)
        {
            
            //Action.Invoke(selectedItem);
        }
        #endregion

        #region Methods
        private void GhostData()
        {
            var buffet = new MMain();
            buffet.Name = "BUFFET";
            buffet.Details.Add(new Detail { detail = "BF. Thịt bò", ID = "001" ,BgItem = Color.BlanchedAlmond});
            buffet.Details.Add(new Detail { detail = "BF. Thịt heo", ID = "002" });
            buffet.Details.Add(new Detail { detail = "BF. Salad", ID = "003" });
            buffet.Details.Add(new Detail { detail = "BF. Cơm", ID = "004" });
            buffet.Details.Add(new Detail { detail = "BF. Món truyền thông", ID = "005" });
            buffet.Details.Add(new Detail { detail = "BF. Canh", ID = "006" });
            buffet.Details.Add(new Detail { detail = "BF. Lẩu", ID = "007" });
            buffet.Details.Add(new Detail { detail = "BF. Rau mì", ID = "008" });
            buffet.Details.Add(new Detail { detail = "BF. Tráng miệng", ID = "009" });

            var alacarte = new MMain();
            alacarte.Name = "ALACARTE";
            alacarte.Details.Add(new Detail { detail = "ALC. Best Seller", ID = "010" });
            alacarte.Details.Add(new Detail { detail = "ALC. SET", ID = "011" });
            alacarte.Details.Add(new Detail { detail = "ALC. Thịt bò", ID = "012" });

            _mMain.Add(buffet);
            _mMain.Add(alacarte);

            var thitbo = new MonAnChiTiet { Tittle = "Thịt bò", Price = "109.000", IDGroup = "001" }; _monAnList.Add(thitbo); _monAnList.Add(thitbo); _monAnList.Add(thitbo); _monAnList.Add(thitbo);
            var thitheo = new MonAnChiTiet { Tittle = "Thịt heo", Price = "109.000", IDGroup = "002" }; _monAnList.Add(thitheo); _monAnList.Add(thitheo); _monAnList.Add(thitheo); _monAnList.Add(thitheo);
            var Salad = new MonAnChiTiet { Tittle = "Salad", Price = "109.000", IDGroup = "003" }; _monAnList.Add(Salad); _monAnList.Add(Salad); _monAnList.Add(Salad); _monAnList.Add(Salad);

            DetailCmd = new Command<Detail>(DetailAct);


        }

        public Detail ScrollChangedSelect(string ID)
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
                        item.BgItem = Color.LightGoldenrodYellow;
                        return item;
                    }
                }
            }
            return null;
        }
        #endregion
    }
}
