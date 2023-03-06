using Microsoft.Maui.ApplicationModel;

namespace PTR_DRS;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
        UserAppTheme = AppTheme.Light;
    }
}
