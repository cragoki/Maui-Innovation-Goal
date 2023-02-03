using MauiApp1.ViewModels;

namespace MauiApp1;

public partial class ViewRoundPage : ContentPage
{
	public ViewRoundPage(ViewRoundViewModel vm)
	{
        BindingContext = vm;
        InitializeComponent();
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await (BindingContext as ViewRoundViewModel).GetPollingStationsAsync();
    }
}