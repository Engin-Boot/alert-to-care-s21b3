using Alert_To_Care.Models;
using Alert_To_Care.Controllers;
using AlertToCare_Tests.MockRepository;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace AlertToCare_Tests.Controllers
{
    public class VitalDataControllerTests
    {
        private readonly MockVitalDataRepository _vitalOperations = new MockVitalDataRepository();

        // ---------------------POST--------------------------

        [Fact]
        public void WhenGiven_ValidData_PostVitalExecutes()
        {
            VitalDataController controller = new VitalDataController(_vitalOperations);
            VitalsDataModel vital = new VitalsDataModel()
            {
                PatientId = "3",
                PatientBedId = "43",
                Bpm = 60f,
                Spo2 = 55f,
                RespRate = 70f
            };
            var response = controller.Post(vital);
            var responseObject = response as OkObjectResult;
            Assert.NotNull(response);
            Assert.NotNull(responseObject);
            Assert.Equal(200, responseObject.StatusCode);
        }

        [Fact]
        public void WhenGiven_NullData_PostVitalFails()
        {
            VitalDataController controller = new VitalDataController(_vitalOperations);
            var response = controller.Post(null);
            var responseObject = response as BadRequestObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(400, responseObject.StatusCode);
        }
        [Fact]
        public void WhenGiven_InvalidDataTypeOfBpm_PostVitalFails()
        {
            VitalDataController controller = new VitalDataController(_vitalOperations);
            VitalsDataModel vital = new VitalsDataModel()
            {
                Bpm = 60,
            };
            var response = controller.Post(vital);
            var responseObject = response as BadRequestObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(400, responseObject.StatusCode);
        }
        [Fact]
        public void WhenGiven_InvalidDataTypeOfSpo2_PostVitalFails()
        {
            VitalDataController controller = new VitalDataController(_vitalOperations);
            VitalsDataModel vital = new VitalsDataModel()
            {
                Spo2 = 55,
            };
            var response = controller.Post(vital);
            var responseObject = response as BadRequestObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(400, responseObject.StatusCode);
        }
        [Fact]
        public void WhenGiven_InvalidDataTypeOfRespRate_PostVitalFails()
        {
            VitalDataController controller = new VitalDataController(_vitalOperations);
            VitalsDataModel vital = new VitalsDataModel()
            {
                RespRate = 70,
            };
            var response = controller.Post(vital);
            var responseObject = response as BadRequestObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(400, responseObject.StatusCode);
        }


        //----------------------GET-----------------------------

        [Fact]
        public void When_FetchingAllVitalData_GetExecutes()
        {
            VitalDataController controller = new VitalDataController(_vitalOperations);
            var response = controller.Get();
            var responseObject = response as OkObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(200, responseObject.StatusCode);
        }

        //------------------------GET {id} -------------------------------

        [Fact]
        public void WhenGiven_ValidId_GetById_Executes()
        {
            VitalDataController controller = new VitalDataController(_vitalOperations);
            var response = controller.Get("1");
            var responseObject = response as OkObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(200, responseObject.StatusCode);
        }
        [Fact]
        public void WhenGiven_InValidId_GetById_FailsToExecute()
        {
            VitalDataController controller = new VitalDataController(_vitalOperations);
            var response = controller.Get("99");
            var responseObject = response as BadRequestObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(400, responseObject.StatusCode);
        }


        //------------------GET : CHECK VITAL AND ALERT {id} --------------------------


        [Fact]
        public void WhenGiven_ValidId_CheckVitalAndAlertFails()
        {
            VitalDataController controller = new VitalDataController(_vitalOperations);
            var response = controller.CheckVitalAndAlert("1");
            var responseObject = response as OkObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(200, responseObject.StatusCode);
        }

        [Fact]
        public void WhenGiven_InValidId_CheckVitalAndAlertFails()
        {
            VitalDataController controller = new VitalDataController(_vitalOperations);
            var response = controller.CheckVitalAndAlert("100");
            var responseObject = response as BadRequestObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(400, responseObject.StatusCode);
        }

        //---------------------------- DELETE {id} ----------------------------------

        [Fact]
        public void WhenGiven_ValidId_DeleteExecutes()
        {
            VitalDataController controller = new VitalDataController(_vitalOperations);
            var response = controller.Delete("2");
            var responseObject = response as OkObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(200, responseObject.StatusCode);
        }

        [Fact]
        public void WhenGiven_InValidId_DeleteFails()
        {
            VitalDataController controller = new VitalDataController(_vitalOperations);
            var response = controller.Delete("88");
            var responseObject = response as BadRequestObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(400, responseObject.StatusCode);
        }

        //---------------------------- PUT {id} ----------------------------------
        [Fact]
        public void WhenGiven_ValidId_PutExecutes()
        {
            VitalDataController controller = new VitalDataController(_vitalOperations);
            var changes = new VitalsDataModel()
            {
                PatientId = "2",
                PatientBedId = "41",
                Bpm = 160f,
                Spo2 = 10f,
                RespRate = 70f
            };
            var response = controller.Put("2", changes);
            var responseObject = response as OkObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(200, responseObject.StatusCode);
        }

        [Fact]
        public void WhenGiven_InValidId_PutExecutes()
        {
            VitalDataController controller = new VitalDataController(_vitalOperations);
            var changes = new VitalsDataModel()
            {
                PatientId = "1000",
                PatientBedId = "41",
                Bpm = 160f,
                Spo2 = 10f,
                RespRate = 70f
            };
            var response = controller.Put("1000", changes);
            var responseObject = response as BadRequestObjectResult;
            Assert.NotNull(responseObject);
            Assert.Equal(400, responseObject.StatusCode);
        }
    }
}
