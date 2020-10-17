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
        public IEnumerable<IcuDataModel> Get()
        {
            return _icudatabase.GetAllIcu();
        }

        // GET api/<IcuDataController>/5
        [HttpGet("{id}")]
        public IcuDataModel Get(string id)
        {
            IcuDataModel _icu = _icudatabase.GetIcuDetailsById(id);
            return _icu;
        }

        [HttpGet]
        [Route("[action]/{id}")]        
        public string GetLayout(string id)
        {
            IcuDataModel _icu = _icudatabase.GetIcuDetailsById(id);
            string layout = _icu.Layout;
            return layout;

        }
        [HttpGet]
        [Route("[action]/{id}")]
        public int GetBeds(string id)
        {
            IcuDataModel _icu = _icudatabase.GetIcuDetailsById(id);
            int bedNo = _icu.TotalNoOfBeds;
            return bedNo;

        }
        

        // POST api/<IcuDataController>
        [HttpPost]
        public IActionResult Post([FromBody] IcuDataModel icu)
        {
             _icudatabase.AddIcu(icu);
              return Ok();
            
        }

        // DELETE api/<IcuDataController>/5
        [HttpDelete("{id}")]
        public IcuDataModel Delete(string id)
        {
            IcuDataModel _icu=_icudatabase.RemoveIcu(id);
            return _icu;
        }



        // PUT api/<IcuDataController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        
    }
}
