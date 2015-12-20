using Teamer.ViewModels;
using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace Teamer.Pages
{
    public sealed partial class SummaryPage : Page
    {
        public SummaryPage()
        {
            this.InitializeComponent();
            var bounds = ApplicationView.GetForCurrentView().VisibleBounds;
            var scaleFactor = DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel;
            this.VisibleDisplaySize = new Size(bounds.Width * scaleFactor, bounds.Height * scaleFactor);
        }

        public UserSummaryViewModel ViewModel
        {
            get { return this.DataContext as UserSummaryViewModel; }
            set { this.DataContext = value; }
        }

        public Size VisibleDisplaySize { get; set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                this.ViewModel = e.Parameter as UserSummaryViewModel;
            }
        }

        private void SummaryMainGrid_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            if (e.Velocities.Linear.X > 1)
            {
                var userAccountViewModel = new UserAccountViewModel()
                {
                    Name = this.ViewModel.Name,
                    Organisation = this.ViewModel.Organisation,
                    Projects = this.ViewModel.Projects,
                    Team = this.ViewModel.Team
                };
                this.Frame.Navigate(typeof(AccountPage), userAccountViewModel);
            }
        }

        private void MainProject_Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainTaskPage));
        }

        private void Organisation_Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(OrganisationSummaryPage), this.ViewModel.Organisation);
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
