using DemoApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.CommunityToolkit.ObjectModel;

namespace DemoApp.ViewModels
{
    public class VMOrder : ObservableObject
    {
        public VMOrder(ObservableCollection<OrderList> ordered, ObservableCollection<OrderList> ordering)
        {
            _ordered = ordered;
            _ordering = ordering;
        }
        #region Props

        private ObservableCollection<OrderList> _ordered;
        public ObservableCollection<OrderList> Ordered { get => _ordered; set { SetProperty(ref _ordered, value); } }
        private ObservableCollection<OrderList> _ordering;
        public ObservableCollection<OrderList> Ordering { get => _ordering; set { SetProperty(ref _ordering, value); } }
        #endregion

        #region Cmds

        #endregion

        #region Acts

        #endregion

        #region Methods

        #endregion
    }
}
