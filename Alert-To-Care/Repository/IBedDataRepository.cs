using System.Collections.Generic;
using Alert_To_Care.Models;

namespace Alert_To_Care.Repository
{
    public interface IBedDataRepository
    {
        public IEnumerable<BedDataModel> GetAllBedInfo();
        public BedDataModel AddBed(BedDataModel bed);
        public BedDataModel RemoveBed(string bedId);
        public BedDataModel UpdateBed(BedDataModel bedDetailsChanges);
        public BedDataModel GetBedDetailsById(string bedId);
        
    }
}
