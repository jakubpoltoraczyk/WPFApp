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
    /// Class which represents statistics view
    /// </summary>
    public partial class StatisticsView : UserControl
    {
        /// <summary>
        /// Create new instance of statistics view
        /// </summary>
        public StatisticsView()
        {
            InitializeComponent();
            Loaded += ViewLoaed;
        }

        /// <summary>
        /// Called when view has been just loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewLoaed(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("Task view has been loaded!");
        }
    }
}
