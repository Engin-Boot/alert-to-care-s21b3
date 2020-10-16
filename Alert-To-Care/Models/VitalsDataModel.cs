using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Alert_To_Care.Models
{
    public class VitalsDataModel
    {
        [Key]
        
        public int PatientId { get; set; }
        public int PatientBedId { get; set; }
        public float Bpm { get; set; }
        public float Spo2 { get; set; }
        public float RespRate { get; set; }
    }
}
