namespace Teamer.Pages
{
    using Notifications;
    using System.Linq;
    using Teamer.ViewModels;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Navigation;

    public sealed partial class AccountPage : Page
    {
        private const string ProjectUpdateSussessToastTitle = "Teamer: Success";
        private const string ProjectUpdateSuccessToastContent = "Project status successfully updated!";
        private const string ProjectUpdateFailToastTitle = "Teamer: Fail";
        private const string ProjectUpdateFailToastContent = "Project status not updated!";

        public AccountPage()
        {
            this.InitializeComponent();
            this.ViewModel = new UserAccountViewModel();
            this.Notifier = new Notifier();
        }

        private INotifier Notifier { get; set; }

        public UserAccountViewModel ViewModel
        {
            get { return this.DataContext as UserAccountViewModel; }
            set { this.DataContext = value; }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.ViewModel = e.Parameter as UserAccountViewModel;
        }

        private void Grid_Holding(object sender, HoldingRoutedEventArgs e)
        {
            var gridSender = sender as Grid;
            var textBlockSender = gridSender.Children
                .Where(c => c.GetType() == typeof(TextBlock))
                .FirstOrDefault()
                as TextBlock;

            var projectName = textBlockSender.Text;
            var project = this.ViewModel
                .Projects
                .Where(p => p.Name == projectName)
                .FirstOrDefault();
            var projectViewModel = new ProjectViewModel()
            {
                Name = project.Name,
                Description = project.Description,
                Organization = project.Organisation
            };

            this.Frame.Navigate(typeof(CurrentProject), projectViewModel);
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

        private async  void ProjectStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = (sender as ComboBox);
            var grid = comboBox.Parent as Grid;
            var textBlock = grid.Children
                .Where(c => c.GetType() == typeof(TextBlock))
                .FirstOrDefault()
                as TextBlock;

            var status = (comboBox.SelectedItem as ComboBoxItem).Content;
            var projectStatus = status.ToString() == "Done";
            var projectName = textBlock.Text;
            var updated = await this.ViewModel.UpdateProjectStatus(projectName, projectStatus);
            if (updated)
            {
                this.Notifier.Notify(ProjectUpdateSussessToastTitle, ProjectUpdateSuccessToastContent);
            }
            else
            {
                this.Notifier.Notify(ProjectUpdateFailToastTitle, ProjectUpdateFailToastContent);
            }
        }
    }
}
