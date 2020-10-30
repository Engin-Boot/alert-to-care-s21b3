using Microsoft.AspNetCore.Mvc;
using Alert_To_Care.Models;
using Alert_To_Care.Repository;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Alert_To_Care.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientDataController : ControllerBase
    {
        private readonly IPatientDataRepository _patientdatabase;

        public PatientDataController(IPatientDataRepository repo)
        {
            _patientdatabase = repo;
        }
        
        //GET: api/<PatientDataController>
        [HttpGet]
        public IActionResult Get()
        {
            var allPatients = _patientdatabase.GetAllPatients();
            return Ok(allPatients);
        }

        // GET api/<PatientDataController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            PatientDataModel patient = _patientdatabase.GetPatientInfoFromId(id);
            if(patient != null)
            {
                return Ok(patient);
            }
            return BadRequest("Patient not found!");
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetBedInfo(string id)
        {
            BedDataModel patientInfo = _patientdatabase.BedInfoFromPatientId(id);
            if(patientInfo != null)
            {
                return Ok(patientInfo);
            }
            return BadRequest("Patient not found OR Bed information for patient not found!");
        }

        //POST api/<PatientDataController>
        [HttpPost]
        public IActionResult Post([FromBody] PatientDataModel patient)
        {
            if (patient == null)
            {
                return BadRequest("Patient cannot be added. Provide all details to add new patient!");
            }

            if (_patientdatabase.GetPatientInfoFromId(patient.PatientId) != null)
            {
                return BadRequest("Patient already exists");
            }
            
            var result = _patientdatabase.NewPatientAdd(patient);
            return Ok(result);
        }

        // DELETE api/<PatientDataController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            PatientDataModel patient = _patientdatabase.GetPatientInfoFromId(id);
            if(patient != null)
            {
                var result = _patientdatabase.DischargePatient(id);
                return Ok(result);
            }
            return BadRequest("Delete operation failed. Patient does not exist!");
        }


        //PUT api/<PatientDataController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] PatientDataModel patientDetailchanges)
        {
            if (patientDetailchanges.PatientId == id)
            {
                var result = _patientdatabase.UpdatePatient(patientDetailchanges);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            return BadRequest("Update operation failed. Patient does not exist!"); 
        }
        
    }
}
