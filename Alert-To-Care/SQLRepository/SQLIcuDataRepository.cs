using Alert_To_Care.Models;
using Alert_To_Care.Repository;
using System.Collections.Generic;

namespace Alert_To_Care.SQLRepository
{
    public class SqlIcuDataRepository:IIcuDataRepository
    {
        private readonly Database _context;

        public SqlIcuDataRepository(Database context)
        {
            _context = context;
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
            //IcuDataModel _icu = _context.Icu.Find(icu.IcuId);
            if ( icu != null && CheckValidity(icu))
            {
                _context.Icu.Add(icu);
                _context.SaveChanges();
                return icu;

            }
            return null;
        }

        public IEnumerable<IcuDataModel> GetAllIcu()
        {
           return _context.Icu;
        }

        public IcuDataModel GetIcuDetailsById(string icuId)
        {
            IcuDataModel icu = _context.Icu.Find(icuId);
            return icu;
        }

        public IcuDataModel RemoveIcu(string icuId)
        {
            IcuDataModel icu = _context.Icu.Find(icuId);
            if (icu != null)
            {
                _context.Icu.Remove(icu);
                _context.SaveChanges();
                return icu;
            }
            return null;
        }

        public IcuDataModel UpdateIcu(IcuDataModel icuDetailsChanges)
        {
            string id =icuDetailsChanges.IcuId;
            if (_context.Icu.Find(id) != null)
            {
                IcuDataModel icu = _context.Icu.Find(id);
                if (icu != null)
                {
                    icu.Layout = icuDetailsChanges.Layout;
                    icu.TotalNoOfBeds = icuDetailsChanges.TotalNoOfBeds;
                    _context.SaveChanges();
                    return icu;
                }
                return null;
            }
            return null;

        }

        public bool UpdateLayout(string icuId, string layout)
        {
            IcuDataModel icu = _context.Icu.Find(icuId);
            if (icu != null)
            {
                icu.Layout = layout;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
