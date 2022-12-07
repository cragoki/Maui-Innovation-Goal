using MauiApp1.Services.Interfaces;
using MauiApp1.ViewModels;
using SharedComponents.Model.Request;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
    public MainPage(LoginViewModel vm)
	{
        BindingContext = vm;
        InitializeComponent();
    }
}

