using PTR_DRS.ViewModels;

namespace PTR_DRS.Views;

public partial class RankingPage : ContentPage
{
	public RankingPage(RiderViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}