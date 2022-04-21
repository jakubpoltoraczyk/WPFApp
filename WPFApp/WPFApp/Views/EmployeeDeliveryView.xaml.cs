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
        /// Create new instance of delivery view
        /// </summary>
        public EmployeeDeliveryView()
        {
            InitializeComponent();
            Loaded += ViewLoaded;
        }

        /// <summary>
        /// List of delivery products in employee delivery view
        /// </summary>
        private IList<DeliveryProduct> deliveryProducts;
        
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
            palet.paletNumber = Convert.ToInt32(DeliveryNumberOfPaletBox.Text);
            palet.paletPlantsType_Id = choosenProductNumber;
            palet.dateOfPlanting = (DateTime)DeliveryDatePicker.SelectedDate;

            var dataClient = DataClient.Instance;
            dataClient.POST("Palet", palet);
        }
    }
}
