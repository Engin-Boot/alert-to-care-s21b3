using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Alert_To_Care.Repository;
using Alert_To_Care.Models;

namespace Alert_To_Care.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VitalDataController : ControllerBase
    {
        IVitalDataRepository _vitaldatabase;

        public VitalDataController(IVitalDataRepository repo)
        {
            this._vitaldatabase = repo;
        }

        // GET: api/<VitalDataController>
        [HttpGet]
        public IEnumerable<VitalsDataModel> Get()
        {
            return _vitaldatabase.GetAll();

        }


        // GET: api/<VitalDataController>
        [HttpGet("{id}")]
        public VitalsDataModel Get(string id)
        {
            VitalsDataModel _vital = default(VitalsDataModel);
            foreach (VitalsDataModel _vitalTemp in _vitaldatabase.GetAll())
            {
                if (String.Equals(_vitalTemp.PatientId, id))
                {
                    _vital = _vitalTemp;
                    break;
                }
            }
            return _vital;
        }

        // GET api/<VitalDataController>/5
        [HttpGet]
        [Route("[action]/{id}")]
        public string CheckVitalAndAlert(string id)
        {
            return _vitaldatabase.CheckVital(id);
        }


        // POST api/<VitalDataController>
        [HttpPost]
        public IActionResult Post([FromBody] VitalsDataModel vital)
        {
            _vitaldatabase.NewVitalAdd(vital);
            return Ok();
        }

        // DELETE api/<VitalDataController>/5
        [HttpDelete("{id}")]
        public VitalsDataModel Delete(string id)
        {
            VitalsDataModel vital = _vitaldatabase.RemoveVital(id);
            return vital;
        }

        //PUT api/<VitalDataController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] VitalsDataModel _vitalDetailchanges)
        {
            _vitalDetailchanges.PatientId = id;
            var result = _vitaldatabase.UpdatePatientVitals(_vitalDetailchanges);
            return Ok(result);

        }
    }
}
