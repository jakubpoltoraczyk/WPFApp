using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WPFApp.Models;
using Flurl.Http;

namespace WPFApp.Views
{
    /// <summary>
    /// Class which represents delivery view for employee
    /// </summary>
    public partial class EmployeeDeliveryView : UserControl
    {
        private bool isApplicationStarted = false;

        /// <summary>
        /// List of delivery products in employee delivery view
        /// </summary>
        private IList<DeliveryProduct> deliveryProducts;

        /// <summary>
        /// Create new instance of delivery view
        /// </summary>
        public EmployeeDeliveryView()
        {
            InitializeComponent();
            Loaded += ViewLoaded;
            deliveryProducts = new List<DeliveryProduct>();
        }
        
        /// <summary>
        /// Called when delivery view has been just loaded
        /// </summary>
        void ViewLoaded(Object sender, RoutedEventArgs e)
        {
            if (!isApplicationStarted)
            {
                isApplicationStarted = true;
                return;
            }

            var dataClient = DataClient.Instance;

            var jsonData = dataClient.GET("PaletPlantsType");
            if (string.IsNullOrEmpty(jsonData))
            {
                return;
            }

            deliveryProducts = JsonConvert.DeserializeObject<IList<DeliveryProduct>>(jsonData);

            DeliveryProductsBox.Items.Clear();
            foreach (var deliveryProduct in deliveryProducts)
            {
                DeliveryProductsBox.Items.Add(deliveryProduct.paletPlantsTypeName);
            }
        }

        /// <summary>
        /// Send delivery request to REST API when user clicked delivery button
        /// </summary>
        private void MakeDeliveryButtonClicked(object sender, RoutedEventArgs e)
        {
            var choosenProductString = DeliveryProductsBox.Text;
            int choosenProductNumber = 0;
            foreach(var deliveryProduct in deliveryProducts)
            {
                if(deliveryProduct.paletPlantsTypeName == choosenProductString)
                {
                    choosenProductNumber = deliveryProduct.paletPlantsTypeId;
                    break;
                }
            }

            var palet = new Palet();
            palet.paletId = -1;

            if (DeliveryNumberOfPaletBox.Text != String.Empty)
            {
                palet.paletNumber = Convert.ToInt32(DeliveryNumberOfPaletBox.Text);
            } else
            {
                MessageBox.Show("Palet number can not be empty", String.Empty,
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (choosenProductNumber != 0)
            {
                palet.paletPlantsType_Id = choosenProductNumber;
            } else
            {
                MessageBox.Show("Chosen product can not be empty", String.Empty,
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var chosenDate = (DateTime)DeliveryDatePicker.SelectedDate;
                if (chosenDate != null && chosenDate > DateTime.Now)
                {
                    palet.dateOfPlanting = (DateTime)DeliveryDatePicker.SelectedDate;
                }
                else
                {
                    MessageBox.Show("Date has to be later than " + DateTime.Now.ToString(), String.Empty,
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
            catch(System.InvalidOperationException)
            {
                MessageBox.Show("Date can not be empty", String.Empty,
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var dataClient = DataClient.Instance;
            var response = dataClient.POST("Palet", palet);
            
            MessageBox.Show("Palet has been just created", String.Empty,
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
