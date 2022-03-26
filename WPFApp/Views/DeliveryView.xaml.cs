using System;
using System.Collections.Generic;
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

namespace WPFApp.Views
{
    /// <summary>
    /// Logika interakcji dla klasy DeliveryView.xaml
    /// </summary>
    public partial class DeliveryView : UserControl
    {
        /// <summary>
        /// Create new instance of delivery view
        /// </summary>
        public DeliveryView()
        {
            InitializeComponent();
            Loaded += ViewLoaded;
        }

        /// <summary>
        /// Called when delivery view has been loaded
        /// </summary>
        void ViewLoaded(Object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("Delivery view has been loaded!");
        }
    }
}
