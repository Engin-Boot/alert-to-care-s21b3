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
    public class ICUDataControllerTests
    {
        private static string url = "http://localhost:56954/api/icudata";
        [TestMethod]
        public void TestGetAllICUData()
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
        [TestMethod]
        public void TestGetICUDataByValidID()
        {
            var client = new RestClient(url);
            var request = new RestRequest("{postid}",Method.GET);
            request.AddUrlSegment("postid","3");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
        [TestMethod]
        public void TestGetICUDataByInValidID()
        {
            var client = new RestClient(url);
            var request = new RestRequest("{postid}", Method.GET);
            request.AddUrlSegment("postid", "77");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }
        [TestMethod]
        public void TestPostICUDataByValidID()
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            var _icuData = new IcuDataModel()
            {
                IcuId = "9",
                Layout = "sq",
                TotalNoOfBeds = 14
            };
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(_icuData);
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
        [TestMethod]
        public void TestPostICUDataByInValidID()
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            var _icuData = new IcuDataModel();
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(_icuData);
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }
        [TestMethod]
        public void TestPutICUDataByValidID()
        {
            var client = new RestClient(url);
            var request = new RestRequest("{postid}",Method.PUT);
            request.AddUrlSegment("postid", "4");
            var _icuDataUpdate = new IcuDataModel()
            {
                IcuId = "4",
                Layout = "sq",
                TotalNoOfBeds = 6
            };
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(_icuDataUpdate);
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
        [TestMethod]
        public void TestPutICUDataByInValidID()
        {
            var client = new RestClient(url);
            var request = new RestRequest("{postid}", Method.PUT);
            request.AddUrlSegment("postid", "99");
            var _icuDataUpdate = new IcuDataModel()
            {
                IcuId = "99",
                Layout = "L",
                TotalNoOfBeds = 23
            };
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(_icuDataUpdate);
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }
        [TestMethod]
        public void TestDeleteICUDataByValidID()
        {
            var client = new RestClient(url);
            var request = new RestRequest("{postid}", Method.DELETE);
            request.AddUrlSegment("postid", "9");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
        [TestMethod]
        public void TestDeleteICUDataByInValidID()
        {
            var client = new RestClient(url);
            var request = new RestRequest("{postid}", Method.DELETE);
            request.AddUrlSegment("postid", "6h");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }
        [TestMethod]
        public void TestGetLayoutByValidID()
        {
            var client = new RestClient(url);
            var request = new RestRequest("/getlayout/{postid}", Method.GET);
            request.AddUrlSegment("postid", "1");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
        [TestMethod]
        public void TestGetLayoutByInValidID()
        {
            var client = new RestClient(url);
            var request = new RestRequest("/getlayout/{postid}", Method.GET);
            request.AddUrlSegment("postid", "44");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }
        [TestMethod]
        public void TestGetBedsByValidID()
        {
            var client = new RestClient(url);
            var request = new RestRequest("/getbeds/{postid}", Method.GET);
            request.AddUrlSegment("postid", "2");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        [TestMethod]
        public void TestGetBedsByInValidID()
        {
            var client = new RestClient(url);
            var request = new RestRequest("/getbeds/{postid}", Method.GET);
            request.AddUrlSegment("postid", "9g");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
