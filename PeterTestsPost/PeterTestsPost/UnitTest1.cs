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


    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var url = "https://localhost:44321/api/Palet";

            var request = WebRequest.Create(url);
            request.Method = "POST";

            var user = new Palet() { DateOfPlanting=DateTime.Now, PaletId=1111, PaletNumber=2222, PaletPlantsType_Id=555};
            var json = JsonSerializer.Serialize(user);
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