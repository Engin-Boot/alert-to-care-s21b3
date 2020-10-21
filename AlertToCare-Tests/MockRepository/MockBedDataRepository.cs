using System.Collections.Generic;
using System.Linq;
using Alert_To_Care.Models;
using Alert_To_Care.Repository;


namespace AlertToCare_Tests.MockRepository
{
    class MockBedDataRepository : IBedDataRepository
    {
        private readonly List<BedDataModel> _bedList;

        public MockBedDataRepository()
        {
            _bedList = new List<BedDataModel>()
            {
                new BedDataModel() {  BedId="12", IcuId = "1", BedStatus=true, PatientId="22"},
                new BedDataModel() {  BedId="8", IcuId = "2", BedStatus=false}
            };

        }
        public BedDataModel AddBed(BedDataModel bed)
        {
            if (bed != null)
            {
                bed.BedId = _bedList.Max(e => e.IcuId + 1);
                _bedList.Add(bed);
                return bed;

            }
            return null;
        }

        public IEnumerable<BedDataModel> GetAllBedInfo()
        {
            return _bedList;
        }

        public BedDataModel GetBedDetailsById(string bedId)
        {
            BedDataModel bed = _bedList.FirstOrDefault(e => string.Equals(e.BedId, bedId));
            return bed;
        }

        public BedDataModel RemoveBed(string bedId)
        {
            BedDataModel bed = _bedList.FirstOrDefault(e => string.Equals(e.BedId, bedId));
            if (bed != null)
            {
                _bedList.Remove(bed);
                return bed;
            }
            return null;
        }

        public BedDataModel UpdateBed(BedDataModel bedDetailsChanges)
        {
            BedDataModel bed = _bedList.FirstOrDefault(e => string.Equals(e.BedId, bedDetailsChanges.BedId));
            if (bed != null)
            {
                bed.BedStatus = bedDetailsChanges.BedStatus;
                bed.PatientId = bedDetailsChanges.PatientId;
                bed.IcuId = bedDetailsChanges.IcuId;
                return bed;
            }
            return null;
        }
    }
}
