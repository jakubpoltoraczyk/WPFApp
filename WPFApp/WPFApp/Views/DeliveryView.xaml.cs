using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    /// Class which represents delivery view
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
        /// Called when delivery view has been just loaded
        /// </summary>
        void ViewLoaded(Object sender, RoutedEventArgs e)
        {
            var dataClient = DataClient.Instance;

            var jsonData = dataClient.GET("PaletPlantsType");

            var deliveryProducts = JsonConvert.DeserializeObject<IList<DeliveryProduct>>(jsonData);

            DeliveryProductsBox.Items.Clear();
            foreach (var deliveryProduct in deliveryProducts)
            {
                DeliveryProductsBox.Items.Add(deliveryProduct.paletPlantsTypeName);
            }
        }
    }
}
