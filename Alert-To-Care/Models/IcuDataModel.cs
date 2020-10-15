using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alert_To_Care.Models
{
    public class IcuDataModel
    {
        public string IcuId { get; set; }
        public int TotalNoOfBeds { get; set; }
        public List<BedDataModel> IcuBedList { get; set; }
        public int NumberOfRows { get; set; }
        public int NumberOfColumns { get; set; }

    }
}
