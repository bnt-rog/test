using CommunityToolkit.Maui.Views;
using PTR_DRS.ViewModels;

namespace PTR_DRS.Views;

public partial class RiderPage : ContentPage
{
    public RiderViewModel RiderViewModel { get; set; }
    public RiderPage(RiderViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        RiderViewModel = viewModel;
    }

    private void AddRiders(object sender, EventArgs e)
    {
        this.ShowPopup(new RiderDialog(RiderViewModel));
    }
}