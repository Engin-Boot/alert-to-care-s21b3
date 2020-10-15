using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alert_To_Care.Models;
using Alert_To_Care.Repository;

namespace Alert_To_Care.Repository
{
    public class PatientDataRepository:IPatientDataRepository
    {
        private readonly Database _context;

        public PatientDataRepository(Database context)
        {
            _context = context;
        }


        public void NewPatientAdd(PatientDataModel patient)
        {
            throw new NotImplementedException();
        }

        public void DischargePatient(int patientId)
        {
            throw new NotImplementedException();
        }

        public void AllotBedToPatient(PatientDataModel patient)
        {
            throw new NotImplementedException();
        }

        public PatientDataModel PatientInfoFromPatientId(int patientId)
        {
            throw new NotImplementedException();
        }

        public BedDataModel BedInfoFromPatientId(int patientId)
        {
            throw new NotImplementedException();
        }
    }
}
