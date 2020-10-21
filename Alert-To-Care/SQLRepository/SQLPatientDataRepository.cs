using System.Collections.Generic;
using Alert_To_Care.Models;
using Alert_To_Care.Repository;

namespace Alert_To_Care.SQLRepository
{
    public class SqlPatientDataRepository : IPatientDataRepository
    {
        private readonly Database _context;

        public SqlPatientDataRepository(Database context)
        {
            _context = context;
        }

        public PatientDataModel NewPatientAdd(PatientDataModel patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
            return patient;
        }

        public PatientDataModel DischargePatient(string patientId)
        {
            PatientDataModel patient = _context.Patients.Find(patientId);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                _context.SaveChanges();
                return patient;
            }
            return null ;
        }

        public PatientDataModel GetPatientInfoFromId(string patientId)
        {
            PatientDataModel details = _context.Patients.Find(patientId);
            return details;
        }

        public IEnumerable<PatientDataModel> GetAllPatients()
        {
            return _context.Patients;
        }


        public BedDataModel BedInfoFromPatientId(string patientId)
        {
            PatientDataModel details = _context.Patients.Find(patientId);
            if (details != null)
            {
                BedDataModel bed = _context.Beds.Find(details.BedId);
                return bed;
            }
            return null;
        }

        public PatientDataModel UpdatePatient(PatientDataModel patientDetailChanges)
        {

            string id = patientDetailChanges.PatientId;
            if (_context.Patients.Find(id) != null)
            {
                PatientDataModel patient = _context.Patients.Find(id);
                if (patient != null)
                {
                    patient.PatientName = patientDetailChanges.PatientName;
                    patient.PatientAge = patientDetailChanges.PatientAge;
                    patient.Email = patientDetailChanges.Email;
                    patient.BedId = patientDetailChanges.BedId;
                    patient.ContactNo = patientDetailChanges.ContactNo;
                    patient.Address = patientDetailChanges.Address;
                    _context.SaveChanges();
                    return patient;
                }
                return null;
            }
            return null;





            //_context.Patients.Update(patientDetailChanges);
             //   _context.SaveChanges();
              //  return patientDetailChanges;
            
        }

        
    }
}
