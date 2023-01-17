using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PTR_DRS.Models;
using PTR_DRS.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTR_DRS.ViewModels
{
    public partial class RankingViewModel : BaseViewModel
    {
        #region Variables

        private readonly RiderRepository RiderRepository;

        #endregion

        #region Properties

        [ObservableProperty]
        ObservableCollection<Rider> riders = new();

        [ObservableProperty]
        int? totalKM;

        #endregion

        public RankingViewModel(RiderRepository riderRepository)
        {
            Title = "Klassement";
            RiderRepository = riderRepository;
            GetRiders();
        }

        #region Commands

        [ICommand]
        public void GroupA()
        {

        }

        [ICommand]
        public void GroupB()
        {

        }

        [ICommand]
        public void GroupC()
        {

        }

        [ICommand]
        public void GroupD()
        {

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
                    foreach (var ride in rider.Rides)
                    {
                        TotalKM += ride.KM;
                    }
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

        #endregion
    }
}
