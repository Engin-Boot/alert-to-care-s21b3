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
        public IEnumerable<PatientDataModel> Get()
        {
            return _patientdatabase.GetAllPatients();
        }

        // GET api/<PatientDataController>/5
        [HttpGet("{id}")]
        public PatientDataModel Get(string id)
        {
            PatientDataModel _patient = default(PatientDataModel);
                foreach (PatientDataModel _patientTemp in _patientdatabase.GetAllPatients())
                {
                    if (String.Equals(_patientTemp.PatientId,id))
                    {
                        _patient = _patientTemp;
                        break;
                    }
                }
                return _patient;
        }
        
        //POST api/<PatientDataController>
        [HttpPost]
        public IActionResult Post([FromBody] PatientDataModel _patient)
        {
            _patientdatabase.NewPatientAdd(_patient);
            return Ok();
        }

        // DELETE api/<PatientDataController>/5
        [HttpDelete("{id}")]
        public PatientDataModel Delete(string id)
        {
            PatientDataModel _icu = _patientdatabase.DischargePatient(id);
            return _icu;
        }


        //PUT api/<PatientDataController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        
    }
}
