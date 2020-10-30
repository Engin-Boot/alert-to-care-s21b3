using Alert_To_Care.Models;
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
            PatientDataController controller = new PatientDataController(_patientDataOperations);
            PatientDataModel patient = new PatientDataModel()
            {
                PatientId = "33",
                PatientName = "Harsh",
                PatientAge = 38,
                BedId = "24",
                ContactNo = 1234543211,
                Email = "abc@sdw.com",
                Address = "123 street, avd city"
            };
            var response = controller.Post(patient);
            var responseObject = response as OkObjectResult;
            Assert.NotNull(response);
            Assert.NotNull(responseObject);
            Assert.Equal(200, responseObject.StatusCode);

        }
        [Fact]
        public void WhenGivenInValidDataPostFails()
        {
            PatientDataController controller = new PatientDataController(_patientDataOperations);
            var response = controller.Post(null);
            var responseObject = response as BadRequestObjectResult;
            Assert.NotNull(response);
            Assert.NotNull(responseObject);
            Assert.Equal(400, responseObject.StatusCode);
        }
        [Fact]
        public void WhenFetchingPatientDataGetExecutes()
        {
            PatientDataController controller = new PatientDataController(_patientDataOperations);
            var response = controller.Get();
            var responseObject = response as OkObjectResult;
            Assert.NotNull(response);
            Assert.NotNull(responseObject);
            Assert.Equal(200, responseObject.StatusCode);

        }
        [Fact]
        public void WhenGivenValidIdGetByIdExecutes()
        {
            PatientDataController controller = new PatientDataController(_patientDataOperations);
            var response = controller.Get("2");
            var responseObject = response as OkObjectResult;
            Assert.NotNull(response);
            Assert.NotNull(responseObject);
            Assert.Equal(200, responseObject.StatusCode);

        }
        [Fact]
        public void WhenGivenInValidIdGetByIdFails()
        {
            PatientDataController controller = new PatientDataController(_patientDataOperations);
            var response = controller.Get("fr2");
            var responseObject = response as BadRequestObjectResult;
            Assert.NotNull(response);
            Assert.NotNull(responseObject);
            Assert.Equal(400, responseObject.StatusCode);

        }
        [Fact]
        public void WhenGivenValidIdDeleteExecutes()
        {
            PatientDataController controller = new PatientDataController(_patientDataOperations);
            var response = controller.Delete("1");
            var responseObject = response as OkObjectResult;
            Assert.NotNull(response);
            Assert.NotNull(responseObject);
            Assert.Equal(200, responseObject.StatusCode);

        }
        [Fact]
        public void WhenGivenInValidIdDeleteFails()
        {
            PatientDataController controller = new PatientDataController(_patientDataOperations);
            var response = controller.Delete("h3f");
            var responseObject = response as BadRequestObjectResult;
            Assert.NotNull(response);
            Assert.NotNull(responseObject);
            Assert.Equal(400, responseObject.StatusCode);

        }
        [Fact]
        public void WhenGivenValidIdPutExecutes()
        {
            PatientDataController controller = new PatientDataController(_patientDataOperations);
            var changes = new PatientDataModel() { PatientId = "1", PatientAge = 49};
            var response = controller.Put("1", changes);
            var responseObject = response as OkObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(200, responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenInvalidIdPutFails()
        {
            PatientDataController controller = new PatientDataController(_patientDataOperations);
            var changes = new PatientDataModel() { PatientId = "86", PatientAge = 49 };
            var response = controller.Put("86", changes);
            var responseObject = response as BadRequestObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(400, responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenUnmatchedIdPutFails()
        {
            PatientDataController controller = new PatientDataController(_patientDataOperations);
            var changes = new PatientDataModel() { PatientId = "1", PatientAge = 49 };
            var response = controller.Put("8", changes);
            var responseObject = response as BadRequestObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(400, responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenValidIdGetBedInfoExecutes()
        {
            PatientDataController controller = new PatientDataController(_patientDataOperations);
            var response = controller.GetBedInfo("2");
            var responseObject = response as OkObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(200, responseObject.StatusCode);
        }
        [Fact]
        public void WhenGivenInValidIdGetBedInfoFails()
        {
            PatientDataController controller = new PatientDataController(_patientDataOperations);
            var response = controller.GetBedInfo("fd5");
            var responseObject = response as BadRequestObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(400, responseObject.StatusCode);
        }
    }
}
