using Teamer.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace Teamer.Pages
{
    public sealed partial class AccountPage : Page
    {
        public AccountPage()
        {
            this.InitializeComponent();
            

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.ViewModel = e.Parameter as UserAccountViewModel;
        }

        public UserAccountViewModel ViewModel
        {
            get { return this.DataContext as UserAccountViewModel; }
            set { this.DataContext = value; }
        }

        private void Grid_Holding(object sender, HoldingRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CurrentTask));
        }

        private async void TakePicture(object sender, RoutedEventArgs e)
        {
            this.img.Source = await this.ViewModel.TakePicture();
        }

        public void GoBack(object sender, RoutedEventArgs args)
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        private void GotoMyAccount(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AccountPage));

        }
    }
}
