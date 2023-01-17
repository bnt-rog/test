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
        #region Variables

        private readonly RideRepository RideRepository;

        #endregion

        #region Properties

        [ObservableProperty]
        Ride ride;

        [ObservableProperty]
        List<Ride> rides;

        [ObservableProperty]
        List<string> groups;

        #endregion

        public RideViewModel(RideRepository rideRepository)
        {
            Title = "Rit aanmaken";
            RideRepository = rideRepository;
            Ride = new Ride() { Date = DateTime.Now, KM = null };
            GetGroups();
        }

        #region Commands

        [ICommand]
        public async void AddRide(object parameter)
        {
            Ride ride = new Ride();
            ride.Name = Ride.Name;
            ride.KM = Ride.KM;
            ride.Date = Ride.Date;
            ride.Group = Ride.Group;

            //RideRepository.InsertRide(ride);

            await Shell.Current.GoToAsync($"{nameof(RiderPage)}",
                new Dictionary<string, object>
                {
                    ["Ride"] = ride
                });
        }

        #endregion

        #region Functions
        
        public async void GetGroups()
        {
            if (IsBusy)
                return;

            try
            {
                string[] groupsLetters = { "A", "B", "C", "D" };
                Groups = new List<string>(groupsLetters);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error", "GetGroups", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion
    }
}
