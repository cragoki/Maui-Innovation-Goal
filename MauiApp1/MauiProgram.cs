using MauiApp1.Clients;
using MauiApp1.Clients.Interfaces;
using MauiApp1.Data;
using MauiApp1.Data.Repositories;
using MauiApp1.Data.Repositories.Intefaces;
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
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<MapPage>();
        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<ViewRoundPage>();
        builder.Services.AddSingleton<VisitStationPage>();

        return builder.Build();
    }

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<LoginViewModel>();
        mauiAppBuilder.Services.AddSingleton<MapViewModel>();
        mauiAppBuilder.Services.AddSingleton<HomeViewModel>();
        mauiAppBuilder.Services.AddSingleton<ViewRoundViewModel>();
        mauiAppBuilder.Services.AddSingleton<MainLayoutViewModel>();

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
    {
        //Repositories
        mauiAppBuilder.Services.AddSingleton<ITokenRepository, TokenRepository>();
        mauiAppBuilder.Services.AddSingleton<IUserRepository, UserRepository>();
        mauiAppBuilder.Services.AddSingleton<IPollingStationRepository, PollingStationRepository>();

        //Services
        mauiAppBuilder.Services.AddSingleton<IAuthService, AuthService>();
        mauiAppBuilder.Services.AddSingleton<IPollingStationService, PollingStationService>();

        //Clients
        mauiAppBuilder.Services.AddSingleton<IPollingStationClient, PollingStationClient>();

        //Context
        mauiAppBuilder.Services.AddScoped<ILocalMauiContext, LocalMauiContext>();

        return mauiAppBuilder;
    }
}

