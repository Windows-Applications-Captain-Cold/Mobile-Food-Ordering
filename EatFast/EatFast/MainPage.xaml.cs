using Teamer.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Teamer.Pages;
using System.Threading.Tasks;

namespace Teamer
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.ViewModel = new UserAuthenticateViewModel();
        }

        private async void AuthenticateUser(object sender, RoutedEventArgs args)
        {
            var email = this.Email.Text;
            var password = this.Password.Text;
            var buttonSender = sender as Button;
            if (buttonSender.Name == "loginButton")
            {
                //TODO: Catch exception when server is unreachable
                var userSummaryViewModel = await this.ViewModel.Login(email, password);
                this.Frame.Navigate(typeof(SummaryPage), userSummaryViewModel);
            }
            else
            {
                var userSummaryViewModel = await this.ViewModel.Register(email, password);
                this.Frame.Navigate(typeof(SummaryPage), userSummaryViewModel);
            }
        }

        public UserAuthenticateViewModel ViewModel
        {
            get { return this.DataContext as UserAuthenticateViewModel; }
            set { this.DataContext = value; }
        }
    }
}
