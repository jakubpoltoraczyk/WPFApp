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
        private string myString;

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
            myString = string.Empty;
            List<TextBlock> indexList = new List<TextBlock>();
            List<TextBlock> deadlineList = new List<TextBlock>();
            List<TextBlock> descriptionList = new List<TextBlock>();
            List<Button> confirmationList = new List<Button>();

            for(int i = 0; i < 50; ++i)
            {
                indexList.Add(createIndexTextBlock(i));
                deadlineList.Add(createDeadlineTextBlock());
                descriptionList.Add(createDescriptionTextBlock());
                confirmationList.Add(createConfirmationButton(i));
            }

            IndexList.ItemsSource = indexList;
            DeadlineList.ItemsSource = deadlineList;
            DescriptionList.ItemsSource = descriptionList;
            ConfirmationList.ItemsSource = confirmationList;
        }

        private TextBlock createIndexTextBlock(int index)
        {
            return new TextBlock()
            {
                Width = 50,
                Height = 50,
                Text = index.ToString(),
                FontSize = 16,
                TextAlignment = TextAlignment.Center
            };
        }

        private TextBlock createDeadlineTextBlock()
        {
            DateTime dateTime = DateTime.Today;
            String contentText = "Deadline: " + dateTime.ToShortDateString();
            return new TextBlock() { 
                Width = 150, 
                Height = 50, 
                Text = contentText, 
                FontSize = 16, 
                TextAlignment = TextAlignment.Center
            };
        }

        private TextBlock createDescriptionTextBlock()
        {
            myString += "ttt";
            return new TextBlock()
            {
                Height = 50,
                MaxWidth = 420,
                Text = myString,
                FontSize = 16,
                TextAlignment = TextAlignment.Center
            };
        }

        private Button createConfirmationButton(int index)
        {
            Button button = new Button() {
                Height = 20, 
                Width = 20, 
                Margin = new Thickness(0, 2, 0, 28),
                Content = index.ToString() 
            };
            button.Click += OnConfirmationButtonClick;
            return button;
        }

        private void OnConfirmationButtonClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            // some POST to delete button with given index
            ViewLoaded(this, e);
        }
    }
}
