namespace Teamer.Pages
{
    using Notifications;
    using Teamer.ViewModels;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    public sealed partial class OrganisationSummaryPage : Page
    {
        public OrganisationSummaryPage()
        {
            this.InitializeComponent();
            this.ViewModel = new OrganisationViewModel();
            this.Notifier = new Notifier();
        }

        public INotifier Notifier { get; set; }

        public OrganisationViewModel ViewModel
        {
            get { return this.DataContext as OrganisationViewModel; }
            set { this.DataContext = value; }
        }

        private void MainProject_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainTaskPage));
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

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            this.OrganisationProgressRing.IsActive = true;
            var viewModelUpdated = await this.ViewModel
                .GetOrganisationDetailsAsync(e.Parameter.ToString());
            this.OrganisationProgressRing.IsActive = false;

            if (!viewModelUpdated)
            {
                this.Notifier.Notify("Organisation data error", "Could not update organisation data. Check your internet connection.");
            }
            else
            {
                //notificate done?
            }
        }
    }
}
