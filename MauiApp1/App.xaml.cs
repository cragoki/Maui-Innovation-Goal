using MauiApp1.Shared;

namespace MauiApp1;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        //WE WILL WANT TO CHECK IF USER IS LOGGED IN TO DETERMINE THE MAIN PAGE
        MainPage = new MainLayout();
    }
}
