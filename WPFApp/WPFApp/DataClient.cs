using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFApp.Models;

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
        /// Base url used to send REST API requests
        /// </summary>
        private string baseUrl = "https://localhost:44321/api/";

        /// <summary>
        /// Type of content in REST API requests
        /// </summary>
        private string contentType = "application/json; charset=utf-8";

        /// <summary>
        /// Call GET request to specified REST endpoint
        /// </summary>
        public string GET(string endpointName)
        {
            try
            {
                var request = WebRequest.Create(baseUrl + endpointName);
                request.Method = "GET";
                request.ContentType = contentType;

                WebResponse response = null;
                response = request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return responseString;
            } 
            catch(Exception ex)
            {
                MessageBox.Show("Server response is not available", String.Empty,
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return String.Empty;
            }
        }

        public string POST(string endpointName, object postData)
        {
            try
            {
                var url = baseUrl + endpointName;

                var request = WebRequest.Create(url);
                request.Method = "POST";

                var json = System.Text.Json.JsonSerializer.Serialize(postData);
                byte[] byteArray = Encoding.UTF8.GetBytes(json);

                request.ContentType = contentType;
                request.ContentLength = byteArray.Length;

                using var reqStream = request.GetRequestStream();
                reqStream.Write(byteArray, 0, byteArray.Length);

                using var response = request.GetResponse();
                var tmp = (((HttpWebResponse)response).StatusDescription);

                using var respStream = response.GetResponseStream();

                using var reader = new StreamReader(respStream);
                string data = reader.ReadToEnd();

                return data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Server response is not available", String.Empty,
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return String.Empty;
            }
        }

        public string PUT(string endpointName, object putData)
        {
            try
            {
                using (var client = new System.Net.WebClient())
                {
                    var url = baseUrl + endpointName;

                    var request = WebRequest.Create(url);
                    request.Method = "PUT";

                    var json = System.Text.Json.JsonSerializer.Serialize(putData);
                    byte[] byteArray = Encoding.UTF8.GetBytes(json);

                    request.ContentType = "application/json";
                    request.ContentLength = byteArray.Length;

                    using var reqStream = request.GetRequestStream();
                    reqStream.Write(byteArray, 0, byteArray.Length);

                    using var response = request.GetResponse();
                    var tmp = (((HttpWebResponse)response).StatusDescription);

                    using var respStream = response.GetResponseStream();

                    using var reader = new StreamReader(respStream);

                    string data = reader.ReadToEnd();
                    return data;
                }
            } 
            catch(Exception ex)
            {
                MessageBox.Show("Server response is not available", String.Empty,
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return String.Empty;
            }
        }
    }
}
