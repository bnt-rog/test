using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PTR_DRS.Views;

namespace PTR_DRS.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        bool isBusy;
        public bool IsNotBusy => !IsBusy;

        [ObservableProperty]
        string title;

        public BaseViewModel()
        {
            Title = "Puitenrijders";
        }

        [ICommand]
        public async void GoRidePage()
        {
            await Shell.Current.GoToAsync($"{nameof(RidePage)}");
        }
    }
}
