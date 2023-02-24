using MauiApp1.ViewModels;

namespace MauiApp1;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(MapPage), typeof(MapPage));
        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        Routing.RegisterRoute(nameof(ViewRoundPage), typeof(ViewRoundPage));
        Routing.RegisterRoute(nameof(VisitStationPage), typeof(VisitStationPage));
    }
}
