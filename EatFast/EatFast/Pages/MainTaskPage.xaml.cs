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
    public sealed partial class MainTaskPage : Page
    {
        public MainTaskPage()
        {
            this.InitializeComponent();
        }

        private void GoToMemberPage(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MembersPage));

        }

        private void GoToTaskPage(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TasksPage));

        }

        private void GoToLeaderPage(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LiderPage));

        }

        private void GoToCreateMainProject(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreateMainProjectPage));

        }



        private void TextBlock_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            var grid = sender as TextBlock;
            grid.FontSize = 11;
        }

        private void Zoom(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            var grid = sender as TextBlock;
            var scale = e.Delta.Scale;
            grid.FontSize *= scale;


        }
    }
}
