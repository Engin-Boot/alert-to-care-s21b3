using Alert_To_Care.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alert_To_Care.Repository
{
    public class IcuDataRepository : IIcuDataRepository
    {
        private List<IcuDataModel> _icuList;

        public IcuDataRepository()
        {
            _icuList = new List<IcuDataModel>()
            {
                new IcuDataModel() {IcuId="1",TotalNoOfBeds=3 , Layout="L" },
                new IcuDataModel() {IcuId="2",TotalNoOfBeds=1 , Layout="I" }
            };

        }
        public IcuDataModel AddIcu(IcuDataModel icu)
        {
            icu.IcuId = _icuList.Max(e => e.IcuId + 1);
            _icuList.Add(icu);
            return icu;
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
            }
            return icu;
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
