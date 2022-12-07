using MauiApp1.Repositories;
using MauiApp1.Repositories.Interfaces;
using MauiApp1.Services;
using MauiApp1.Services.Interfaces;
using MauiApp1.ViewModels;
namespace MauiApp1;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .RegisterAppServices()
            .RegisterViewModels()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.UseMauiMaps();
        //Pages
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MapPage>();

        //ViewModels
        builder.Services.AddSingleton<LoginViewModel>();
        builder.Services.AddSingleton<MapViewModel>();

        return builder.Build();
    }

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<ViewModels.LoginViewModel>();

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
    {
        //Repositories
        mauiAppBuilder.Services.AddSingleton<ITokenRepository, TokenRepository>();
        mauiAppBuilder.Services.AddSingleton<IUserRepository, UserRepository>();
        //Services
        mauiAppBuilder.Services.AddSingleton<IAuthService, AuthService>();

        return mauiAppBuilder;
    }
}

