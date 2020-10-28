using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Alert_To_Care.Repository;
using Alert_To_Care.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Alert_To_Care.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IcuDataController : ControllerBase
    {

        private readonly IIcuDataRepository _icudatabase;

        public IcuDataController(IIcuDataRepository repo)
        {
            _icudatabase = repo;
        }

        // GET: api/<IcuDataController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<IcuDataModel> result = _icudatabase.GetAllIcu();
            
            return Ok(result);
        }

        // GET api/<IcuDataController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            IcuDataModel icu = _icudatabase.GetIcuDetailsById(id);
            if(icu != null)
            {
                return Ok(icu);
            }
            return BadRequest("Icu not found!");
        }

        [HttpGet]
        [Route("[action]/{id}")]        
        public IActionResult GetLayout(string id)
        {
            IcuDataModel icu = _icudatabase.GetIcuDetailsById(id);
            if(icu != null)
            {
                string layout = icu.Layout;
                return Ok(layout);

            }
            return BadRequest("Icu does not exist!");
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetBeds(string id)
        {
            IcuDataModel icu = _icudatabase.GetIcuDetailsById(id);
            if (icu != null)
            {
                int bedNo = icu.TotalNoOfBeds;
                return Ok(bedNo);
            }
            return BadRequest("Icu does not exist!");
        }
        

        // POST api/<IcuDataController>
        [HttpPost]
        public IActionResult Post([FromBody] IcuDataModel icu)
        {
            var result = _icudatabase.AddIcu(icu);
            if(result != null)
            {
                return Ok(result);
            }
                
            return BadRequest("Icu already exists!");
        }

        // DELETE api/<IcuDataController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            IcuDataModel result =_icudatabase.RemoveIcu(id);
            if(result != null)
            {
                return Ok(result);
            }
            return BadRequest("Icu does not exist!");
        }



        // PUT api/<IcuDataController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] IcuDataModel icuDetailsChanges)
        {
            if (icuDetailsChanges.IcuId == id)
            {
                var result = _icudatabase.UpdateIcu(icuDetailsChanges);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            return BadRequest("Icu does not exist");
            
        }

        
    }
}
