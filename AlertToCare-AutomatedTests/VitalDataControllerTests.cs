using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Net;
using Alert_To_Care.Models;
namespace AlertToCare_AutomatedTests
{
    [TestClass]
    public class VitalDataControllerTests
    {

        private static string url2 = "http://localhost:56954/api/vitaldata";
        [TestMethod]
        public void Test_GetAllVitalsData()
        {
            var client = new RestClient(url2);
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }

        [TestMethod]
        public void TestGetVitalDataByValidId()
        {
            var client = new RestClient(url2);
            var request = new RestRequest("{postid}", Method.GET);
            request.AddUrlSegment("postid", "1");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
        [TestMethod]
        public void TestGetVitalDataByInValidId()
        {
            var client = new RestClient(url2);
            var request = new RestRequest("{postid}", Method.GET);
            request.AddUrlSegment("postid", "77");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }


        [TestMethod]
        public void TestPostVitalDataByValidId()
        {
            var client = new RestClient(url2);
            var request = new RestRequest(Method.POST);
            var vitalData = new VitalsDataModel()
            {
                PatientId = "2",
                PatientBedId = "41",
                Bpm = 30f,
                Spo2 = 15f,
                RespRate = 170f
            };
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(vitalData);
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
        [TestMethod]
        public void TestPostVitalDataByInValidId()
        {
            var client = new RestClient(url2);
            var request = new RestRequest(Method.POST);
            var vitalData = new VitalsDataModel();
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(vitalData);
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }



        [TestMethod]
        public void TestPutVitalDataByValidId()
        {
            var client = new RestClient(url2);
            var request = new RestRequest("{postid}", Method.PUT);
            request.AddUrlSegment("postid", "3");
            var vitalData = new VitalsDataModel()
            {
                PatientId = "3",
                PatientBedId = "42",
                Bpm = 60f,
                Spo2 = 50f,
                RespRate = 17f
            };
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(vitalData);
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
        [TestMethod]
        public void TestPutVitalDataByInValidId()
        {
            var client = new RestClient(url2);
            var request = new RestRequest("{postid}", Method.PUT);
            request.AddUrlSegment("postid", "99");
            var vitalData = new VitalsDataModel()
            {
                PatientId = "99",
                PatientBedId = "40",
                Bpm = 60f,
                Spo2 = 155f,
                RespRate = 70f
            };
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(vitalData);
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }
        [TestMethod]
        public void TestDeleteVitalDataByValidId()
        {
            var client = new RestClient(url2);
            var request = new RestRequest("{postid}", Method.DELETE);
            request.AddUrlSegment("postid", "4");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
        [TestMethod]
        public void TestDeleteVitalDataByInValidId()
        {
            var client = new RestClient(url2);
            var request = new RestRequest("{postid}", Method.DELETE);
            request.AddUrlSegment("postid", "6h");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }

        [TestMethod]
        public void Test_GeCheckVitalAndAlertData_ForValidId()
        {
            var client = new RestClient(url2);
            var request = new RestRequest("/checkvitalandalert/{postid}", Method.GET);
            request.AddUrlSegment("postid", "6");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
        [TestMethod]
        public void Test_GeCheckVitalAndAlertData_ForInValidId()
        {
            var client = new RestClient(url2);
            var request = new RestRequest("/checkvitalandalert/{postid}", Method.GET);
            request.AddUrlSegment("postid", "6uf");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }

    }
}
