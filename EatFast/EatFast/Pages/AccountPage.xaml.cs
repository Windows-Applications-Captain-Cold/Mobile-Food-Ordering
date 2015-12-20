using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Teamer.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Teamer.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AccountPage : Page
    {
        public AccountPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.ViewModel = e.Parameter as UserSummaryViewModel;
        }

        public UserSummaryViewModel ViewModel
        {
            get { return this.DataContext as UserSummaryViewModel; }
            set { this.DataContext = value; }
        }

        private void Grid_Holding(object sender, HoldingRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CurrentTask));

        }

        private void TakePicture(object sender, RoutedEventArgs e)
        {
            this.InitCamera();
        }

        private async void InitCamera()
        {
            var camera = new CameraCaptureUI();
            var photo = await camera.CaptureFileAsync(CameraCaptureUIMode.Photo);
            if (photo != null)
            {
                img.Source = new BitmapImage(new Uri(photo.Path));
            }
        }
    }
}
