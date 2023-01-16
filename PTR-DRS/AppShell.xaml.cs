using PTR_DRS.Views;

namespace PTR_DRS;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(RidePage), typeof(RidePage));
        Routing.RegisterRoute(nameof(RiderPage), typeof(RiderPage));
    }
}
