using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Services;
using MauiApp1.Services.Interfaces;
using SharedComponents.Model.Request;
using System.ComponentModel;
using static System.Net.Mime.MediaTypeNames;

namespace MauiApp1.ViewModels
{
    public partial class LoginViewModel : ObservableObject //Automatically gives us the OnPropertyChanged function commented out below
    {

        private IAuthService _authService;

        public LoginViewModel(IAuthService authService)
        {
            _authService = authService;
        }

        [ObservableProperty] // This will do the get set code commented out below
        string email;
        [ObservableProperty]
        string password;
        [ObservableProperty]
        string loginValidationMessage;
        //public string Email
        //{
        //    get => email;
        //    set 
        //    {
        //        email = value;
        //        OnPropertyChanged(nameof(Email));
        //    }
        //}


        //public event PropertyChangedEventHandler PropertyChanged;
        //void OnPropertyChanged(string name) =>
        //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        [RelayCommand]
        public async Task Login() 
        {
            LoginValidationMessage = String.Empty;

            if ((Email == null || Password == null) || (Email.Length == 0 || Password.Length == 0))
            {
                if (Email == null || Email.Length == 0)
                {
                    LoginValidationMessage = "Please enter a valid email address";
                }
                else if (Password == null || Password.Length == 0)
                {
                    LoginValidationMessage = "Please enter a valid password";
                }
                Password = String.Empty;
                //Show Validation saying insert email or password
                return;
            }
            else 
            {
                try
                {
                    //Send Email and Password to API to authenticate
                    var response = await _authService.Login(new LoginRequestModel()
                    {
                        Email = Email,
                        Password = Password
                    });

                    //Redirect to Homepage
                    await Shell.Current.GoToAsync(nameof(MapPage));
                }
                catch (Exception ex)
                {
                    LoginValidationMessage = ex.Message;
                }
            }
        }
    }
}
