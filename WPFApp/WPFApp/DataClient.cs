using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return responseString;
        }

        private string baseUrl = "https://localhost:44321/api/";

        private string contentType = "application/json; charset=utf-8";

        /// <summary>
        /// Call POST request to specified REST endpoint
        /// </summary>
        public string POST(string endpointName, string postData)
        {
            var request = (HttpWebRequest)WebRequest.Create(baseUrl + endpointName);

            // var postData = "mail=" + Uri.EscapeDataString("musk@gmail.com");
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return responseString;
        }
    }
}
