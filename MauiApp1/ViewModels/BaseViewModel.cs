using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiApp1.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isBusy;

        [ObservableProperty]
        private bool _title;
    }
}
