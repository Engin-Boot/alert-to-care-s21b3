using Alert_To_Care.Models;
using Alert_To_Care.Controllers;
using AlertToCare_Tests.MockRepository;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace AlertToCare_Tests.Controllers
{
    public class IcuDataControllerTests
    {
        private readonly MockIcuDataRepository _icuOperations = new MockIcuDataRepository();
        
        [Fact]
        public void WhenGivenValidDataPostIcuExecutes()
        {
            IcuDataController controller = new IcuDataController(_icuOperations);
            IcuDataModel icu = new IcuDataModel()
            {
                IcuId = "3",
                Layout = "sq",
                TotalNoOfBeds = 20
            };
            var response = controller.Post(icu);
            var responseObject =  response as OkObjectResult;
            Assert.NotNull(response);
            Assert.NotNull(responseObject);
            Assert.Equal(200, responseObject.StatusCode);
        }
    
        [Fact]
        public void WhenGivenNullDataPostIcuFails()
        {
            IcuDataController controller = new IcuDataController(_icuOperations);
            IcuDataModel icu = new IcuDataModel();
            var response = controller.Post(icu);
            var responseObject = response as BadRequestObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(400, responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenInvalidDataPostIcuFails()
        {
            IcuDataController controller = new IcuDataController(_icuOperations);
            IcuDataModel icu = new IcuDataModel()
            {
                TotalNoOfBeds = 20
            };
            var response = controller.Post(icu);
            var responseObject = response as BadRequestObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(400, responseObject.StatusCode);
        }

        [Fact]
        public void WhenFetchingIcuDataGetExecutes()
        {
            IcuDataController controller = new IcuDataController(_icuOperations);
            var response = controller.Get();
            var responseObject = response as OkObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(200, responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenValidIdGetByIdExecutes()
        {
            IcuDataController controller = new IcuDataController(_icuOperations);
            var response = controller.Get("1");
            var responseObject = response as OkObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(200, responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenInValidIdGetByIdFails()
        {
            IcuDataController controller = new IcuDataController(_icuOperations);
            var response = controller.Get("99");
            var responseObject = response as BadRequestObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(400, responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenValidIdDeleteExecutes()
        {
            IcuDataController controller = new IcuDataController(_icuOperations);
            var response = controller.Delete("2");
            var responseObject = response as OkObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(200, responseObject.StatusCode);
        }

        [Fact]
        public void WhenGivenInValidIdDeleteFails()
        {
            IcuDataController controller = new IcuDataController(_icuOperations);
            var response = controller.Delete("88");
            var responseObject = response as BadRequestObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(400, responseObject.StatusCode);
        }

        [Fact]
        public void WhenGivenValidIdPutExecutes()
        {
            IcuDataController controller = new IcuDataController(_icuOperations);
            var changes = new IcuDataModel() { IcuId = "1", TotalNoOfBeds = 20, Layout = "L" };
            var response = controller.Put("1",changes);
            var responseObject = response as OkObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(200, responseObject.StatusCode);
        }

        [Fact]
        public void WhenGivenInvalidIcuIdPutFails()
        {
            IcuDataController controller = new IcuDataController(_icuOperations);
            var changes = new IcuDataModel() { IcuId = "42", TotalNoOfBeds = 20, Layout = "L" };
            var response = controller.Put("42", changes);
            var responseObject = response as BadRequestObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(400, responseObject.StatusCode);
        }

        [Fact]
        public void WhenGivenUnmatchedIcuIdPutFails()
        {
            IcuDataController controller = new IcuDataController(_icuOperations);
            var changes = new IcuDataModel() { IcuId = "1", TotalNoOfBeds = 20, Layout = "L" };
            var response = controller.Put("8", changes);
            var responseObject = response as BadRequestObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(400, responseObject.StatusCode);
        }

        [Fact]
        public void WhenGivenValidIdGetLayoutExecutes()
        {
            IcuDataController controller = new IcuDataController(_icuOperations);
            var response = controller.GetLayout("1");
            var responseObject = response as OkObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(200, responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenInValidIdGetLayoutFails()
        {
            IcuDataController controller = new IcuDataController(_icuOperations);
            var response = controller.GetLayout("11");
            var responseObject = response as BadRequestObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(400, responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenValidIdGetBedsExecutes()
        {
            IcuDataController controller = new IcuDataController(_icuOperations);
            var response = controller.GetBeds("2");
            var responseObject = response as OkObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(200, responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenInValidIdGetBedsFails()
        {
            IcuDataController controller = new IcuDataController(_icuOperations);
            var response = controller.GetBeds("55");
            var responseObject = response as BadRequestObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(400, responseObject.StatusCode);
        }
    }
}
