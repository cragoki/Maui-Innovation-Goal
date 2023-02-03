using CommunityToolkit.Mvvm.Input;
using MauiApp1.Services.Interfaces;

namespace MauiApp1.ViewModels
{
    public partial class MainLayoutViewModel : BaseViewModel
    {
        private IAuthService _authService;

        public MainLayoutViewModel(IAuthService authService) 
        {
            _authService = authService;
        }

        [RelayCommand]
        public async Task SignOut()
        {
            _authService.ClearLocalData();
            //Here we will want to Clear out the local db
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
