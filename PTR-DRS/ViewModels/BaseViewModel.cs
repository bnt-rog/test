using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PTR_DRS.Models;
using PTR_DRS.Repositories;
using PTR_DRS.Views;
using System.Diagnostics;

namespace PTR_DRS.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        #region Properties

        [ObservableProperty]
        bool isBusy;

        public bool IsNotBusy => !IsBusy;

        [ObservableProperty]
        string title;

        #endregion

        public BaseViewModel()
        {
            Title = "Puitenrijders";
        }

        #region Commands

        [ICommand]
        public async void GoRidePage()
        {
            await Shell.Current.GoToAsync($"{nameof(RidePage)}");
        }

        #endregion

        #region Functions

        public async void ImportRiders()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("test.json");
            using var reader = new StreamReader(stream);

            using (reader)
            {
                string json = reader.ReadToEnd();
                List<Rider> riders = JsonConvert.DeserializeObject<List<Rider>>(json);

                foreach (var rider in riders)
                {
                    RiderRepository.InsertRider(rider);
                }
            }
        }

        #endregion
    }
}
