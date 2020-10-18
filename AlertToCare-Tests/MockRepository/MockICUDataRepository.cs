using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alert_To_Care.Models;
using Alert_To_Care.Repository;

namespace AlertToCare_Tests.MockRepository
{
    class MockICUDataRepository : IIcuDataRepository
    {
        private List<IcuDataModel> _ICUList;

        public MockICUDataRepository()
        {
            _ICUList = new List<IcuDataModel>()
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
            if(icu != null && CheckValidity(icu))
            {
                icu.IcuId = _ICUList.Max(e => e.IcuId + 1);
                _ICUList.Add(icu);
                return icu;
                
            }
            return null;
        }

        public IEnumerable<IcuDataModel> GetAllIcu()
        {
             if(_ICUList != null)
            {
                return _ICUList;
            }
            return null;
        }

        public IcuDataModel GetIcuDetailsById(string _icuId)
        {
            IcuDataModel _icu = _ICUList.FirstOrDefault(e => string.Equals(e.IcuId, _icuId));
            return _icu;
        }

        public IcuDataModel RemoveIcu(string icuId)
        {
            IcuDataModel _icu = _ICUList.FirstOrDefault(e => string.Equals(e.IcuId, icuId));
            if (_icu != null)
            {
                _ICUList.Remove(_icu);
                return _icu;
            }
            return null;
        }

        public IcuDataModel UpdateIcu(IcuDataModel _icuDetailsChanges)
        {
            IcuDataModel _icu = _ICUList.FirstOrDefault(e => string.Equals(e.IcuId, _icuDetailsChanges.IcuId));
            return _icu;   
        }

        public bool UpdateLayout(string icuId, string layout)
        {
            IcuDataModel _icu = _ICUList.FirstOrDefault(e => string.Equals(e.IcuId, icuId));
            if (_icu != null)
            {
                _icu.Layout = layout;
                return true;
            }

            return false;
        }
    }
}
