using System.ComponentModel.DataAnnotations;

namespace AlertToCare_AutomatedTests.Models
{
    public class IcuDataModel
    {
        [Key]
        public string IcuId { get; set; }
        public int TotalNoOfBeds { get; set; }
        public string Layout { get; set; }
       

    }
}
