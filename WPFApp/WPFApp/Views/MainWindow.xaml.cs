using Newtonsoft.Json;
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
using WPFApp.Models;
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
        private bool isManager { get; set; }

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

            var dataClient = DataClient.Instance;
            var jsonData = dataClient.GET("UserCategory");

            if (string.IsNullOrEmpty(jsonData))
            {
                return;
            }

            var currentData = CurrentData.Instance;
            var userCategories = JsonConvert.DeserializeObject<IList<UserCategory>>(jsonData);
            foreach (var userCategory in userCategories)
            {
                if(userCategory.userCategoryName == "unemployed")
                {
                    currentData.unemployed = userCategory;
                }
                if(userCategory.userCategoryName == "manager")
                {
                    currentData.manager = userCategory;
                }
            }
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

        /// <summary>
        /// Set appropriate access level in regard to passed category ID
        /// </summary>
        public void setAccessLevel(int userCategoryID)
        {
            var currentData = CurrentData.Instance;
            isManager = (currentData.manager.userCategoryId == userCategoryID);
        }
    }
}
