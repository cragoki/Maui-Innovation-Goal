using CommunityToolkit.Mvvm.Input;
using MauiApp1.Models.Navigation;
using System.Collections.ObjectModel;

namespace MauiApp1.ViewModels
{
    public partial class HomeViewModel : BaseViewModel
    {
        public ObservableCollection<NavItem> NavItems { get; } = new ObservableCollection<NavItem>()
        {
            new NavItem()
            {
                Name = "View Round",
                Page = nameof(ViewRoundPage)
            }
        };


        [RelayCommand]
        public async Task NavigateTo(NavItem navItem)
        {
            await Shell.Current.GoToAsync(navItem.Page);
        }
    }
}
