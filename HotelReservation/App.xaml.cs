using HotelReservation.Commands;
using HotelReservation.DbContexts;
using HotelReservation.Exceptions;
using HotelReservation.Models;
using HotelReservation.Services;
using HotelReservation.Stores;
using HotelReservation.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HotelReservation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Hotel _hotel;
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _hotel = new Hotel("Imperial Hotel");
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=hotelreservation.db").Options;
            using (HotelReservationDbContext reservationDbContext = new HotelReservationDbContext(options))
            {
                reservationDbContext.Database.Migrate();
            }
              
            _navigationStore.CurrentViewModel = CreateReservationListingViewModel();
            MainWindow window = new MainWindow();
            window.DataContext = new MainViewModel(_navigationStore);
            window.Show();
            base.OnStartup(e);
        }

        private MakeReservationViewModel CreateMakeReservationViewModel()
        {
            MakeReservationViewModel makeReservationViewModel = new MakeReservationViewModel(_hotel, new NavigationService(_navigationStore,  CreateReservationListingViewModel));
            return makeReservationViewModel;
        }

        private ReservationListingViewModel CreateReservationListingViewModel()
        {
            ReservationListingViewModel reservationListingViewModel = new ReservationListingViewModel(_hotel ,new NavigationService(_navigationStore, CreateMakeReservationViewModel));
            return reservationListingViewModel;
        }
    }
}
