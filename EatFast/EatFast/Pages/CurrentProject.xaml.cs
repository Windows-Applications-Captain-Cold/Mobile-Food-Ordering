namespace Teamer.Pages
{
    using Teamer.ViewModels;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;

    public sealed partial class CurrentProject : Page
    {
        public CurrentProject()
        {
            this.InitializeComponent();
            this.DataContext = new ProjectViewModel("Emo", "Peahosos", "dfgafgsfghdhfhfghfghgfhf");
        }

        private void Zoom(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            var grid = sender as TextBlock;
            var delta = e.Delta;
            var scale = delta.Scale;
                grid.FontSize *= scale;
        }

        private void TextBlock_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            var grid = sender as TextBlock;
            grid.FontSize = 11;
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
