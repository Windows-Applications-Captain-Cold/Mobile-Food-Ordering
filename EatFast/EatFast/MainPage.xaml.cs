﻿using EatFast.ViewModels;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace EatFast
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            var mainMenuViewModel = new MainMenuViewModel { mainMenuGridMargin = "10, 10, 0, 0" };
            this.mainMenuGrid.DataContext = mainMenuViewModel;
        }

        public void NavigateToPage(object sender, RoutedEventArgs args)
        {
            this.Frame.Navigate(typeof(LocationsPage));
        }
        public void NavigateToMenuPage(object sender, RoutedEventArgs args)
        {
            this.Frame.Navigate(typeof(FoodMenuPage));
        }
    }
}
