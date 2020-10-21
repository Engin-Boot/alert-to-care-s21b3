using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Net;
using Alert_To_Care.Models;

namespace AlertToCare_AutomatedTests
{
    [TestClass]
    public class IcuDataControllerTests
    {
        private static string url = "http://localhost:56954/api/icudata";
        [TestMethod]
        public void TestGetAllIcuData()
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
        [TestMethod]
        public void TestGetIcuDataByValidId()
        {
            var client = new RestClient(url);
            var request = new RestRequest("{postid}",Method.GET);
            request.AddUrlSegment("postid","3");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
        [TestMethod]
        public void TestGetIcuDataByInValidId()
        {
            var client = new RestClient(url);
            var request = new RestRequest("{postid}", Method.GET);
            request.AddUrlSegment("postid", "77");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }
        [TestMethod]
        public void TestPostIcuDataByValidId()
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            var icuData = new IcuDataModel()
            {
                IcuId = "6",
                Layout = "sq",
                TotalNoOfBeds = 15
            };
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(icuData);
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
        [TestMethod]
        public void TestPostIcuDataByInValidId()
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            var icuData = new IcuDataModel();
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(icuData);
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }
        [TestMethod]
        public void TestPutIcuDataByValidId()
        {
            var client = new RestClient(url);
            var request = new RestRequest("{postid}",Method.PUT);
            request.AddUrlSegment("postid", "4");
            var icuDataUpdate = new IcuDataModel()
            {
                IcuId = "4",
                Layout = "sq",
                TotalNoOfBeds = 16
            };
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(icuDataUpdate);
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
        [TestMethod]
        public void TestPutIcuDataByInValidId()
        {
            var client = new RestClient(url);
            var request = new RestRequest("{postid}", Method.PUT);
            request.AddUrlSegment("postid", "99");
            var icuDataUpdate = new IcuDataModel()
            {
                IcuId = "99",
                Layout = "sq",
                TotalNoOfBeds = 23
            };
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(icuDataUpdate);
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }
        [TestMethod]
        public void TestDeleteIcuDataByValidId()
        {
            var client = new RestClient(url);
            var request = new RestRequest("{postid}", Method.DELETE);
            request.AddUrlSegment("postid", "7");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        [TestMethod]
        public void TestDeleteIcuDataByInValidId()
        {
            var client = new RestClient(url);
            var request = new RestRequest("{postid}", Method.DELETE);
            request.AddUrlSegment("postid", "6h");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }
        [TestMethod]
        public void TestGetLayoutByValidId()
        {
            var client = new RestClient(url);
            var request = new RestRequest("/getlayout/{postid}", Method.GET);
            request.AddUrlSegment("postid", "1");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
        [TestMethod]
        public void TestGetLayoutByInValidId()
        {
            var client = new RestClient(url);
            var request = new RestRequest("/getlayout/{postid}", Method.GET);
            request.AddUrlSegment("postid", "44");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }
        [TestMethod]
        public void TestGetBedsByValidId()
        {
            var client = new RestClient(url);
            var request = new RestRequest("/getbeds/{postid}", Method.GET);
            request.AddUrlSegment("postid", "2");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        [TestMethod]
        public void TestGetBedsByInValidId()
        {
            var client = new RestClient(url);
            var request = new RestRequest("/getbeds/{postid}", Method.GET);
            request.AddUrlSegment("postid", "9g");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
