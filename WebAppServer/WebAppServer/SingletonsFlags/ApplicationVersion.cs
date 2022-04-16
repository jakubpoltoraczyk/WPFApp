using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppServer.SingletonsFlags
{
    /// <summary>
    /// Singleton class to switch between test dev version and database connected version
    /// </summary>
    public sealed class ApplicationVersion
    {
        private ApplicationVersion() { }
        private static ApplicationVersion _instance;
        /// <summary>
        /// Method to return single instance of class
        /// </summary>
        /// <returns>Application Version instance</returns>
        public static ApplicationVersion GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ApplicationVersion();
            }
            return _instance;
        }
        /// <summary>
        /// Method to check that current working version of software is test or production
        /// </summary>
        /// <returns></returns>
        public static bool IsTestVersion()
        {
            return true;
        }
    }
}
