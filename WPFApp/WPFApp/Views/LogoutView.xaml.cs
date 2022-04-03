using System;
using System.Collections.Generic;
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

namespace WPFApp.Views
{
    /// <summary>
    /// Class which represents logout view
    /// </summary>
    public partial class LogoutView : UserControl
    {
        private bool isApplicationStarted = false;

        /// <summary>
        /// Create new instance of logout view
        /// </summary>
        public LogoutView()
        {
            InitializeComponent();
            Loaded += ViewLoaed;
        }

        /// <summary>
        /// Called when view has been just loaded
        /// </summary>
        private void ViewLoaed(object sender, RoutedEventArgs e)
        {
            if (!isApplicationStarted)
            {
                isApplicationStarted = true;
                return;
            }

            var response = MessageBox.Show("Do you want to logout?", string.Empty, MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (response == MessageBoxResult.Yes)
            {
                MainWindow.Instance.RefreshControlPanel(false);
            } else
            {
                MainWindow.Instance.RefreshControlPanel(true);
            }
        }
    }
}
