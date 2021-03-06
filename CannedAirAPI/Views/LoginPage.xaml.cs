﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using CannedAirAPI.Singletons;
using CannedAirAPI.ViewModel;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using CannedAirAPI.Resources;

namespace CannedAirAPI.Views
{
    public partial class LoginPage : PhoneApplicationPage
    {
        // Constructor
        public LoginPage()
        {
            InitializeComponent();
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}

        private void LoginPage_OnLoaded(object sender, RoutedEventArgs e)
        {
//            if (CurrentUser.Instance != null && CurrentUser.HasUserBeenInitialized)
//            {
//                NavigationService.Navigate(new Uri("/Views/MainPage.xaml", UriKind.Relative));
//            }
        }

        private async void LoginButton_OnClick(object sender, RoutedEventArgs e)
        {
            var mvm = DataContext as LoginViewModel;
            if (mvm != null)
            {
                await mvm.UserLogin();
                if (mvm.IsInvalidLogin == 0)
                    NavigationService.Navigate(new Uri("/Views/MainPage.xaml", UriKind.Relative));
            }
        }
    }
}