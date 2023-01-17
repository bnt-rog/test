using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PTR_DRS.Views;

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
    }
}
