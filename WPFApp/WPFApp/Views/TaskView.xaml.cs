using Newtonsoft.Json;
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
using WPFApp.Models;

namespace WPFApp.Views
{
    /// <summary>
    /// Class which represents task view
    /// </summary>
    public partial class TaskView : UserControl
    {
        private bool isApplicationStarted = false;

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
            if (!isApplicationStarted)
            {
                isApplicationStarted = true;
                return;
            }

            var indexList = new List<TextBlock>();
            var deadlineList = new List<DatePicker>();
            var descriptionList = new List<TextBlock>();
            var statusList = new List<Button>();

            var dataClient = DataClient.Instance;
            var jsonData = dataClient.GET("ActualTaskDedic");

            if (string.IsNullOrEmpty(jsonData))
            {
                return;
            }

            var palets = JsonConvert.DeserializeObject<IList<ActualTaskDedicated>>(jsonData);

            foreach (var palet in palets)
            {
                indexList.Add(CreateIndexTextBlock(0));

                var taskDeadline = palet.timeOfCare.ToString();
                deadlineList.Add(CreateDeadlineTextBlock(taskDeadline));

                var description = "Palet: " + palet.paletNumber + " (" + palet.paletPlantsTypeName
                                    + " - " + palet.typeOfCareName + ")";
                descriptionList.Add(CreateDescriptionTextBlock(description));

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
        private TextBlock CreateIndexTextBlock(int index)
        {
            return new()
            {
                Text = index.ToString(),
                TextAlignment = TextAlignment.Center,
                FontSize = 18,
                Margin = new (0, 10, 0, 10)
            };
        }

        /// <summary>
        /// Create date picker component related to deadline field
        /// </summary>
        private DatePicker CreateDeadlineTextBlock(string dateOfPlanting)
        {
            return new() {
                Focusable = false,
                SelectedDate = Convert.ToDateTime(dateOfPlanting),
                Margin = new (0, 10, 0, 10)
            };
        }

        /// <summary>
        /// Create text block component related to description field
        /// </summary>
        private TextBlock CreateDescriptionTextBlock(string description)
        {
            return new()
            {
                Text = description,
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
                Content = "Done",
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
            button.Background = Brushes.LightGreen;

            var result = MessageBox.Show("Do you want to close this task?", String.Empty, 
                                         MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var dataClient = DataClient.Instance;
                // dataClient.PUT("ActualTaskDedic", "");
                ViewLoaded(this, e);
            } else
            {
                button.Background = Brushes.IndianRed;
            }
        }
    }
}
