using System.ComponentModel.DataAnnotations;

namespace Alert_To_Care.Models
{
    public class PatientDataModel
    {
        [Key]
        public string PatientId { get; set; }
        public string BedId { get; set; }
        public string PatientName { get; set; }
        public int PatientAge { get; set; }
        public string Email { get; set; }     
        public int ContactNo { get; set; }
        public string Address { get; set; }
        
    }
}
