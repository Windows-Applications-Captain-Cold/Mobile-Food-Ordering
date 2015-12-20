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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Teamer.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CurrentTask : Page
    {
        public CurrentTask()
        {
            this.InitializeComponent();
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
