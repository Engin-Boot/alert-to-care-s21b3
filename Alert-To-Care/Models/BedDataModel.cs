using System.ComponentModel.DataAnnotations;

namespace Alert_To_Care.Models
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
