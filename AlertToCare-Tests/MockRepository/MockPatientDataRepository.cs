using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alert_To_Care.Models;
using Alert_To_Care.Repository;

namespace AlertToCare_Tests.MockRepository 
{
    class MockPatientDataRepository : IPatientDataRepository
    {
        private List<PatientDataModel> _patientList;
        
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
            if(_patientList != null)
            {
                return _patientList;
            }
            return null;
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
            PatientDataModel _patient = _patientList.FirstOrDefault(e => string.Equals(e.PatientId, patientId));
            return _patient;
            
        }
        public BedDataModel BedInfoFromPatientId(string patientId)
        {
            PatientDataModel _patient = _patientList.FirstOrDefault(e => string.Equals(e.PatientId, patientId));
            if(_patient != null)
            {
                BedDataModel _bed = new BedDataModel()
                {
                    BedId = _patient.BedId,
                    IcuId = "1",
                    BedStatus = true,
                    PatientId = "6"
                    
                };
                return _bed;
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

        public PatientDataModel UpdatePatient(PatientDataModel patient)
        {
            PatientDataModel _patient = _patientList.FirstOrDefault(e => string.Equals(e.PatientId, patient.PatientId));
            return _patient;
        }
    }
}
