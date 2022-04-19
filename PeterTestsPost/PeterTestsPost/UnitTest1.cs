using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;

namespace PeterTestsPost
{
    public class Palet
    {
        public int PaletId { get; set; }
        public int PaletNumber { get; set; }
        public int PaletPlantsType_Id { get; set; }
        public DateTime DateOfPlanting { get; set; }
    }
    public class ActualTask
    {
        public int ActualTaskId { get; set; }
        public DateTime? RealizationDate { get; set; }               //data faktycznego zrobienia przez usera,  data kiedy powinno sie zrobic -> obliczona z Palet.DateOfPlanting + CareSchedule.TimeOfCare
        public int Palet_Id { get; set; }
        public int? User_Id { get; set; }                            // id usera który wykonal zadanie
        public int CareSchedule_Id { get; set; }

    }


    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Post()
        {
            var url = "https://localhost:44321/api/Palet";

            var request = WebRequest.Create(url);
            request.Method = "POST";

            var user = new Palet() { DateOfPlanting=DateTime.Now, PaletId=1111, PaletNumber=2222, PaletPlantsType_Id=555};
            var json = System.Text.Json.JsonSerializer.Serialize(user);
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
        }


        [Test]
        public void Put()
        {
            using (var client = new System.Net.WebClient())
            {
                int imp_id = 1;
                var url = "https://localhost:44321/api/ActualTaskDedic/" + imp_id.ToString();
                var user = new ActualTask() { ActualTaskId = 1, CareSchedule_Id = 9999, Palet_Id = 99999, RealizationDate = DateTime.Now, User_Id = 99999 };


                var request = WebRequest.Create(url);
                request.Method = "PUT";

                var json = System.Text.Json.JsonSerializer.Serialize(user);
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
            }
        }
    }
}