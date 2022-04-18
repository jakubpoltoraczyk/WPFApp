using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFApp.Models;

namespace WPFApp
{
    /// <summary>
    /// Singleton class which represents current data
    /// </summary>
    public sealed class CurrentData
    {
        private static CurrentData instance = null;
        public static CurrentData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CurrentData();
                }
                return instance;
            }
        }

        /// <summary>
        /// Private constructor used to create only one instance of CurrentData class
        /// </summary>
        private CurrentData()
        {
        }

        /// <summary>
        /// User category related to unemployed access level
        /// </summary>
        public UserCategory unemployed { get; set; }

        /// <summary>
        /// User category related to admin access level
        /// </summary>
        public UserCategory admin { get; set; }

        /// <summary>
        /// User category related to manager access level
        /// </summary>
        public UserCategory manager { get; set; }

        /// <summary>
        /// User category related to worker access level
        /// </summary>
        public UserCategory worker { get; set; }
    }
}
