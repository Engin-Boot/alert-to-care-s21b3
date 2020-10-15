using System;
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
        public string PatientAge { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
    }
}
