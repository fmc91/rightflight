﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Navigation;

namespace RightFlight
{
    public enum UiState { Normal, Wait }

    public partial class App : Application
    {
        public void AppStartup(object sender, StartupEventArgs e)
        {
            NavigationWindow mainWindow = new NavigationWindow
            {
                Width = 1000,
                Height = 800,
                ShowsNavigationUI = false
            };

            mainWindow.Navigated += (s, e) => mainWindow.RemoveBackEntry();

            PageController pageController = new PageController(mainWindow);

            mainWindow.Show();

            pageController.Home();
        }
    }
}
