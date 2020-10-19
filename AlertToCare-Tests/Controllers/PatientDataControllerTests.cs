using System;
using System.Collections.Generic;
using System.Text;
using Alert_To_Care.Models;
using Alert_To_Care.Repository;
using Alert_To_Care.Controllers;
using AlertToCare_Tests.MockRepository;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace AlertToCare_Tests.Controllers
{
    public class PatientDataControllerTests
    {
        readonly MockPatientDataRepository _patientDataOperations = new MockPatientDataRepository();

        [Fact]
        public void WhenGivenValidDataPostExecutes()
        {
            PatientDataController _controller = new PatientDataController(_patientDataOperations);
            PatientDataModel _patient = new PatientDataModel()
            {
                PatientId = "3",
                PatientName = "Harsh",
                PatientAge = 38,
                BedId = "24",
                ContactNo = 1234543211,
                Email = "abc@sdw.com",
                Address = "123 street, avd city"
            };
            var _response = _controller.Post(_patient);
            var _responseObject = _response as OkObjectResult;
            Assert.NotNull(_response);
            Assert.Equal(200, _responseObject.StatusCode);

        }
        [Fact]
        public void WhenGivenInValidDataPostFails()
        {
            PatientDataController _controller = new PatientDataController(_patientDataOperations);
            PatientDataModel _patient = null;
            var _response = _controller.Post(_patient);
            var _responseObject = _response as BadRequestResult;
            Assert.NotNull(_response);
            Assert.Equal(400, _responseObject.StatusCode);
        }
        [Fact]
        public void WhenFetchingPatientDataGetExecutes()
        {
            PatientDataController _controller = new PatientDataController(_patientDataOperations);
            var _response = _controller.Get();
            var _responseObject = _response as OkObjectResult;
            Assert.NotNull(_response);
            Assert.Equal(200, _responseObject.StatusCode);

        }
        [Fact]
        public void WhenGivenValidIDGetByIDExecutes()
        {
            PatientDataController _controller = new PatientDataController(_patientDataOperations);
            var _response = _controller.Get("2");
            var _responseObject = _response as OkObjectResult;
            Assert.NotNull(_response);
            Assert.Equal(200, _responseObject.StatusCode);

        }
        [Fact]
        public void WhenGivenInValidIDGetByIDFails()
        {
            PatientDataController _controller = new PatientDataController(_patientDataOperations);
            var _response = _controller.Get("fr2");
            var _responseObject = _response as BadRequestResult;
            Assert.NotNull(_response);
            Assert.Equal(400, _responseObject.StatusCode);

        }
        [Fact]
        public void WhenGivenValidIDDeleteExecutes()
        {
            PatientDataController _controller = new PatientDataController(_patientDataOperations);
            var _response = _controller.Delete("1");
            var _responseObject = _response as OkObjectResult;
            Assert.NotNull(_response);
            Assert.Equal(200, _responseObject.StatusCode);

        }
        [Fact]
        public void WhenGivenInValidIDDeleteFails()
        {
            PatientDataController _controller = new PatientDataController(_patientDataOperations);
            var _response = _controller.Delete("h3f");
            var _responseObject = _response as BadRequestResult;
            Assert.NotNull(_response);
            Assert.Equal(400, _responseObject.StatusCode);

        }
        [Fact]
        public void WhenGivenValidIDPutExecutes()
        {
            PatientDataController _controller = new PatientDataController(_patientDataOperations);
            var _changes = new PatientDataModel() { PatientId = "1", PatientAge = 49};
            var _response = _controller.Put("1", _changes);
            var _responseObject = _response as OkObjectResult;
            Assert.Equal(200, _responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenValidIDGetBedInfoExecutes()
        {
            PatientDataController _controller = new PatientDataController(_patientDataOperations);
            var _response = _controller.GetBedInfo("2");
            var _responseObject = _response as OkObjectResult;
            Assert.Equal(200, _responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenInValidIDGetBedInfoFails()
        {
            PatientDataController _controller = new PatientDataController(_patientDataOperations);
            var _response = _controller.GetBedInfo("fd5");
            var _responseObject = _response as BadRequestResult;
            Assert.Equal(400, _responseObject.StatusCode);
        }
    }
}
