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
        ObservableCollection<Ranking> rankings = new();

        [ObservableProperty]
        int? totalKM;

        [ObservableProperty]
        bool sortAll;

        [ObservableProperty]
        bool sortA;

        [ObservableProperty]
        bool sortB;

        [ObservableProperty]
        bool sortC;

        [ObservableProperty]
        bool sortD;

        #endregion

        public RankingViewModel(RiderRepository riderRepository)
        {
            Title = "Klassement";
            RiderRepository = riderRepository;
            GetRiders();
        }

        #region Commands

        [ICommand]
        public void GroupAll()
        {
            Rankings = GetRankings(Riders);

            if (!sortAll)
                Rankings = Rankings.OrderByDescending(r => r.TotalKM).ToObservableCollection();
            else
                Rankings = Rankings.Reverse().ToObservableCollection();
            sortAll = !sortAll;
        }

        [ICommand]
        public void GroupA()
        {
            var group = "A";
            Rankings = GetRankings(Riders);

            if (!sortA)
            {
                Rankings.ToList().ForEach(ranking =>
                {
                    var groupRides = ranking.Rider.Rides.Where(ride => ride.Group == group);
                    ranking.TotalRides = groupRides.Count();
                    ranking.TotalKM = groupRides.Sum(ride => ride.KM);
                });
                Rankings = Rankings.OrderByDescending(r => r.TotalKM).ToObservableCollection();
            }
            else
            {
                Rankings.ToList().ForEach(ranking =>
                {
                    var groupRides = ranking.Rider.Rides.Where(ride => ride.Group == group);
                    ranking.TotalRides = groupRides.Count();
                    ranking.TotalKM = groupRides.Sum(ride => ride.KM);
                });
                Rankings = Rankings.OrderBy(r => r.TotalKM).ToObservableCollection();
            }
            sortA = !sortA;
        }

        [ICommand]
        public void GroupB()
        {
            var group = "B";
            Rankings = GetRankings(Riders);

            if (!sortB)
            {
                Rankings.ToList().ForEach(ranking =>
                {
                    var groupRides = ranking.Rider.Rides.Where(ride => ride.Group == group);
                    ranking.TotalRides = groupRides.Count();
                    ranking.TotalKM = groupRides.Sum(ride => ride.KM);
                });
                Rankings = Rankings.OrderByDescending(r => r.TotalKM).ToObservableCollection();
            }
            else
            {
                Rankings.ToList().ForEach(ranking =>
                {
                    var groupRides = ranking.Rider.Rides.Where(ride => ride.Group == group);
                    ranking.TotalRides = groupRides.Count();
                    ranking.TotalKM = groupRides.Sum(ride => ride.KM);
                });
                Rankings = Rankings.OrderBy(r => r.TotalKM).ToObservableCollection();
            }
            sortB = !sortB;
        }

        [ICommand]
        public void GroupC()
        {
            var group = "C";
            Rankings = GetRankings(Riders);

            if (!sortC)
            {
                Rankings.ToList().ForEach(ranking =>
                {
                    var groupRides = ranking.Rider.Rides.Where(ride => ride.Group == group);
                    ranking.TotalRides = groupRides.Count();
                    ranking.TotalKM = groupRides.Sum(ride => ride.KM);
                });
                Rankings = Rankings.OrderByDescending(r => r.TotalKM).ToObservableCollection();
            }
            else
            {
                Rankings.ToList().ForEach(ranking =>
                {
                    var groupRides = ranking.Rider.Rides.Where(ride => ride.Group == group);
                    ranking.TotalRides = groupRides.Count();
                    ranking.TotalKM = groupRides.Sum(ride => ride.KM);
                });
                Rankings = Rankings.OrderBy(r => r.TotalKM).ToObservableCollection();
            }
            sortC = !sortC;
        }

        [ICommand]
        public void GroupD()
        {
            var group = "D";
            Rankings = GetRankings(Riders);

            if (!sortD)
            {
                Rankings.ToList().ForEach(ranking =>
                {
                    var groupRides = ranking.Rider.Rides.Where(ride => ride.Group == group);
                    ranking.TotalRides = groupRides.Count();
                    ranking.TotalKM = groupRides.Sum(ride => ride.KM);
                });
                Rankings = Rankings.OrderByDescending(r => r.TotalKM).ToObservableCollection();
            }
            else
            {
                Rankings.ToList().ForEach(ranking =>
                {
                    var groupRides = ranking.Rider.Rides.Where(ride => ride.Group == group);
                    ranking.TotalRides = groupRides.Count();
                    ranking.TotalKM = groupRides.Sum(ride => ride.KM);
                });
                Rankings = Rankings.OrderByDescending(r => r.TotalKM).ToObservableCollection();
            }
            sortD = !sortD;
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

                Rankings = GetRankings(Riders);
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

        public ObservableCollection<Ranking> GetRankings(ObservableCollection<Rider> riders)
        {
            var rankings = riders
                .Select(rider => new Ranking
                {
                    Rider = rider,
                    TotalKM = rider.Rides.Sum(ride => ride.KM),
                    TotalRides = rider.Rides.Count
                })
                .OrderByDescending(r => r.TotalKM)
                .ToObservableCollection();
            return rankings;
        }

        #endregion
    }
}
