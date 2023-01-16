using PTR_DRS.ViewModels;

namespace PTR_DRS.Views;

public partial class MainPage : ContentPage
{
    public MainPage(BaseViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}

