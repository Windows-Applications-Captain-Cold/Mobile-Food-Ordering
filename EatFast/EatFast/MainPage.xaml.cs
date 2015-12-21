namespace Teamer
{
    using Teamer.ViewModels;
    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Teamer.Pages;
    using Teamer.Notifications;

    public sealed partial class MainPage : Page
    {
        private const string AuthenticationErrorTitle = "Teamer: Unsuccessfull authentication!";
        private const string AuthenticationErrorText = "Authentication denied. Wrong email or password, or user already exists.";
        private const string AuthenticationSuccessfullTitle = "Teamer: Authentication Successfull!";
        private const string AuthenticationSuccessfullMessage = "You are now logged in!";

        public MainPage()
        {
            this.InitializeComponent();
            this.ViewModel = new UserAuthenticateViewModel();
            this.Notifier = new Notifier();
        }

        private async void AuthenticateUser(object sender, RoutedEventArgs args)
        {
            var email = this.Email.Text;
            var password = this.Password.Text;
            var buttonSender = sender as Button;
            if (buttonSender.Name == "loginButton")
            {
                var userSummaryViewModel = await this.ViewModel.Login(email, password);
                if (userSummaryViewModel == null)
                {
                    this.Notifier.Notify(AuthenticationErrorTitle, AuthenticationErrorText);
                }
                else
                {
                    this.Notifier.Notify(AuthenticationSuccessfullTitle, AuthenticationSuccessfullMessage);
                    this.Frame.Navigate(typeof(SummaryPage), userSummaryViewModel);
                }
            }
            else
            {
                var userSummaryViewModel = await this.ViewModel.Register(email, password);
                if (userSummaryViewModel == null)
                {
                    this.Notifier.Notify(AuthenticationErrorTitle, AuthenticationErrorText);
                }
                else
                {
                    this.Notifier.Notify(AuthenticationSuccessfullTitle, AuthenticationSuccessfullMessage);
                    this.Frame.Navigate(typeof(SummaryPage), userSummaryViewModel);
                }
            }
        }

        private INotifier Notifier { get; set; }

        public UserAuthenticateViewModel ViewModel
        {
            get { return this.DataContext as UserAuthenticateViewModel; }
            set { this.DataContext = value; }
        }
    }
}
