using HotelReservation.Exceptions;
using HotelReservation.Models;
using HotelReservation.ViewModels;
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

        public App()
        {
            _hotel = new Hotel("Imperial Hotel");
            
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.DataContext = new MainViewModel(_hotel);
            window.Show();
            base.OnStartup(e);
        }
    }
}
