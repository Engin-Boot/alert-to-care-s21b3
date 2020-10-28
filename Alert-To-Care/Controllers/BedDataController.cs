using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Alert_To_Care.Repository;
using Alert_To_Care.Models;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Alert_To_Care.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BedDataController : ControllerBase
    {
        private readonly IBedDataRepository _bedDatabase;

        public BedDataController(IBedDataRepository repo)
        {
            _bedDatabase = repo;
        }
       

        // GET: api/<BedDataController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<BedDataModel> result = _bedDatabase.GetAllBedInfo();
            return Ok(result);
        }

        // GET api/<BedDataController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var details = _bedDatabase.GetBedDetailsById(id);
            if (details != null)
            {
                return Ok(details);
            }
            return BadRequest("Bed not found!");
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetBedStatus(string id)
        {
            BedDataModel bedDetails = _bedDatabase.GetBedDetailsById(id);
            if(bedDetails != null)
            {
                bool bedStatus = bedDetails.BedStatus;
                return Ok( bedStatus);
            }
            return BadRequest("Bed not found!");
        }

        [HttpGet]
        [Route("[action]/{icuId}")]
        public IActionResult GetBedsByIcuId(string icuId)
        {
            IEnumerable<BedDataModel> bedDetails = _bedDatabase.GetAllBedInfo();

            IEnumerable<BedDataModel> bedsByIcuId = bedDetails.Where(bed => bed.IcuId.Equals(icuId));

            return Ok(bedsByIcuId);
        }

        // POST api/<BedDataController>
        [HttpPost]
        public IActionResult Post([FromBody] BedDataModel bedDetails)
        {
            if(bedDetails != null)
            {
                var result = _bedDatabase.AddBed(bedDetails);
                return Ok(result);
            }
            return BadRequest("Provide all details to add bed!");
        }

        // PUT api/<BedDataController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] BedDataModel bedDetails)
        {
            if (bedDetails.BedId == id)
            {
                var result = _bedDatabase.UpdateBed(bedDetails);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            return BadRequest("Update operation failed. Bed does not exist!");
        }

        // DELETE api/<BedDataController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var result = _bedDatabase.RemoveBed(id);
            if(result != null)
            {
                return Ok(result);
            }   
            return BadRequest("Delete operation failed. Bed does not exist!");
        }
    }
}
