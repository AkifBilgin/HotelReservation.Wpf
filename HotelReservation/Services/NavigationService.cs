using HotelReservation.Stores;
using HotelReservation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Services
{
    public class NavigationService
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<ViewModelBase> _cretaeViewModel;

        public NavigationService(NavigationStore navigationStore, Func<ViewModelBase> cretaeViewModel)
        {
            _navigationStore = navigationStore;
            _cretaeViewModel = cretaeViewModel;
        }
        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _cretaeViewModel();
        }
    }
}
