using Alert_To_Care.Models;
using Alert_To_Care.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alert_To_Care.SQLRepository
{
    public class SQLIcuDataRepository:IIcuDataRepository
    {
        private readonly Database _context;

        public SQLIcuDataRepository(Database context)
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
            if (icu != null && CheckValidity(icu))
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
            }
            return icu;
        }

        public IcuDataModel UpdateIcu(IcuDataModel _icuDetailsChanges)
        {
            IcuDataModel icu = _context.Icu.Find(_icuDetailsChanges.IcuId);
            if (icu != null)
            {
                _context.Icu.Update(_icuDetailsChanges);
                _context.SaveChanges();
                return _icuDetailsChanges;
            }
            return _icuDetailsChanges;
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
