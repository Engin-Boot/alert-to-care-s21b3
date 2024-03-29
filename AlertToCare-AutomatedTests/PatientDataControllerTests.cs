﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Net;
using Alert_To_Care.Models;

namespace AlertToCare_AutomatedTests
{
    [TestClass]
    public class PatientDataControllerTests
    {

        private static string url3 = "http://localhost:56954/api/patientdata";
        [TestMethod]
        public void Test_GetAllPatientsData()
        {
            var client = new RestClient(url3);
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }

        [TestMethod]
        public void TestGetPatientDataByValidId()
        {
            var client = new RestClient(url3);
            var request = new RestRequest("{postid}", Method.GET);
            request.AddUrlSegment("postid", "7");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
        [TestMethod]
        public void TestGetPatientDataByInvalidId()
        {
            var client = new RestClient(url3);
            var request = new RestRequest("{postid}", Method.GET);
            request.AddUrlSegment("postid", "77");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }






        [TestMethod]
        public void TestPostPatientDataByValidId()
        {
            var client = new RestClient(url3);
            var request = new RestRequest(Method.POST);
            var patientData = new PatientDataModel()
            {
                PatientId = "8",
                PatientAge = 49,
                PatientName = "Christ",
                BedId = "47",
                Address = "fgd street, swe city",
                ContactNo = 098432198,
                Email = "fdw@adf.com"
            };
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(patientData);
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
        [TestMethod]
        public void TestPostPatientDataByInValidId()
        {
            var client = new RestClient(url3);
            var request = new RestRequest(Method.POST);
            //PatientDataModel patientData = null;
            request.AddHeader("Content-Type", "application/json");
            //request.AddJsonBody(patientData);
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }



        [TestMethod]
        public void TestPutPatientDataByValidId()
        {
            var client = new RestClient(url3);
            var request = new RestRequest("{postid}", Method.PUT);
            request.AddUrlSegment("postid", "9");
            var patientData = new PatientDataModel()
            {
                PatientId = "9",
                PatientAge = 40,
                PatientName = "DeepakLal",
                BedId = "48",
                Address = "fgd street, swe city",
                ContactNo = 098432198,
                Email = "fdw@adf.com"
            };
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(patientData);
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
        [TestMethod]
        public void TestPutPatientDataByInValidId()
        {
            var client = new RestClient(url3);
            var request = new RestRequest("{postid}", Method.PUT);
            request.AddUrlSegment("postid", "99");
            var patientData = new PatientDataModel()
            {
                PatientId = "99",
                PatientAge = 40,
                PatientName = "rahul",
                BedId = "140",
                Address = "fgd street, swe city",
                ContactNo = 098432198,
                Email = "fdw@adf.com"
            };
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(patientData);
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }

        [TestMethod]
        public void TestDeletePatientDataByValidId()
        {
            var client = new RestClient(url3);
            var request = new RestRequest("{postid}", Method.DELETE);
            request.AddUrlSegment("postid", "10");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
        [TestMethod]
        public void TestDeletePatientDataByInValidId()
        {
            var client = new RestClient(url3);
            var request = new RestRequest("{postid}", Method.DELETE);
            request.AddUrlSegment("postid", "6h");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }

        [TestMethod]
        public void Test_GetBedInfo_ForValidId()
        {
            var client = new RestClient(url3);
            var request = new RestRequest("/getbedinfo/{postid}", Method.GET);
            request.AddUrlSegment("postid", "11");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        }
        [TestMethod]
        public void Test_GetBedInfo_ForInValidId()
        {
            var client = new RestClient(url3);
            var request = new RestRequest("/getbedinfo/{postid}", Method.GET);
            request.AddUrlSegment("postid", "6uf");
            var response = client.Execute(request);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

        }

    }
}
