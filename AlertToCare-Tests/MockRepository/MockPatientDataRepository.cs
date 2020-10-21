using System.Collections.Generic;
using System.Linq;
using Alert_To_Care.Models;
using Alert_To_Care.Repository;

namespace AlertToCare_Tests.MockRepository
{
    class MockPatientDataRepository : IPatientDataRepository
    {
        private readonly List<PatientDataModel> _patientList;
        
        public MockPatientDataRepository()
        {
            _patientList = new List<PatientDataModel>()
            {
              new PatientDataModel() { PatientId = "1", BedId = "22", PatientName = "Sneha", PatientAge = 31, ContactNo = 098765487, Address = "xyz street, abc colony", Email = "abc@123" },
              new PatientDataModel() { PatientId = "2", BedId = "42", PatientName = "Priya", PatientAge = 49, ContactNo = 098766475, Address = "xyz street, abc colony", Email = "rfd@654" },
              new PatientDataModel() { PatientId = "3", BedId = "90", PatientName = "Kaush", PatientAge = 56, ContactNo = 876345674, Address = "xyz street, abc colony", Email = "hgf@543" }
            };
        }
        public IEnumerable<PatientDataModel> GetAllPatients()
        {
            return _patientList;
        }

        public PatientDataModel NewPatientAdd(PatientDataModel patient)
        {
            if (patient != null)
            {
                patient.PatientId = _patientList.Max(e => e.PatientId + 1);
                _patientList.Add(patient);
                return patient;
            }
            return null;
        }

        public PatientDataModel GetPatientInfoFromId(string patientId)
        {
            PatientDataModel patient = _patientList.FirstOrDefault(e => string.Equals(e.PatientId, patientId));
            return patient;
            
        }
        public BedDataModel BedInfoFromPatientId(string patientId)
        {
            PatientDataModel patient = _patientList.FirstOrDefault(e => string.Equals(e.PatientId, patientId));
            if(patient != null)
            {
                BedDataModel bed = new BedDataModel()
                {
                    BedId = patient.BedId,
                    IcuId = "1",
                    BedStatus = true,
                    PatientId = "6"
                    
                };
                return bed;
            }
            return null;
        }

        public PatientDataModel DischargePatient(string patientId)
        {
            PatientDataModel patient = _patientList.FirstOrDefault(e => string.Equals(e.PatientId, patientId));
            if (patient != null)
            {
                _patientList.Remove(patient);
            }
            return patient;
        }

        public PatientDataModel UpdatePatient(PatientDataModel patientDetailChanges)
        {
            PatientDataModel patient = _patientList.FirstOrDefault(e => string.Equals(e.PatientId, patientDetailChanges.PatientId));
            if (patient != null)
            {
                patient.PatientName = patientDetailChanges.PatientName;
                patient.PatientAge = patientDetailChanges.PatientAge;
                patient.Email = patientDetailChanges.Email;
                patient.BedId = patientDetailChanges.BedId;
                patient.ContactNo = patientDetailChanges.ContactNo;
                patient.Address = patientDetailChanges.Address;
                return patient;
            }
            return null;
        }
    }
}
