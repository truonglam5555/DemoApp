using DemoApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace DemoApp.ViewModels
{
    public class VMOrder : ObservableObject
    {
        public VMOrder()
        {
            _ordered = new ObservableCollection<MMonDat>();
            _ordering = new ObservableCollection<MMonDat>();
            HuyMonCmd = new Command(HuyMonAction);
            XacNhanMonCmd = new Command(XacNhanMonAction);
            LoadDataOedering();

        }
        #region Props
        private ObservableCollection<MMonDat> _ordered;
        public ObservableCollection<MMonDat> Ordered { get => _ordered; set { SetProperty(ref _ordered, value); } }
        private ObservableCollection<MMonDat> _ordering;
        public ObservableCollection<MMonDat> Ordering { get => _ordering; set { SetProperty(ref _ordering, value); } }
        #endregion

        #region Cmds
        public Command HuyMonCmd { get; set; }
        public Command XacNhanMonCmd { get; set; }
        #endregion

        #region Acts
        void HuyMonAction()
        {
            Ordered.Clear();
            App.dataBussiness.DeleteAllRow<MMonDat>();
        }

        void XacNhanMonAction()
        {
            foreach(var item in App.dataBussiness.GetAllRowMonDat())
            {
                item.isOrder = true;
                App.dataBussiness.UpdateRow(item);
            }
        }

        #endregion

        #region Methods
        public void LoadDataOedering()
        {
            foreach(var item in App.dataBussiness.GetAllRowMonDat())
            {
                if(!item.isOrder)
                {
                    Ordering.Add(item);
                }
            }
        }

        public void LoadDataOeder()
        {
            Ordered.Clear();
            foreach (var item in App.dataBussiness.GetAllRowMonDat())
            {
                if (item.isOrder)
                {
                    Ordered.Add(item);
                }
            }
        }
        #endregion
    }
}
