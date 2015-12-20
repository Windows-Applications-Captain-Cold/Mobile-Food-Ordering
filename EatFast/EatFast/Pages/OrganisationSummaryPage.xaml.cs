using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Teamer.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Teamer.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OrganisationSummaryPage : Page
    {
        public OrganisationSummaryPage()
        {
            this.InitializeComponent();
            this.ViewModel = new OrganisationViewModel()
            {
                Name = "AAA",
                Project = new Models.Project { Name = "asd"},
                Teams = new List<string>(){ "asd", "asd", "asd"}
            };
        }

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
            var viewModelUpdated = await this.ViewModel
                .GetOrganisationDetailsAsync(e.Parameter.ToString());


            if (!viewModelUpdated)
            {
                
            }
            else
            {
                //notificate done?
            }
        }
    }
}
