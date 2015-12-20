using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamer.ViewModels;
using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Teamer.Pages
{
    public sealed partial class SummaryPage : Page
    {
        public SummaryPage()
        {
            this.InitializeComponent();
            var bounds = ApplicationView.GetForCurrentView().VisibleBounds;
            var scaleFactor = DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel;
            this.VisibleDisplaySize = new Size(bounds.Width * scaleFactor, bounds.Height * scaleFactor);
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
    }
}
