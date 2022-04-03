using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WPFApp
{
    /// <summary>
    /// Singleton class which represents REST data client
    /// </summary>
    public sealed class DataClient
    {
        private static DataClient instance = null;
        public static DataClient Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataClient();
                }
                return instance;
            }
        }

        private string baseUrl = "https://localhost:44321/api/";

        private string contentType = "application/json; charset=utf-8";

        /// <summary>
        /// Private constructor used to create only one instance of DataClient class
        /// </summary>
        private DataClient()
        {
        }

        /// <summary>
        /// Call GET request to specified REST endpoint
        /// </summary>
        public string GET(string endpointName)
        {
            var request = WebRequest.Create(baseUrl + endpointName);
            request.Method = "GET";
            request.ContentType = contentType;

            WebResponse response = null;
            try
            {
                response = request.GetResponse();
            }
            catch (WebException)
            {
                return String.Empty;
            }

            var dataStream = response.GetResponseStream();

            var reader = new StreamReader(dataStream);

            var responseFromServer = reader.ReadToEnd();

            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;
        }
    }
}
