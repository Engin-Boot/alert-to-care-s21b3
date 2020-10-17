using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Alert_To_Care.Models
{
    public class IcuDataModel
    {
        [Key]
        public string IcuId { get; set; }
        public int TotalNoOfBeds { get; set; }
        public string Layout { get; set; }
       

    }
}
