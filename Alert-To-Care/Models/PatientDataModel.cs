using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alert_To_Care.Models
{
    public class PatientDataModel
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientAge { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
    }
}
