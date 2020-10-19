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
    public class VitalDataControllerTests
    {
        readonly MockVitalDataRepository _VitalOperations = new MockVitalDataRepository();

        // ---------------------POST--------------------------

        [Fact]
        public void WhenGiven_ValidData_PostVitalExecutes()
        {
            VitalDataController _controller = new VitalDataController(_VitalOperations);
            VitalsDataModel _vital = new VitalsDataModel()
            {
                PatientId = "3",
                PatientBedId = "43",
                Bpm = 60f,
                Spo2 = 55f,
                RespRate = 70f
            };
            var _response = _controller.Post(_vital);
            var _responseObject = _response as OkObjectResult;
            Assert.NotNull(_response);
            Assert.Equal(200, _responseObject.StatusCode);
        }

        [Fact]
        public void WhenGiven_NullData_PostVitalFails()
        {
            VitalDataController _controller = new VitalDataController(_VitalOperations);
            VitalsDataModel _vital = null;
            var _response = _controller.Post(_vital);
            var _responseObject = _response as BadRequestResult;
            Assert.Equal(400, _responseObject.StatusCode);
        }
        [Fact]
        public void WhenGiven_InvalidDataTypeOfBpm_PostVitalFails()
        {
            VitalDataController _controller = new VitalDataController(_VitalOperations);
            VitalsDataModel _vital = new VitalsDataModel()
            {
                Bpm = 60,
            };
            var _response = _controller.Post(_vital);
            var _responseObject = _response as BadRequestResult;
            Assert.Equal(400, _responseObject.StatusCode);
        }
        [Fact]
        public void WhenGiven_InvalidDataTypeOfSpo2_PostVitalFails()
        {
            VitalDataController _controller = new VitalDataController(_VitalOperations);
            VitalsDataModel _vital = new VitalsDataModel()
            {
                Spo2 = 55,
            };
            var _response = _controller.Post(_vital);
            var _responseObject = _response as BadRequestResult;
            Assert.Equal(400, _responseObject.StatusCode);
        }
        [Fact]
        public void WhenGiven_InvalidDataTypeOfRespRate_PostVitalFails()
        {
            VitalDataController _controller = new VitalDataController(_VitalOperations);
            VitalsDataModel _vital = new VitalsDataModel()
            {
                RespRate = 70,
            };
            var _response = _controller.Post(_vital);
            var _responseObject = _response as BadRequestResult;
            Assert.Equal(400, _responseObject.StatusCode);
        }


        //----------------------GET-----------------------------

        [Fact]
        public void When_FetchingAllVitalData_GetExecutes()
        {
            VitalDataController _controller = new VitalDataController(_VitalOperations);
            var _response = _controller.Get();
            var _responseObject = _response as OkObjectResult;
            Assert.Equal(200, _responseObject.StatusCode);
        }

        //------------------------GET {id} -------------------------------

        [Fact]
        public void WhenGiven_ValidID_GetByID_Executes()
        {
            VitalDataController _controller = new VitalDataController(_VitalOperations);
            var _response = _controller.Get("1");
            var _responseObject = _response as OkObjectResult;
            Assert.Equal(200, _responseObject.StatusCode);
        }
        [Fact]
        public void WhenGiven_InValidID_GetByID_FailsToExecute()
        {
            VitalDataController _controller = new VitalDataController(_VitalOperations);
            var _response = _controller.Get("99");
            var _responseObject = _response as BadRequestResult;
            Assert.Equal(400, _responseObject.StatusCode);
        }


        //------------------GET : CHECK VITAL AND ALERT {id} --------------------------


        [Fact]
        public void WhenGiven_ValidId_CheckVitalAndAlertFails()
        {
            VitalDataController _controller = new VitalDataController(_VitalOperations);
            var _response = _controller.CheckVitalAndAlert("1");
            var _responseObject = _response as OkObjectResult;
            Assert.Equal(200, _responseObject.StatusCode);
        }

        [Fact]
        public void WhenGiven_InValidId_CheckVitalAndAlertFails()
        {
            VitalDataController _controller = new VitalDataController(_VitalOperations);
            var _response = _controller.CheckVitalAndAlert("100");
            var _responseObject = _response as BadRequestResult;
            Assert.Equal(400, _responseObject.StatusCode);
        }

        //---------------------------- DELETE {id} ----------------------------------

        [Fact]
        public void WhenGiven_ValidID_DeleteExecutes()
        {
            VitalDataController _controller = new VitalDataController(_VitalOperations);
            var _response = _controller.Delete("2");
            var _responseObject = _response as OkObjectResult;
            Assert.Equal(200, _responseObject.StatusCode);
        }

        [Fact]
        public void WhenGiven_InValidID_DeleteFails()
        {
            VitalDataController _controller = new VitalDataController(_VitalOperations);
            var _response = _controller.Delete("88");
            var _responseObject = _response as BadRequestResult;
            Assert.Equal(400, _responseObject.StatusCode);
        }

        //---------------------------- PUT {id} ----------------------------------
        [Fact]
        public void WhenGiven_ValidID_PutExecutes()
        {
            VitalDataController _controller = new VitalDataController(_VitalOperations);
            var _changes = new VitalsDataModel()
            {
                PatientId = "2",
                PatientBedId = "41",
                Bpm = 160f,
                Spo2 = 10f,
                RespRate = 70f
            };
            var _response = _controller.Put("2", _changes);
            var _responseObject = _response as OkObjectResult;
            Assert.Equal(200, _responseObject.StatusCode);
        }

        [Fact]
        public void WhenGiven_InValidID_PutExecutes()
        {
            VitalDataController _controller = new VitalDataController(_VitalOperations);
            var _changes = new VitalsDataModel()
            {
                PatientId = "1000",
                PatientBedId = "41",
                Bpm = 160f,
                Spo2 = 10f,
                RespRate = 70f
            };
            var _response = _controller.Put("1000", _changes);
            var _responseObject = _response as BadRequestResult;
            Assert.Equal(400, _responseObject.StatusCode);
        }
    }
}
