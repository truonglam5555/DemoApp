using DemoApp.Models;
using System.Collections.ObjectModel;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;
using System.Linq;

namespace DemoApp.ViewModels
{
    public class VMMain : ObservableObject
    {
        public VMMain()
        {
            _mMain = new ObservableCollection<MMain>();
            _monAn = new ObservableCollection<MonAn>();
            GhostData();
        }

        #region Props
        private ObservableCollection<MMain> _mMain;
        public ObservableCollection<MMain> MMain { get => _mMain; set { SetProperty(ref _mMain, value); } }
        private ObservableCollection<MonAn> _monAn;
        public ObservableCollection<MonAn> MMonAn { get => _monAn; set { SetProperty(ref _monAn, value); } }
        #endregion

        #region Cmds
        public Command DetailCmd { get; set; }
        #endregion

        #region Acts
        public void DetailAct(Detail obj)
        {
            foreach (var header in MMain)
            {
                foreach (var item in header.Details)
                {
                    item.isSelected = false;
                    item.BgItem = Color.Transparent;
                }
            }

            obj.isSelected = true;
            obj.BgItem = Color.LightGoldenrodYellow;
        }
        #endregion

        #region Methods
        private void GhostData()
        {
            var buffet = new MMain();
            buffet.Name = "BUFFET";
            buffet.Details.Add(new Detail { detail = "BF. Thịt bò", ID = "001" });
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

            var thitbo = new MonAn { Tittle = "Thịt bò", Price = "109.000", IDGroup = "001" }; _monAn.Add(thitbo); _monAn.Add(thitbo); _monAn.Add(thitbo); _monAn.Add(thitbo);
            var thitheo = new MonAn { Tittle = "Thịt heo", Price = "109.000", IDGroup = "002" }; _monAn.Add(thitheo); _monAn.Add(thitheo); _monAn.Add(thitheo); _monAn.Add(thitheo);
            var Salad = new MonAn { Tittle = "Salad", Price = "109.000", IDGroup = "003" }; _monAn.Add(Salad); _monAn.Add(Salad); _monAn.Add(Salad); _monAn.Add(Salad);

            DetailCmd = new Command<Detail>(DetailAct);


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
                        item.BgItem = Color.LightGoldenrodYellow;
                    }
                }
            }
        }
        #endregion
    }
}
