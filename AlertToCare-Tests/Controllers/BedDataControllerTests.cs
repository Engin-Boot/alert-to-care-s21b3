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
    public class BedDataControllerTests
    {
        readonly MockBedDataRepository _bedOperations = new MockBedDataRepository();
        [Fact]
        public void WhenGivenValidDataPostBedExecutes()
        {
            BedDataController _controller = new BedDataController(_bedOperations);
            BedDataModel _bed = new BedDataModel()
            {
                IcuId = "3",
                BedId = "34",
                BedStatus = true,
                PatientId = "30"
            };
            var _response = _controller.Post(_bed);
            var _responseObject = _response as OkObjectResult;
            Assert.NotNull(_response);
            Assert.Equal(200, _responseObject.StatusCode);

        }
        [Fact]
        public void WhenGivenNullDataPostBedFails()
        {
            BedDataController _controller = new BedDataController(_bedOperations);
            BedDataModel _bed = null;
            var _response = _controller.Post(_bed);
            var _responseObject = _response as BadRequestResult;
            Assert.Equal(400, _responseObject.StatusCode);

        }
        [Fact]
        public void WhenFetchingBedDataGetExecutes()
        {
            BedDataController _controller = new BedDataController(_bedOperations);
            var _response = _controller.Get();
            var _responseObject = _response as OkObjectResult;
            Assert.Equal(200, _responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenValidIDGetByIDExecutes()
        {
            BedDataController _controller = new BedDataController(_bedOperations);
            var _response = _controller.Get("8");
            var _responseObject = _response as OkObjectResult;
            Assert.Equal(200, _responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenInValidIDGetByIDFails()
        {
            BedDataController _controller = new BedDataController(_bedOperations);
            var _response = _controller.Get("30");
            var _responseObject = _response as BadRequestResult;
            Assert.Equal(400, _responseObject.StatusCode);

        }
        [Fact]
        public void WhenGivenValidIDDeleteExecutes()
        {
            BedDataController _controller = new BedDataController(_bedOperations);
            var _response = _controller.Delete("12");
            var _responseObject = _response as OkObjectResult;
            Assert.Equal(200, _responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenInValidIDDeleteFails()
        {
            BedDataController _controller = new BedDataController(_bedOperations);
            var _response = _controller.Delete("20");
            var _responseObject = _response as BadRequestResult;
            Assert.Equal(400, _responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenValidIDPutExecutes()
        {
            BedDataController _controller = new BedDataController(_bedOperations);
            var _changes = new BedDataModel() { BedId="12", BedStatus = true, PatientId="4" };
            var _response = _controller.Put("12", _changes);
            var _responseObject = _response as OkObjectResult;
            Assert.Equal(200, _responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenValidIDGetBedStatusExecutes()
        {
            BedDataController _controller = new BedDataController(_bedOperations);
            var _response = _controller.GetBedStatus("8");
            var _responseObject = _response as OkObjectResult;
            Assert.Equal(200, _responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenInValidIDGetBedStatusFails()
        {
            BedDataController _controller = new BedDataController(_bedOperations);
            var _response = _controller.GetBedStatus("40");
            var _responseObject = _response as BadRequestResult;
            Assert.Equal(400, _responseObject.StatusCode);
        }
    }
}
