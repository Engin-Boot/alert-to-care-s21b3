using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alert_To_Care.Models
{
    public class VitalsDataModel
    {
        public string PatientId { get; set; }
        public string PatientBedId { get; set; }
        public float Bpm { get; set; }
        public float Spo2 { get; set; }
        public float RespRate { get; set; }
    }
}
