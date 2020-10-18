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
    public class IcuDataControllerTests
    {
        readonly MockICUDataRepository _IcuOperations = new MockICUDataRepository();
        
        [Fact]
        public void WhenGivenValidDataPostICUExecutes()
        {
            IcuDataController _controller = new IcuDataController(_IcuOperations);
            IcuDataModel _icu = new IcuDataModel()
            {
                IcuId = "3",
                Layout = "sq",
                TotalNoOfBeds = 20
            };
            var _response = _controller.Post(_icu);
            var _responseObject =  _response as OkObjectResult;
            Assert.NotNull(_response);
            Assert.Equal(200, _responseObject.StatusCode);
        }
    
        [Fact]
        public void WhenGivenNullDataPostICUFails()
        {
            IcuDataController _controller = new IcuDataController(_IcuOperations);
            IcuDataModel _icu = null;
            var _response = _controller.Post(_icu);
            var _responseObject = _response as BadRequestResult;
            Assert.Equal(400, _responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenInvalidDataPostICUFails()
        {
            IcuDataController _controller = new IcuDataController(_IcuOperations);
            IcuDataModel _icu = new IcuDataModel()
            {
                TotalNoOfBeds = 20
            };
            var _response = _controller.Post(_icu);
            var _responseObject = _response as BadRequestResult;
            Assert.Equal(400, _responseObject.StatusCode);
        }

        [Fact]
        public void WhenFetchingICUDataGetExecutes()
        {
            IcuDataController _controller = new IcuDataController(_IcuOperations);
            var _response = _controller.Get();
            var _responseObject = _response as OkObjectResult;
            Assert.Equal(200, _responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenValidIDGetByIDExecutes()
        {
            IcuDataController _controller = new IcuDataController(_IcuOperations);
            var _response = _controller.Get("1");
            var _responseObject = _response as OkObjectResult;
            Assert.Equal(200, _responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenInValidIDGetByIDFails()
        {
            IcuDataController _controller = new IcuDataController(_IcuOperations);
            var _response = _controller.Get("99");
            var _responseObject = _response as BadRequestResult;
            Assert.Equal(400, _responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenValidIDDeleteExecutes()
        {
            IcuDataController _controller = new IcuDataController(_IcuOperations);
            var _response = _controller.Delete("2");
            var _responseObject = _response as OkObjectResult;
            Assert.Equal(200, _responseObject.StatusCode);
        }

        [Fact]
        public void WhenGivenInValidIDDeleteFails()
        {
            IcuDataController _controller = new IcuDataController(_IcuOperations);
            var _response = _controller.Delete("88");
            var _responseObject = _response as BadRequestResult;
            Assert.Equal(400, _responseObject.StatusCode);
        }

        [Fact]
        public void WhenGivenValidIDPutExecutes()
        {
            IcuDataController _controller = new IcuDataController(_IcuOperations);
            var _changes = new IcuDataModel() { TotalNoOfBeds = 20 };
            var _response = _controller.Put("2",_changes);
            var _responseObject = _response as OkObjectResult;
            Assert.Equal(200, _responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenInValidIDPutFails()
        {
            IcuDataController _controller = new IcuDataController(_IcuOperations);
            var _changes = new IcuDataModel() { TotalNoOfBeds = 39 };
            var _response = _controller.Put("7", _changes);
            var _responseObject = _response as BadRequestResult;
            Assert.Equal(400, _responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenValidIDGetLayoutExecutes()
        {
            IcuDataController _controller = new IcuDataController(_IcuOperations);
            var _response = _controller.GetLayout("1");
            var _responseObject = _response as OkObjectResult;
            Assert.Equal(200, _responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenInValidIDGetLayoutFails()
        {
            IcuDataController _controller = new IcuDataController(_IcuOperations);
            var _response = _controller.GetLayout("11");
            var _responseObject = _response as BadRequestResult;
            Assert.Equal(400, _responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenValidIDGetBedsExecutes()
        {
            IcuDataController _controller = new IcuDataController(_IcuOperations);
            var _response = _controller.GetBeds("2");
            var _responseObject = _response as OkObjectResult;
            Assert.Equal(200, _responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenInValidIDGetBedsFails()
        {
            IcuDataController _controller = new IcuDataController(_IcuOperations);
            var _response = _controller.GetBeds("55");
            var _responseObject = _response as BadRequestResult;
            Assert.Equal(400, _responseObject.StatusCode);
        }
    }
}
