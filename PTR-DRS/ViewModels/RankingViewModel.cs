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
                foreach (var ranking in Rankings)
                {
                    int? totalKM = 0;
                    int? totalRides = 0;
                    foreach (var ride in ranking.Rider.Rides)
                    {
                        if (ride.Group == group)
                        {
                            totalRides++;
                            totalKM += ride.KM;
                        }
                    }
                    ranking.TotalRides = totalRides;
                    ranking.TotalKM = totalKM;
                }
                Rankings = Rankings.OrderByDescending(r => r.TotalKM).ToObservableCollection();
            }
            else
            {
                foreach (var ranking in Rankings)
                {
                    int? totalKM = 0;
                    int? totalRides = 0;
                    foreach (var ride in ranking.Rider.Rides)
                    {
                        if (ride.Group == group)
                        {
                            totalRides++;
                            totalKM += ride.KM;
                        }
                    }
                    ranking.TotalRides = totalRides;
                    ranking.TotalKM = totalKM;
                }
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
                foreach (var ranking in Rankings)
                {
                    int? totalKM = 0;
                    int? totalRides = 0;
                    foreach (var ride in ranking.Rider.Rides)
                    {
                        if (ride.Group == group)
                        {
                            totalRides++;
                            totalKM += ride.KM;
                        }
                    }
                    ranking.TotalRides = totalRides;
                    ranking.TotalKM = totalKM;
                }
                Rankings = Rankings.OrderByDescending(r => r.TotalKM).ToObservableCollection();
            }
            else
            {
                foreach (var ranking in Rankings)
                {
                    int? totalKM = 0;
                    int? totalRides = 0;
                    foreach (var ride in ranking.Rider.Rides)
                    {
                        if (ride.Group == group)
                        {
                            totalRides++;
                            totalKM += ride.KM;
                        }
                    }
                    ranking.TotalRides = totalRides;
                    ranking.TotalKM = totalKM;
                }
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
                foreach (var ranking in Rankings)
                {
                    int? totalKM = 0;
                    int? totalRides = 0;
                    foreach (var ride in ranking.Rider.Rides)
                    {
                        if (ride.Group == group)
                        {
                            totalRides++;
                            totalKM += ride.KM;
                        }
                    }
                    ranking.TotalRides = totalRides;
                    ranking.TotalKM = totalKM;
                }
                Rankings = Rankings.OrderByDescending(r => r.TotalKM).ToObservableCollection();
            }
            else
            {
                foreach (var ranking in Rankings)
                {
                    int? totalKM = 0;
                    int? totalRides = 0;
                    foreach (var ride in ranking.Rider.Rides)
                    {
                        if (ride.Group == group)
                        {
                            totalRides++;
                            totalKM += ride.KM;
                        }
                    }
                    ranking.TotalRides = totalRides;
                    ranking.TotalKM = totalKM;
                }
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
                foreach (var ranking in Rankings)
                {
                    int? totalKM = 0;
                    int? totalRides = 0;
                    foreach (var ride in ranking.Rider.Rides)
                    {
                        if (ride.Group == group)
                        {
                            totalRides++;
                            totalKM += ride.KM;
                        }
                    }
                    ranking.TotalRides = totalRides;
                    ranking.TotalKM = totalKM;
                }
                Rankings = Rankings.OrderByDescending(r => r.TotalKM).ToObservableCollection();
            }
            else
            {
                foreach (var ranking in Rankings)
                {
                    int? totalKM = 0;
                    int? totalRides = 0;
                    foreach (var ride in ranking.Rider.Rides)
                    {
                        if (ride.Group == group)
                        {
                            totalRides++;
                            totalKM += ride.KM;
                        }
                    }
                    ranking.TotalRides = totalRides;
                    ranking.TotalKM = totalKM;
                }
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
            var rankings = new ObservableCollection<Ranking>();
            foreach (var rider in riders)
            {
                int? totalKM = 0;
                foreach (var ride in rider.Rides)
                {
                    totalKM += ride.KM;
                }
                Ranking ranking = new Ranking()
                {
                    Rider = rider,
                    TotalKM = totalKM,
                    TotalRides = rider.Rides.Count
                };
                rankings.Add(ranking);
            }
            rankings = rankings.OrderByDescending(r => r.TotalKM).ToObservableCollection();
            return rankings;
        }

        #endregion
    }
}
