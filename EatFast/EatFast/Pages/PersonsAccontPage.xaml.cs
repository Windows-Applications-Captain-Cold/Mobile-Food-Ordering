namespace Teamer.Pages
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;

    public sealed partial class PersonsAccontPage : Page
    {
        public PersonsAccontPage()
        {
            this.InitializeComponent();
        }

        private void Grid_Holding(object sender, HoldingRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CurrentProject));
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
