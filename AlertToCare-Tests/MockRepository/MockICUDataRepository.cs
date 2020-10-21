using System.Collections.Generic;
using System.Linq;
using Alert_To_Care.Models;
using Alert_To_Care.Repository;

namespace AlertToCare_Tests.MockRepository
{
    class MockIcuDataRepository : IIcuDataRepository
    {
        private readonly List<IcuDataModel> _icuList;

        public MockIcuDataRepository()
        {
            _icuList = new List<IcuDataModel>()
            {
                new IcuDataModel() { IcuId = "1", Layout = "sq", TotalNoOfBeds = 12},
                new IcuDataModel() { IcuId = "2", Layout = "L", TotalNoOfBeds = 6},
            };

        }
        private bool CheckValidity(IcuDataModel icu)
        {
            if (icu.Layout != null && icu.TotalNoOfBeds > 0)
            {
                return true;
            }
            return false;
        }
        public IcuDataModel AddIcu(IcuDataModel icu)
        {
           // IcuDataModel _icu = _ICUList.FirstOrDefault(e => string.Equals(e.IcuId, icu.IcuId));
            if (icu != null && CheckValidity(icu))
            {
                icu.IcuId = _icuList.Max(e => e.IcuId + 1);
                _icuList.Add(icu);
                return icu;
                
            }
            return null;
        }

        public IEnumerable<IcuDataModel> GetAllIcu()
        {
            return _icuList;
        }

        public IcuDataModel GetIcuDetailsById(string icuId)
        {
            IcuDataModel icu = _icuList.FirstOrDefault(e => string.Equals(e.IcuId, icuId));
            return icu;
        }

        public IcuDataModel RemoveIcu(string icuId)
        {
            IcuDataModel icu = _icuList.FirstOrDefault(e => string.Equals(e.IcuId, icuId));
            if (icu != null)
            {
                _icuList.Remove(icu);
                return icu;
            }
            return null;
        }

        public IcuDataModel UpdateIcu(IcuDataModel icuDetailsChanges)
        {
            IcuDataModel icu = _icuList.FirstOrDefault(e => string.Equals(e.IcuId, icuDetailsChanges.IcuId));
            if (icu != null)
            {
                icu.TotalNoOfBeds = icuDetailsChanges.TotalNoOfBeds;
                icu.Layout = icuDetailsChanges.Layout;
                return icu;
            }
            return null;
        }

        public bool UpdateLayout(string icuId, string layout)
        {
            IcuDataModel icu = _icuList.FirstOrDefault(e => string.Equals(e.IcuId, icuId));
            if (icu != null)
            {
                icu.Layout = layout;
                return true;
            }

            return false;
        }
    }
}
