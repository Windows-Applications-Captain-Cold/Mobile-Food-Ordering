namespace Teamer.Pages
{
    using Managers;
    using Notifications;
    using Teamer.ViewModels;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Navigation;

    public sealed partial class MainTaskPage : Page
    {
        private string ProjectDetailsErrorTitle = "Teamer: Project Details";
        private string ProjectDetailsErrorText = "Could not load project details. Check your internet connection.";

        public MainTaskPage()
        {
            this.InitializeComponent();
            this.ViewModel = new ProjectViewModel();
            this.ProjectManager = new ProjectManager();
        }

        private ProjectViewModel ViewModel
        {
            get { return this.DataContext as ProjectViewModel; }
            set { this.DataContext = value; }
        }

        private ProjectManager ProjectManager { get; set; }
        private INotifier Notifier { get; set; }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            var projectName = e.Parameter.ToString();
            var viewModelUpdated = await this.ViewModel.GetDetailsAsync(projectName);
            if (!viewModelUpdated)
            {
                this.Notifier.Notify(ProjectDetailsErrorTitle, ProjectDetailsErrorText);
            }
            var a = this.innerDataContext.DataContext;
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
