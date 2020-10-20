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
            if (icu != null)
            {
                return icu;
            }
            return null;
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

        public IcuDataModel UpdateIcu(IcuDataModel _icuDetailsChanges)
        {
            string _id =_icuDetailsChanges.IcuId;
            if (_context.Icu.Find(_id) != null)
            {
                IcuDataModel icu = _context.Icu.Find(_id);
                if (icu != null)
                {
                    icu.Layout = _icuDetailsChanges.Layout;
                    icu.TotalNoOfBeds = _icuDetailsChanges.TotalNoOfBeds;
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
