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
    /// Class which represents delivery view
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

            var postData = "paletId=" + Uri.EscapeDataString("0");
            postData += "&paletNumber=" + Uri.EscapeDataString(DeliveryNumberOfPaletBox.Text);
            postData += "&paletPlantsType_Id=" + Uri.EscapeDataString(choosenProductNumber.ToString());
            postData += "&dateOfPlanting=" + Uri.EscapeDataString(DeliveryDatePicker.ToString());

            var dataClient = DataClient.Instance;
            // dataClient.POST("Palet", postData);
            // dataClient.POST2("Palet");
        }
    }
}
