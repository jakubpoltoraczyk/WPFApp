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

        public void POST2(string endpointName)
        {
            using (var wb = new WebClient())
            {
                var data = new NameValueCollection();
                data["paletId"] = "0";
                data["paletNumber"] = "0";
                data["paletPlantsType_Id"] = "0";
                data["dateOfPlanting"] = "2022-04-18T13:28:16.210Z";

                var response = wb.UploadValues(baseUrl + endpointName, "POST", data);
                string responseInString = Encoding.UTF8.GetString(response);
            }
        }

        public string PUT(string endpointName, string putData)
        {
            using (var client = new HttpClient())
            {
                RealizedTask payLoad = new RealizedTask();
                payLoad.actualTaskId = 10;
                payLoad.realizationDate = "2022-04-18T14:11:47.911Z";
                payLoad.palet_Id = 1;
                payLoad.user_Id = 2;
                payLoad.careSchedule_Id = 4;
                client.BaseAddress = new Uri(baseUrl);
                var response = client.PutAsJsonAsync(endpointName, payLoad).Result;
                if (response.IsSuccessStatusCode)
                {
                    Trace.WriteLine("Success");
                }
                else
                    Trace.WriteLine("Error");
            }

            return "";
        }
    }
}
