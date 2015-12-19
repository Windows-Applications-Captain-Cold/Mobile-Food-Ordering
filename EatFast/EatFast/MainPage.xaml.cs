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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Teamer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.ViewModel = new UserAuthenticateViewModel();
            this.DataContext = this.ViewModel;
        }

        private async void LoginUser(object sender, RoutedEventArgs args)
        {
            var email = this.Email.Text;
            var password = this.Password.Text;
            var userContentViewModel = await this.ViewModel.Login(email, password);
            this.Frame.Navigate(typeof(AccountPage), userContentViewModel);
        }

        public UserAuthenticateViewModel ViewModel { get; set; }

        //public void NavigateToPage(object sender, RoutedEventArgs args)
        //{
        //    this.Frame.Navigate(typeof(LocationsPage));
        //}
        //public void NavigateToMenuPage(object sender, RoutedEventArgs args)
        //{
        //    this.Frame.Navigate(typeof(FoodMenuPage));
        //}

        //public void GoBack(object sender, RoutedEventArgs args)
        //{
        //    if (this.Frame.CanGoBack)
        //    {
        //        this.Frame.GoBack();
        //    }
        //}
    }
}
