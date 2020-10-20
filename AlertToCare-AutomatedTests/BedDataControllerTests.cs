using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Net;
using Gherkin;
using Newtonsoft.Json;
using Alert_To_Care.Models;

namespace AlertToCare_AutomatedTests
{
    [TestClass]
    public class BedDataControllerTests
    {
        private static string url = "http://localhost:56954/api/beddata";
        [TestMethod]
        public void TestGetAllBedData()
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
        [TestMethod]
        public void TestGetBedDataByValidID()
        {
            var client = new RestClient(url);
            var request = new RestRequest("{postid}", Method.GET);
            request.AddUrlSegment("postid", "21");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
        [TestMethod]
        public void TestGetBedDataByInValidID()
        {
            var client = new RestClient(url);
            var request = new RestRequest("{postid}", Method.GET);
            request.AddUrlSegment("postid", "90");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }
        [TestMethod]
        public void TestPostBedDataByValidID()
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            var _bedData = new BedDataModel()
            {
                BedId = "26",
                IcuId = "19",
                BedStatus= true,
                PatientId = "60"
                
            };
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(_bedData);
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
        [TestMethod]
        public void TestPostBedDataByInValidID()
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            BedDataModel _bedData = null;
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(_bedData);
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }
        [TestMethod]
        public void TestPutBedDataByValidID()
        {
            var client = new RestClient(url);
            var request = new RestRequest("{postid}", Method.PUT);
            request.AddUrlSegment("postid", "23");
            var _bedDataUpdate = new BedDataModel()
            {
                BedId = "23",
                IcuId = "15",
                BedStatus = true,
                PatientId = "31"
            };
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(_bedDataUpdate);
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
        [TestMethod]
        public void TestPutBedDataByInValidID()
        {
            var client = new RestClient(url);
            var request = new RestRequest("{postid}", Method.PUT);
            request.AddUrlSegment("postid", "678");
            var _dataUpdate = new BedDataModel()
            {
                BedId = "678",
                BedStatus = false
            };
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(_dataUpdate);
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }
        [TestMethod]
        public void TestDeleteBedDataByValidID()
        {
            var client = new RestClient(url);
            var request = new RestRequest("{postid}", Method.DELETE);
            request.AddUrlSegment("postid", "25");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        [TestMethod]
        public void TestDeleteBedDataByInValidID()
        {
            var client = new RestClient(url);
            var request = new RestRequest("{postid}", Method.DELETE);
            request.AddUrlSegment("postid", "6");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }
        [TestMethod]
        public void TestGetBedStatusByValidID()
        {
            var client = new RestClient(url);
            var request = new RestRequest("/getbedstatus/{postid}", Method.GET);
            request.AddUrlSegment("postid", "21");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
        [TestMethod]
        public void TestGetBedStatusByInValidID()
        {
            var client = new RestClient(url);
            var request = new RestRequest("/getlayout/{postid}", Method.GET);
            request.AddUrlSegment("postid", "60");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

        }
    }
}
