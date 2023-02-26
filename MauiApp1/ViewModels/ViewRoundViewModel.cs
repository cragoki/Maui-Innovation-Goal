using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models.PollingStation;
using MauiApp1.Services.Interfaces;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MauiApp1.ViewModels
{
    public partial class ViewRoundViewModel : BaseViewModel
    {
        public ObservableCollection<PollingStationModel> PollingStations { get; } = new();
        private IPollingStationService _pollingStationService;

        public ViewRoundViewModel(IPollingStationService pollingStationService)
        {
            _pollingStationService = pollingStationService;
        }

        public async Task GetPollingStationsAsync()
        {
            try
            {
                //if (connectivity.NetworkAccess != NetworkAccess.Internet)
                //{
                //    await Shell.Current.DisplayAlert("No connectivity!",
                //        $"Please check internet and try again.", "OK");
                //    return;
                //}
                if (PollingStations.Count() == 0)
                {
                    var stations = await _pollingStationService.GetStationModel();

                    foreach (var station in stations)
                        PollingStations.Add(station);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get Polling Stations: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
        }

        [RelayCommand]
        public async Task ShowStation(PollingStationModel station)
        {
            //Need to pass in station to the visit station page
            await Shell.Current.GoToAsync(nameof(VisitStationPage));
        }
    }
}
