using MauiApp1.ViewModels;

namespace MauiApp1;

public partial class MapPage : ContentPage
{
	public MapPage(MapViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}