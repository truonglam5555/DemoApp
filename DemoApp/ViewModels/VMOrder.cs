using DemoApp.Models;
using DemoApp.Views.Popup;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace DemoApp.ViewModels
{
    public class VMOrder : ObservableObject
    {
        public bool isChanged = true;
        public VMOrder()
        {
            _ordered = new ObservableCollection<MMonDat>();
            _ordering = new ObservableCollection<MMonDat>();
            HuyMonCmd = new Command(HuyMonAction);
            XacNhanMonCmd = new Command(XacNhanMonAction);
            GhiChuCmd = new Command<MMonDat>(GhiChuAction);
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
        public Command GhiChuCmd { get; set; }
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
            Ordering.Clear();
        }

        async void GhiChuAction(MMonDat monDat)
        {
            if(monDat != null)
            {
                var popupnote = new NotePage(monDat.Note);
                await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(popupnote);
                popupnote.Resutl += (s,e)=> {
                    if(!string.IsNullOrEmpty(e))
                    {
                        var item = App.dataBussiness.GetAllRowMonDat().Where(x => x.ID == monDat.ID).FirstOrDefault();
                        item.Note = e;
                        App.dataBussiness.UpdateRow(item);
                        Ordering.Clear();
                        LoadDataOedering();
                    }
                };
            }
        }

        #endregion

        #region Methods
        internal void DeleteOrderAction(MMonDat item)
        {
            App.dataBussiness.DeleteOneRow(item);
            Ordering.Remove(item);
        }
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
