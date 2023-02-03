using System.Windows.Input;

namespace MauiApp1.Models.Navigation
{
    public class NavItem
    {
        public string Name { get; set; }
        public string Page { get; set; }
        public ICommand Method { get; set; }
    }
}
