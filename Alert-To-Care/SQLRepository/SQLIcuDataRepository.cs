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

        public IcuDataModel AddIcu(IcuDataModel icu)
        {
            _context.Icu.Add(icu);
            _context.SaveChanges();
            return icu;
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
            _context.Icu.Update(_icuDetailsChanges);
            _context.SaveChanges();
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
