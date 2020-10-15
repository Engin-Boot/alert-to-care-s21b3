using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Alert_To_Care.Models
{
    public class BedDataModel
    {
        [Key]
        public string BedId { get; set; }
        public string BedStatus { get; set; }
        public int PatientId { get; set; }
        public string IcuId { get; set; }
        public int BedRow { get; set; }
        public int BedColumn { get; set; }
    }
}
