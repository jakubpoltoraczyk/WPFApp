﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFApp.Views;

namespace WPFApp
{
    /// <summary>
    /// Singleton class which represents main window and allows to manage control panel or its tab items
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Contains information if manager is logged in as current user
        /// </summary>
        public bool isManager { get; set; }

        /// <summary>
        /// Instance of main window class
        /// </summary>
        public static MainWindow Instance { get; private set; }

        /// <summary>
        /// Static constructor, which allows to create instance of main window class
        /// </summary>
        static MainWindow()
        {
            Instance = new MainWindow();
        }

        /// <summary>
        /// Private constructor, which creates new instance of main window class
        /// </summary>
        private MainWindow()
        {
            InitializeComponent();
            RefreshControlPanel(false);
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        /// <summary>
        /// Refresh control panel status
        /// </summary>
        public void RefreshControlPanel(bool isSignedIn)
        {
            LoginViewTab.IsEnabled = !isSignedIn;
            TaskViewTab.IsEnabled = isSignedIn;
            EmployeeDeliveryViewTab.IsEnabled = isSignedIn;
            ManagerDeliveryViewTab.IsEnabled = isSignedIn;
            StatisticsViewTab.IsEnabled = isSignedIn;
            LogoutViewTab.IsEnabled = isSignedIn;
            ControlPanel.SelectedIndex = isSignedIn ? 1 : 0;

            EmployeeDeliveryViewTab.Visibility = isManager ? Visibility.Collapsed : Visibility.Visible;
            ManagerDeliveryViewTab.Visibility = isManager ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
