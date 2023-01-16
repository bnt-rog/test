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
        private readonly RiderRepository RiderRepository;

        [ObservableProperty]
        ObservableCollection<Rider> riders = new();

        [ObservableProperty]
        Ride ride;

        [ObservableProperty]
        List<Rider> selectedRiders;

        [ObservableProperty]
        bool sortABCState;

        public RiderViewModel(RiderRepository riderRepository)
        {
            Title = "Renners toevoegen";
            RiderRepository = riderRepository;
            GetRiders();
        }

        [ICommand]
        public async void AddRiderRide(object parameter)
        {
            RiderRepository.InsertRiderRide(SelectedRiders, Ride);
            await Shell.Current.GoToAsync($"../..");
        }

        [ICommand]
        public async void SortABC(object parameter)
        {
            if (!sortABCState)
                Riders = Riders.OrderBy(r => r.LastName).ToObservableCollection();
            else
                Riders = Riders.OrderByDescending(r => r.LastName).ToObservableCollection();
            sortABCState = !sortABCState;
        }

        [ICommand]
        public async void SortGroup(object parameter)
        {

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
