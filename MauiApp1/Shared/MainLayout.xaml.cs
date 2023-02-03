using MauiApp1.ViewModels;

namespace MauiApp1;

public partial class MainLayout : Shell
{
	public MainLayout()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(MapPage), typeof(MapPage));
        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        Routing.RegisterRoute(nameof(ViewRoundPage), typeof(ViewRoundPage));
        Routing.RegisterRoute(nameof(VisitStationPage), typeof(VisitStationPage));

    }
}
