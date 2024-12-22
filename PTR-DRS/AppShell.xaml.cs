using PTR_DRS.Views;

namespace PTR_DRS;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(RidePage), typeof(RidePage));
        Routing.RegisterRoute(nameof(RiderPage), typeof(RiderPage));
        Routing.RegisterRoute(nameof(RiderDialog), typeof(RiderDialog));
        Routing.RegisterRoute(nameof(RankingPage), typeof(RankingPage));
    }
}
