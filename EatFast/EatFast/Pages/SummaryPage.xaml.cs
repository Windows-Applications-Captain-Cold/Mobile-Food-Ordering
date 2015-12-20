using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamer.ViewModels;
using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace Teamer.Pages
{
    public sealed partial class SummaryPage : Page
    {
        private Point initialPoint;

        public SummaryPage()
        {
            this.InitializeComponent();
            var bounds = ApplicationView.GetForCurrentView().VisibleBounds;
            var scaleFactor = DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel;
            this.VisibleDisplaySize = new Size(bounds.Width * scaleFactor, bounds.Height * scaleFactor);
            //this.initialPoint = this.SummaryMainGrid.
        }

        public UserSummaryViewModel ViewModel
        {
            get { return this.DataContext as UserSummaryViewModel; }
            set { this.DataContext = value; }
        }

        public Size VisibleDisplaySize { get; set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                this.ViewModel = e.Parameter as UserSummaryViewModel;
            }
        }

        private void SummaryMainGrid_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            
        }

        private void SummaryMainGrid_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            if (e.Velocities.Linear.X > 1)
            {
                this.Frame.Navigate(typeof(AccountPage));
            }
        }

        private void SummaryMainGrid_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {

        }

        private void MainProject_Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainTaskPage));
        }

        private void Organisation_Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
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
    }
}
