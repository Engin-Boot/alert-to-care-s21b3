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
            _context.Beds.Add(_bed);
            _context.SaveChanges();
            return _bed;
        }

        public IEnumerable<BedDataModel> GetAllBedInfo()
        {
            return _context.Beds;
        }

        public BedDataModel GetBedDetailsById(string _bedId)
        {
            BedDataModel _bedDetails = _context.Beds.Find(_bedId);
            return _bedDetails;
        }

        public BedDataModel RemoveBed(string _bedId)
        {
            BedDataModel _bed = _context.Beds.Find(_bedId);
            if(_bed != null)
            {
                _context.Beds.Remove(_bed);
                _context.SaveChanges();
            }
            return _bed;
        }

        public BedDataModel UpdateBed(BedDataModel _bedDetailsChanges)
        {
            _context.Beds.Update(_bedDetailsChanges);
            _context.SaveChanges();
            return _bedDetailsChanges;
        }
    }
}
