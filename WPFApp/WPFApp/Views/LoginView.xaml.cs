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
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Text.Json;

namespace WPFApp.Views
{
    /// <summary>
    /// Class which represents login view
    /// </summary>
    public partial class LoginView : UserControl
    {
        /// <summary>
        /// Construct new instance of LoginView class
        /// </summary>
        public LoginView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Called when login button has been clicked
        /// </summary>
        private void LoginButtonClicked(object sender, RoutedEventArgs e)
        {
            int answer = RequestLogin(UsernameContentBox.Text, PasswordContentBox.Password.ToString());
            if (answer == 200)
            {
                UsernameContentBox.Text = String.Empty;
                PasswordContentBox.Password = String.Empty;

                var mainWindowInstance = MainWindow.Instance;
                mainWindowInstance.isManager = drawAccessLevel();
                mainWindowInstance.RefreshControlPanel(true);

                MessageBox.Show("Successful login attempt", String.Empty, MessageBoxButton.OK, MessageBoxImage.Information);
            } else
            {
                MessageBox.Show("Invalid username or password", String.Empty, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // todo: remove this method when service logic will be ready
        private int RequestLogin(string username, string password)
        {
            return username == password ? 200 : 404;
        }

        private bool drawAccessLevel()
        {
            var random = new Random();
            return random.Next() % 2 == 0;
        }
    }
}
