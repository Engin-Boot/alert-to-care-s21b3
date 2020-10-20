using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alert_To_Care.Models;
using Alert_To_Care.Repository;
using Microsoft.EntityFrameworkCore;

namespace Alert_To_Care.SQLRepository
{
    public class SQLBedDataRepository : IBedDataRepository
    {
        private readonly Database _context;

        public SQLBedDataRepository(Database context)
        {
            _context = context;
        }
        public BedDataModel AddBed(BedDataModel _bed)
        {
            if(_bed != null)
            {
                _context.Beds.Add(_bed);
                _context.SaveChanges();
                return _bed;
            }
            return null;
        }

        public IEnumerable<BedDataModel> GetAllBedInfo()
        {
            return _context.Beds;
        }

        public BedDataModel GetBedDetailsById(string _bedId)
        {
            BedDataModel _bedDetails = _context.Beds.Find(_bedId);
            if(_bedDetails!= null)
            {
                return _bedDetails;
            }
            return null;
        }

        public BedDataModel RemoveBed(string _bedId)
        {
            BedDataModel _bed = _context.Beds.Find(_bedId);
            if(_bed != null)
            {
                _context.Beds.Remove(_bed);
                _context.SaveChanges();
                return _bed;
            }
            return null;
        }

        public BedDataModel UpdateBed(BedDataModel _bedDetailsChanges)
        {
            string _id = _bedDetailsChanges.BedId;
            if (_context.Beds.Find(_id) != null)
            {
                BedDataModel bed = _context.Beds.Find(_id);
                if (bed != null)
                {
                    bed.BedStatus = _bedDetailsChanges.BedStatus;
                    bed.PatientId = _bedDetailsChanges.PatientId;
                    bed.IcuId = _bedDetailsChanges.IcuId;
                    _context.SaveChanges();
                    return bed;
                }
                return null;
            }
            return null;
        }
    }
}
