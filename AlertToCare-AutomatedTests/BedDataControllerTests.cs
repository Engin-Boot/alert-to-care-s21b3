using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Net;
using Alert_To_Care.Models;

namespace AlertToCare_AutomatedTests
{
    [TestClass]
    public class BedDataControllerTests
    {
        private static string url = "http://localhost:5695/api/beddata";
        [TestMethod]
        public void TestGetAllBedData()
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
        [TestMethod]
        public void TestGetBedDataByValidId()
        {
            var client = new RestClient(url);
            var request = new RestRequest("{postid}", Method.GET);
            request.AddUrlSegment("postid", "21");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
        [TestMethod]
        public void TestGetBedDataByInValidId()
        {
            var client = new RestClient(url);
            var request = new RestRequest("{postid}", Method.GET);
            request.AddUrlSegment("postid", "90");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }
        [TestMethod]
        public void TestPostBedDataByValidId()
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            var bedData = new BedDataModel()
            {
                BedId = "26",
                IcuId = "19",
                BedStatus= true,
                PatientId = "60"
                
            };
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(bedData);
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
        [TestMethod]
        public void TestPostBedDataByInValidId()
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            //BedDataModel bedData = null;
            request.AddHeader("Content-Type", "application/json");
            //request.AddJsonBody(bedData);
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }
        [TestMethod]
        public void TestPutBedDataByValidId()
        {
            var client = new RestClient(url);
            var request = new RestRequest("{postid}", Method.PUT);
            request.AddUrlSegment("postid", "23");
            var bedDataUpdate = new BedDataModel()
            {
                BedId = "23",
                IcuId = "15",
                BedStatus = true,
                PatientId = "31"
            };
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(bedDataUpdate);
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
        [TestMethod]
        public void TestPutBedDataByInValidId()
        {
            var client = new RestClient(url);
            var request = new RestRequest("{postid}", Method.PUT);
            request.AddUrlSegment("postid", "678");
            var dataUpdate = new BedDataModel()
            {
                BedId = "678",
                BedStatus = false
            };
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(dataUpdate);
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }
        [TestMethod]
        public void TestDeleteBedDataByValidId()
        {
            var client = new RestClient(url);
            var request = new RestRequest("{postid}", Method.DELETE);
            request.AddUrlSegment("postid", "25");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        [TestMethod]
        public void TestDeleteBedDataByInValidId()
        {
            var client = new RestClient(url);
            var request = new RestRequest("{postid}", Method.DELETE);
            request.AddUrlSegment("postid", "6");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }
        [TestMethod]
        public void TestGetBedStatusByValidId()
        {
            var client = new RestClient(url);
            var request = new RestRequest("/getbedstatus/{postid}", Method.GET);
            request.AddUrlSegment("postid", "21");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
        [TestMethod]
        public void TestGetBedStatusByInValidId()
        {
            var client = new RestClient(url);
            var request = new RestRequest("/getlayout/{postid}", Method.GET);
            request.AddUrlSegment("postid", "60");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

        }
    }
}
