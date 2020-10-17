using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        IPatientDataRepository _patientdatabase;

        public PatientDataController(IPatientDataRepository repo)
        {
            this._patientdatabase = repo;
        }
        
        //GET: api/<PatientDataController>
        [HttpGet]
        public IActionResult Get()
        {
            var _allPatients = _patientdatabase.GetAllPatients();
            if(_allPatients != null)
            {
                return Ok(_allPatients);
            }
            return BadRequest();
        }

        // GET api/<PatientDataController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            PatientDataModel _patient = _patientdatabase.GetPatientInfoFromId(id);
            if(_patient != null)
            {
                return Ok(_patient);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetBedInfo(string id)
        {
            var _patientInfo = _patientdatabase.GetPatientInfoFromId(id);
            if(_patientInfo != null)
            {
                var _bedId = _patientInfo.BedId;
                return Ok(_patientdatabase.BedInfoFromPatientId(_bedId));
            }
            return BadRequest();
        }

        //POST api/<PatientDataController>
        [HttpPost]
        public IActionResult Post([FromBody] PatientDataModel _patient)
        {
            if(_patient != null)
            {
                var result = _patientdatabase.NewPatientAdd(_patient);
                return Ok(result);

            }
            return BadRequest();
        }

        // DELETE api/<PatientDataController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            PatientDataModel _patient = _patientdatabase.GetPatientInfoFromId(id);
            if(_patient != null)
            {
                var result = _patientdatabase.DischargePatient(id);
                return Ok(result);
            }
            return BadRequest();
        }


        //PUT api/<PatientDataController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] PatientDataModel _patientDetailchanges)
        { 
                _patientDetailchanges.PatientId = id;
                var result = _patientdatabase.UpdatePatient(_patientDetailchanges);
                return Ok(result);
          
        }

        
    }
}
