using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PTR_DRS.Models;
using PTR_DRS.Repositories;
using PTR_DRS.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTR_DRS.ViewModels
{
    public partial class RideViewModel : BaseViewModel
    {
        private readonly RideRepository RideRepository;

        [ObservableProperty]
        Ride ride;

        [ObservableProperty]
        List<Ride> rides;

        public RideViewModel(RideRepository rideRepository)
        {
            Title = "Rit aanmaken";
            RideRepository = rideRepository;
            Ride = new Ride();
        }

        [ICommand]
        public async void AddRide(object parameter)
        {
            Ride ride = new Ride();
            ride.Name = Ride.Name;
            ride.KM = Ride.KM;
            ride.Group = Ride.Group;

            RideRepository.InsertRide(ride);

            await Shell.Current.GoToAsync($"{nameof(RiderPage)}",
                new Dictionary<string, object>
                {
                    ["Ride"] = ride
                });
        }

        public async void GetRides()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                List<Ride> rides = await RideRepository.GetRides();

                if (Rides.Count != 0)
                    Rides.Clear();

                foreach (var ride in rides)
                {
                    Rides.Add(ride);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error", "GetRiders", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
