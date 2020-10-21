using System.ComponentModel.DataAnnotations;

namespace AlertToCare_AutomatedTests.Models
{
    public class BedDataModel
    {
        [Key]
        public string BedId { get; set; }
        public bool BedStatus { get; set; }
        public string PatientId { get; set; }
        public string IcuId { get; set; }
       
    }
}
