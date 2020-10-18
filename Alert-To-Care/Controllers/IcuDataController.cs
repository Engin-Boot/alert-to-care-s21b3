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

        IIcuDataRepository _icudatabase;

        public IcuDataController(IIcuDataRepository repo)
        {
            this._icudatabase = repo;
        }

        // GET: api/<IcuDataController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<IcuDataModel> result = _icudatabase.GetAllIcu();
            if ( result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        // GET api/<IcuDataController>/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            IcuDataModel _icu = _icudatabase.GetIcuDetailsById(id);
            if(_icu != null)
            {
                return Ok(_icu);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("[action]/{id}")]        
        public IActionResult GetLayout(string id)
        {
            IcuDataModel _icu = _icudatabase.GetIcuDetailsById(id);
            if(_icu != null)
            {
                string layout = _icu.Layout;
                return Ok(layout);

            }
            return BadRequest();
            

        }
        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetBeds(string id)
        {
            IcuDataModel _icu = _icudatabase.GetIcuDetailsById(id);
            if (_icu != null)
            {
                int bedNo = _icu.TotalNoOfBeds;
                return Ok(bedNo);
            }
            return BadRequest();
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
                
            return BadRequest();
        }

        // DELETE api/<IcuDataController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            IcuDataModel _icu=_icudatabase.RemoveIcu(id);
            if(_icu != null)
            {
                return Ok(_icu);
            }
            return BadRequest();
        }



        // PUT api/<IcuDataController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] IcuDataModel _icuDetailsChanges)
        { 
           _icuDetailsChanges.IcuId = id;
           var result = _icudatabase.UpdateIcu(_icuDetailsChanges);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        
    }
}
