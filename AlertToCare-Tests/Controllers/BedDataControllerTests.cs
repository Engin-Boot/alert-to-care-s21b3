using Alert_To_Care.Models;
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
            BedDataController controller = new BedDataController(_bedOperations);
            BedDataModel bed = new BedDataModel()
            {
                IcuId = "3",
                BedId = "34",
                BedStatus = true,
                PatientId = "30"
            };
            var response = controller.Post(bed);
            var responseObject = response as OkObjectResult;
            Assert.NotNull(response);
            Assert.NotNull(responseObject);
            Assert.Equal(200, responseObject.StatusCode);

        }
        [Fact]
        public void WhenGivenNullDataPostBedFails()
        {
            BedDataController controller = new BedDataController(_bedOperations);
            var response = controller.Post(null);
            var responseObject = response as BadRequestObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(400, responseObject.StatusCode);

        }
        [Fact]
        public void WhenFetchingBedDataGetExecutes()
        {
            BedDataController controller = new BedDataController(_bedOperations);
            var response = controller.Get();
            var responseObject = response as OkObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(200, responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenValidIdGetByIdExecutes()
        {
            BedDataController controller = new BedDataController(_bedOperations);
            var response = controller.Get("8");
            var responseObject = response as OkObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(200, responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenIcuIdGetBedsByIcuIdExecutes()
        {
            BedDataController controller = new BedDataController(_bedOperations);
            var response = controller.GetBedsByIcuId("1");
            var responseObject = response as OkObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(200, responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenInValidIdGetByIdFails()
        {
            BedDataController controller = new BedDataController(_bedOperations);
            var response = controller.Get("30");
            var responseObject = response as BadRequestObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(400, responseObject.StatusCode);

        }
        [Fact]
        public void WhenGivenValidIdDeleteExecutes()
        {
            BedDataController controller = new BedDataController(_bedOperations);
            var response = controller.Delete("12");
            var responseObject = response as OkObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(200, responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenInValidIdDeleteFails()
        {
            BedDataController controller = new BedDataController(_bedOperations);
            var response = controller.Delete("20");
            var responseObject = response as BadRequestObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(400, responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenValidIdPutExecutes()
        {
            BedDataController controller = new BedDataController(_bedOperations);
            var changes = new BedDataModel() { BedId="12", BedStatus = true, PatientId="4" };
            var response = controller.Put("12", changes);
            var responseObject = response as OkObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(200, responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenInvalidBedIdPutFails()
        {
            BedDataController controller = new BedDataController(_bedOperations);
            var changes = new BedDataModel() { BedId = "132", BedStatus = true, PatientId = "4" };
            var response = controller.Put("132", changes);
            var responseObject = response as BadRequestObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(400, responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenUnmatchedBedIdPutFails()
        {
            BedDataController controller = new BedDataController(_bedOperations);
            var changes = new BedDataModel() { BedId = "12", BedStatus = true, PatientId = "4" };
            var response = controller.Put("132", changes);
            var responseObject = response as BadRequestObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(400, responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenValidIdGetBedStatusExecutes()
        {
            BedDataController controller = new BedDataController(_bedOperations);
            var response = controller.GetBedStatus("8");
            var responseObject = response as OkObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(200, responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenInValidIdGetBedStatusFails()
        {
            BedDataController controller = new BedDataController(_bedOperations);
            var response = controller.GetBedStatus("40");
            var responseObject = response as BadRequestObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(400, responseObject.StatusCode);
        }
    }
}
