using MauiApp1.ViewModels;

namespace MauiApp1;

public partial class HomePage : ContentPage
{
    public HomePage(HomeViewModel vm)
	{
        BindingContext = vm;
        InitializeComponent();
    }
}