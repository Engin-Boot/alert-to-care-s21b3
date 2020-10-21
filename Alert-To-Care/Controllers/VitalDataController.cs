using Microsoft.AspNetCore.Mvc;
using Alert_To_Care.Repository;
using Alert_To_Care.Models;

namespace Alert_To_Care.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VitalDataController : ControllerBase
    {
        private readonly IVitalDataRepository _vitaldatabase;

        public VitalDataController(IVitalDataRepository repo)
        {
            _vitaldatabase = repo;
        }

        // GET: api/<VitalDataController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _vitaldatabase.GetAll();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();

        }


        // GET: api/<VitalDataController>
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            VitalsDataModel vital = _vitaldatabase.GetAllVital(id);
            if (vital != null)
            {
                return Ok(vital);
            }
            return BadRequest();
        }

        // GET api/<VitalDataController>/5
        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult CheckVitalAndAlert(string id)
        {
            string alert = _vitaldatabase.CheckVital(id);
            if (alert == null)
            {
                return BadRequest();
            }
            return Ok(alert);
        }


        // POST api/<VitalDataController>
        [HttpPost]
        public IActionResult Post([FromBody] VitalsDataModel vital)
        {
            var result = _vitaldatabase.NewVitalAdd(vital);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        // DELETE api/<VitalDataController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            VitalsDataModel vital = _vitaldatabase.RemoveVital(id);
            if (vital != null)
            {
                return Ok(vital);
            }

            return BadRequest();
        }

        //PUT api/<VitalDataController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] VitalsDataModel vitalDetailchanges)
        {
            if (vitalDetailchanges.PatientId == id)
            {
                var result = _vitaldatabase.UpdatePatientVitals(vitalDetailchanges);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            return BadRequest();
        }
    }
}
