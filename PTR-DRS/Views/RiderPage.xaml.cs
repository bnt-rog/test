using PTR_DRS.ViewModels;
using System.Collections.ObjectModel;

namespace PTR_DRS.Views;

public partial class RiderPage : ContentPage
{
    public RiderPage(RiderViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}