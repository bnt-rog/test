using PTR_DRS.ViewModels;

namespace PTR_DRS.Views;

public partial class RankingPage : ContentPage
{
	public RankingPage(RankingViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}