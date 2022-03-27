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
    /// Class which represents task view
    /// </summary>
    public partial class TaskView : UserControl
    {
        /// <summary>
        /// Create new instance of task view
        /// </summary>
        public TaskView()
        {
            InitializeComponent();
            Loaded += ViewLoaded;
        }

        /// <summary>
        /// Called when view has been just loaded
        /// </summary>
        private void ViewLoaded(Object sender, RoutedEventArgs e)
        {
            var indexList = new List<TextBlock>();
            var deadlineList = new List<DatePicker>();
            var descriptionList = new List<TextBlock>();
            var statusList = new List<Button>();

            for(int i = 0; i < 50; ++i)
            {
                indexList.Add(CreateIndexTextBlock());
                deadlineList.Add(CreateDeadlineTextBlock());
                descriptionList.Add(CreateDescriptionTextBlock());
                statusList.Add(CreateStatusButton());
            }

            IndexList.ItemsSource = indexList;
            DeadlineList.ItemsSource = deadlineList;
            DescriptionList.ItemsSource = descriptionList;
            StatusList.ItemsSource = statusList;
        }

        /// <summary>
        /// Create text block component related to index field
        /// </summary>
        private TextBlock CreateIndexTextBlock()
        {
            return new()
            {
                Text = "0",
                TextAlignment = TextAlignment.Center,
                FontSize = 18,
                Margin = new (0, 10, 0, 10)
            };
        }

        /// <summary>
        /// Create date picker component related to deadline field
        /// </summary>
        private DatePicker CreateDeadlineTextBlock()
        {
            return new() {
                Focusable = false,
                SelectedDate = DateTime.Today,
                Margin = new (0, 10, 0, 10)
            };
        }

        /// <summary>
        /// Create text block component related to description field
        /// </summary>
        private TextBlock CreateDescriptionTextBlock()
        {
            return new()
            {
                Text = "Some completely random text",
                TextAlignment = TextAlignment.Center,
                FontSize = 18,
                Margin = new (0, 10, 0, 10)
            };
        }

        /// <summary>
        /// Create button component related to current task status
        /// </summary>
        private Button CreateStatusButton()
        {
            Button button = new() {
                Content = "To do",
                Background = Brushes.IndianRed,
                Margin = new (0, 12, 0, 12)
            };
            button.Click += OnStatusButtonClick;
            return button;
        }

        /// <summary>
        /// Called when status button has been clicked
        /// </summary>
        private void OnStatusButtonClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            button.Content = "Done";
            button.Background = Brushes.LightGreen;

            var result = MessageBox.Show("Do you want to close this task?", String.Empty, 
                                         MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                // todo: call here some POST related to deleting specified task
                ViewLoaded(this, e);
            } else
            {
                button.Content = "To do";
                button.Background = Brushes.IndianRed;
            }
        }
    }
}
