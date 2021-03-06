﻿using System.ComponentModel.DataAnnotations;

namespace Alert_To_Care.Models
{
    public class VitalsDataModel
    {
        [Key]        
        public string PatientId { get; set; }
        public string PatientBedId { get; set; }
        public float Bpm { get; set; }
        public float Spo2 { get; set; }
        public float RespRate { get; set; }
    }
}
