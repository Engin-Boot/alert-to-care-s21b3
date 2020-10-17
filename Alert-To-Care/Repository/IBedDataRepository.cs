using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alert_To_Care.Models;

namespace Alert_To_Care.Repository
{
    public interface IBedDataRepository
    {
        public IEnumerable<BedDataModel> GetAllBedInfo();
        public BedDataModel AddBed(BedDataModel _bed);
        public BedDataModel RemoveBed(string _bedId);
        public BedDataModel UpdateBed(BedDataModel _bedDetailsChanges);
        public BedDataModel GetBedDetailsById(string _bedId);
        
    }
}
