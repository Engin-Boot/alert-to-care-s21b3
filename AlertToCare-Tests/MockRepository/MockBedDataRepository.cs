using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alert_To_Care.Models;
using Alert_To_Care.Repository;


namespace AlertToCare_Tests.MockRepository
{
    class MockBedDataRepository : IBedDataRepository
    {
        private List<BedDataModel> _bedList;

        public MockBedDataRepository()
        {
            _bedList = new List<BedDataModel>()
            {
                new BedDataModel() {  BedId="12", IcuId = "1", BedStatus=true, PatientId="22"},
                new BedDataModel() {  BedId="8", IcuId = "2", BedStatus=false}
            };

        }
        public BedDataModel AddBed(BedDataModel _bed)
        {
            if (_bed != null)
            {
                _bed.BedId = _bedList.Max(e => e.IcuId + 1);
                _bedList.Add(_bed);
                return _bed;

            }
            return null;
        }

        public IEnumerable<BedDataModel> GetAllBedInfo()
        {
            if (_bedList != null)
            {
                return _bedList;
            }
            return null;
        }

        public BedDataModel GetBedDetailsById(string _bedId)
        {
            BedDataModel _bed = _bedList.FirstOrDefault(e => string.Equals(e.BedId, _bedId));
            return _bed;
        }

        public BedDataModel RemoveBed(string _bedId)
        {
            BedDataModel _bed = _bedList.FirstOrDefault(e => string.Equals(e.BedId, _bedId));
            if (_bed != null)
            {
                _bedList.Remove(_bed);
                return _bed;
            }
            return null;
        }

        public BedDataModel UpdateBed(BedDataModel _bedDetailsChanges)
        {
            BedDataModel _bed = _bedList.FirstOrDefault(e => string.Equals(e.BedId, _bedDetailsChanges.BedId));
            return _bed;
        }
    }
}
