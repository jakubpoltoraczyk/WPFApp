using System;
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

namespace WPFApp
{
    /// <summary>
    /// Class which represents main window and allows to manage control panel and its tab items
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Instance of main window class
        /// </summary>
        public static MainWindow Instance { get; private set; }

        /// <summary>
        /// Static constructor, which creates new instance of main window class
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
            SetApplicationAccess(false);
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        /// <summary>
        /// Set access to appropriate application views
        /// </summary>
        public void SetApplicationAccess(bool hasAccess)
        {
            if (hasAccess)
            {
                LoginViewTab.IsEnabled = false;
                TaskViewTab.IsEnabled = true;
                DeliveryViewTab.IsEnabled = true;
                StatisticsViewTab.IsEnabled = true;
                ControlPanel.SelectedIndex = 1;
            } else
            {
                LoginViewTab.IsEnabled = true;
                TaskViewTab.IsEnabled = false;
                DeliveryViewTab.IsEnabled = false;
                StatisticsViewTab.IsEnabled = false;
                ControlPanel.SelectedIndex = 0;
            }
        }
    }
}
