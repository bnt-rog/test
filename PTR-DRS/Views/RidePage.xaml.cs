using PTR_DRS.ViewModels;

namespace PTR_DRS.Views;

public partial class RidePage : ContentPage
{
    public RidePage(RideViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}