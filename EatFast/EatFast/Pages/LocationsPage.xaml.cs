﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace EatFast
{
    public sealed partial class LocationsPage
    {
        public LocationsPage()
        {
            this.InitializeComponent();
            List<string> locationNamesTest = new List<string>
            {
                "Location 1",
                "New Yourk park foods",
                "Aladin foods",
                "Best pizza"
            };
            
            this.locationsList.DataContext = locationNamesTest;
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