namespace MauiApp1.Shared;

public partial class NavigationFlyoutPage : FlyoutPage
{
	public NavigationFlyoutPage()
	{
        InitializeComponent();
        Routing.RegisterRoute(nameof(MapPage), typeof(MapPage));
        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        Routing.RegisterRoute(nameof(ViewRoundPage), typeof(ViewRoundPage));
        Routing.RegisterRoute(nameof(VisitStationPage), typeof(VisitStationPage));
    }
}