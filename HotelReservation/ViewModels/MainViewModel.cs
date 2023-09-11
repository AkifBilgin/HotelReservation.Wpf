using HotelReservation.Models;
using HotelReservation.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;

        public MainViewModel(NavigationStore navigatinStore)
        {
            _navigationStore = navigatinStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
       
    }
}
