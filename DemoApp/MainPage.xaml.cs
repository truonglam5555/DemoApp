using DemoApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace DemoApp
{
    public partial class MainPage : ContentPage
    {
        private VMMain vm;
        public MainPage()
        {
            InitializeComponent();
            vm = new VMMain();
            this.BindingContext = vm;
        }

        async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            var popupOrder = new Views.Popup.OderPage();
            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(popupOrder);
        }
    }

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
        private void DetailAct(Detail obj)
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
            buffet.Details.Add(new Detail { detail = "BF. Thịt bò" });
            buffet.Details.Add(new Detail { detail = "BF. Thịt heo" });
            buffet.Details.Add(new Detail { detail = "BF. Salad" });
            buffet.Details.Add(new Detail { detail = "BF. Cơm" });
            buffet.Details.Add(new Detail { detail = "BF. Món truyền thông" });
            buffet.Details.Add(new Detail { detail = "BF. Canh" });
            buffet.Details.Add(new Detail { detail = "BF. Lẩu" });
            buffet.Details.Add(new Detail { detail = "BF. Rau mì" });
            buffet.Details.Add(new Detail { detail = "BF. Tráng miệng" });

            var alacarte = new MMain();
            alacarte.Name = "ALACARTE";
            alacarte.Details.Add(new Detail { detail = "ALC. Best Seller" });
            alacarte.Details.Add(new Detail { detail = "ALC. SET" });
            alacarte.Details.Add(new Detail { detail = "ALC. Thịt bò"});


            var MonAn = new MonAn { Tittle = "Ba chỉ bò", Price = "109.000" };
            var MonAn1 = new MonAn { Tittle = "Ba chỉ bò", Price = "109.000" };
            var MonAn2 = new MonAn { Tittle = "Ba chỉ bò", Price = "109.000" };
            var MonAn3 = new MonAn { Tittle = "Ba chỉ bò", Price = "109.000" };
            _mMain.Add(buffet);
            _mMain.Add(alacarte);
            _monAn.Add(MonAn);
            _monAn.Add(MonAn1);
            _monAn.Add(MonAn2);
            _monAn.Add(MonAn3);

            DetailCmd = new Command<Detail>(DetailAct);


        }
        #endregion
    }
}
