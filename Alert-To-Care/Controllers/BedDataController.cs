using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Alert_To_Care.Repository;
using Alert_To_Care.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Alert_To_Care.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BedDataController : ControllerBase
    {
        IBedDataRepository _bedDatabase;

        public BedDataController(IBedDataRepository repo)
        {
            this._bedDatabase = repo;
        }
       

        // GET: api/<BedDataController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<BedDataModel> result = _bedDatabase.GetAllBedInfo();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        // GET api/<BedDataController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var _details = _bedDatabase.GetBedDetailsById(id);
            if (_details != null)
            {
                return Ok(_details);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetBedStatus(string id)
        {
            BedDataModel _bedDetails = _bedDatabase.GetBedDetailsById(id);
            if(_bedDetails != null)
            {
                bool _bedStatus = _bedDetails.BedStatus;
                return Ok( _bedStatus);
            }
            return BadRequest();
        }

        // POST api/<BedDataController>
        [HttpPost]
        public IActionResult Post([FromBody] BedDataModel _bedDetails)
        {
            if(_bedDetails != null)
            {
                var result = _bedDatabase.AddBed(_bedDetails);
                return Ok(result);
            }
            return BadRequest();
        }

        // PUT api/<BedDataController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] BedDataModel _bedDetails)
        {
                _bedDetails.IcuId = id;
                var result = _bedDatabase.UpdateBed(_bedDetails);
                return Ok(result);
        }

        // DELETE api/<BedDataController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var _checkBed = _bedDatabase.GetBedDetailsById(id);
            if(_checkBed != null)
            {
                var result = _bedDatabase.RemoveBed(id);
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
