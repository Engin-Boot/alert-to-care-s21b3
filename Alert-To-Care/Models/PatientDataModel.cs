﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Alert_To_Care.Models
{
    public class PatientDataModel
    {
        [Key]
        public int PatientId { get; set; }
        public int BedId { get; set; }
        public string PatientName { get; set; }
        public int PatientAge { get; set; }
        public string Email { get; set; }
        public int ContactNo { get; set; }
        public string Address { get; set; }
        
        public VitalsDataModel vitals { get; set; }
    }
}
