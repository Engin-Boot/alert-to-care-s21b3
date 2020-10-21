using Alert_To_Care.Models;
using System.Collections.Generic;

namespace Alert_To_Care.Repository
{
    public interface IIcuDataRepository
    {
        public IcuDataModel AddIcu(IcuDataModel icu);
        public IcuDataModel RemoveIcu(string icuId);
        public IcuDataModel UpdateIcu(IcuDataModel icuDetailsChanges);
        public bool UpdateLayout(string icuId, string layout);
        public IEnumerable<IcuDataModel> GetAllIcu();
        public IcuDataModel GetIcuDetailsById(string icuId);
    }
}
