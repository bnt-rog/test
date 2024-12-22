using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using PTR_DRS.Models;
using PTR_DRS.Repositories;
using PTR_DRS.Views;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTR_DRS.ViewModels
{
    [QueryProperty(nameof(Ride), nameof(Ride))]
    public partial class RiderViewModel : BaseViewModel
    {
        #region Variables

        private readonly RiderRepository RiderRepository;

        #endregion

        #region Properties

        [ObservableProperty]
        List<Rider> allRiders = new();

        [ObservableProperty]
        List<Rider> riders = new();

        [ObservableProperty]
        Ride ride;

        [ObservableProperty]
        List<Rider> selectedRiders;

        [ObservableProperty]
        bool sortABCState;

        [ObservableProperty]
        bool sortGroupState;

        [ObservableProperty]
        public string searchTerm;

        #endregion

        public RiderViewModel(RiderRepository riderRepository)
        {
            Title = "Renners toevoegen";
            RiderRepository = riderRepository;
            GetRiders();
        }

        #region Commands

        [ICommand]
        public async void AddRiderRide(object parameter)
        {
            RiderRepository.InsertRiderRide(SelectedRiders, Ride);
            await Shell.Current.GoToAsync($"../..");
        }

        [ICommand]
        public void SortABC(object parameter)
        {
            IsBusy = true;
            if (!sortABCState)
                Riders = Riders.OrderBy(r => r.LastName).ToList();
            else
                Riders.Reverse();
            sortABCState = !sortABCState;
            IsBusy = false;
        }

        [ICommand]
        public void SortGroup(object parameter)
        {
            IsBusy = true;
            var group = Ride.Group;
            if (!sortGroupState)
            {
                var query = riders.Select(r => new { Rider = r, Rides = r.Rides.Where(ride => ride.Group == group) })
                    .OrderByDescending(r => r.Rides.Count())
                    .ToDictionary(r => r.Rider, r => r.Rides.Count());
                Riders = new List<Rider>(query.Keys);
            }
            else
            {
                Riders.Reverse();
            }
            sortGroupState = !sortGroupState;
            IsBusy = false;
        }

        [ICommand]
        public void SearchName(object parameter)
        {
            List<Rider> searchRiders = new List<Rider>();
            if (string.IsNullOrEmpty(SearchTerm))
            {
                SearchTerm = string.Empty;
                Riders = AllRiders;
            }
            else
            {
                SearchTerm = SearchTerm.ToLowerInvariant();
                var fiteredItems = AllRiders.Where(r => r.FirstName.ToLowerInvariant().Contains(SearchTerm) || r.LastName.ToLowerInvariant().Contains(SearchTerm));

                if (fiteredItems is not null)
                {
                    foreach (var item in fiteredItems)
                    {
                        searchRiders.Add(item);
                    }
                }

                Riders = searchRiders.ToList();
            }
        }

        [ICommand]
        public void Clear()
        {
            IsBusy = true;
            SearchTerm = string.Empty;
            Riders = AllRiders;
            IsBusy = false;
        }

        public Command SelectedTagChangedCommand
        {
            get
            {
                return new Command((sender) =>
                {
                    List<Rider> riders = ((IEnumerable)sender).Cast<Rider>().ToList();
                    SelectedRiders = riders;
                });
            }
        }

        #endregion

        #region Functions

        public async void GetRiders()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var riders = await RiderRepository.GetRiders();

                if (Riders.Count != 0)
                    Riders.Clear();

                foreach (var rider in riders)
                {
                    Riders.Add(rider);
                }

                AllRiders = Riders;

                if (!sortABCState)
                    Riders = Riders.OrderBy(r => r.LastName).ToList();
                else
                    Riders.Reverse();
                sortABCState = !sortABCState;
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

        #endregion
    }
}
