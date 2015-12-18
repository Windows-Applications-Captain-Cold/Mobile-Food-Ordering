using EatFast.Pages;
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

namespace EatFast
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FoodMenuPage : Page
    {
        public FoodMenuPage()
        {
            this.InitializeComponent();
        }

        public void GoBack(object sender, RoutedEventArgs args)
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }
        private void GotoMainCourse(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainCoursePage));
        }
        private void GotoAppetizers(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AppetizersPage));
        }
        private void GotoPizza(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PizzaPage));
        }
        private void GotoPasta(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(PastaPage));
        }
        private void GotoSalads(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SaladsPage));
        }
        private void GotoSoups(object sender, RoutedEventArgs e)
        {
            var u = sender.ToString();
            this.Frame.Navigate(typeof(SoupsPage));
        }
        private void GotoDeserts(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(DesertsPage));
        }
        private void GotoWines(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(WinesPage));
        }
        private void GotoSoft_Drinks(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Soft_DrinksPage));
        }
    }
}
