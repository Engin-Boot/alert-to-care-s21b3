using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Alert_To_Care.Models;
using Alert_To_Care.Repository;

namespace Alert_To_Care.SQLRepository
{
    [ExcludeFromCodeCoverage]
    public class SqlBedDataRepository : IBedDataRepository
    {
        private readonly Database _context;

        public SqlBedDataRepository(Database context)
        {
            _context = context;
        }
        public BedDataModel AddBed(BedDataModel bed)
        {
            if(bed != null)
            {
                _context.Beds.Add(bed);
                _context.SaveChanges();
                return bed;
            }
            return null;
        }

        public IEnumerable<BedDataModel> GetAllBedInfo()
        {
            return _context.Beds;
        }

        public BedDataModel GetBedDetailsById(string bedId)
        {
            BedDataModel bedDetails = _context.Beds.Find(bedId);
            
            return bedDetails;
        }

        public BedDataModel RemoveBed(string bedId)
        {
            BedDataModel bed = _context.Beds.Find(bedId);
            if(bed != null)
            {
                _context.Beds.Remove(bed);
                _context.SaveChanges();
            }
            return bed;
        }

        public BedDataModel UpdateBed(BedDataModel bedDetailsChanges)
        {
            string id = bedDetailsChanges.BedId;
            if (_context.Beds.Find(id) != null)
            {
                BedDataModel bed = _context.Beds.Find(id);
                if (bed != null)
                {
                    bed.BedStatus = bedDetailsChanges.BedStatus;
                    bed.PatientId = bedDetailsChanges.PatientId;
                    bed.IcuId = bedDetailsChanges.IcuId;
                    _context.SaveChanges();
                }
                return bed;
            }
            return null;
        }
    }
}
