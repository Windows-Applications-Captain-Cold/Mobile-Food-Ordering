namespace Teamer.Pages
{
    using Teamer.ViewModels;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Navigation;

    public sealed partial class MainTaskPage : Page
    {
        public MainTaskPage()
        {
            this.InitializeComponent();
            this.ViewModel = new ProjectViewModel();
        }

        private ProjectViewModel ViewModel
        {
            get { return this.DataContext as ProjectViewModel; }
            set { this.DataContext = value; }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        private void GoToMemberPage(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MembersPage));

        }

        private void GoToTaskPage(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TasksPage));

        }

        private void GoToLeaderPage(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LiderPage));

        }

        private void GoToCreateMainProject(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreateMainProjectPage));

        }

        private void TextBlock_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            var grid = sender as TextBlock;
            grid.FontSize = 11;
        }

        private void Zoom(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            var grid = sender as TextBlock;
            var scale = e.Delta.Scale;
            grid.FontSize *= scale;
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(OrganisationSummaryPage));
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
