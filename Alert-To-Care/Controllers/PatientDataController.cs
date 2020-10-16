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
            return this._patientdatabase.GetAllPatients();
        }

        // GET api/<PatientDataController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
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
                return Ok(_patient);
            }
            catch
            {
                return BadRequest();
            }
            
        }

        //POST api/<PatientDataController>
        [HttpPost]
        public IActionResult Post([FromBody] PatientDataModel _patient)
        {
            try
            {
                _patientdatabase.NewPatientAdd(_patient);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        //PUT api/<PatientDataController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PatientDataController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
