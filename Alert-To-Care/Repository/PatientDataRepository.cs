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
        private List<PatientDataModel> _patientList;

        public PatientDataRepository()
        {
            _patientList = new List<PatientDataModel>()
            {
                new PatientDataModel() { PatientId = "1", BedId = "22", PatientName = "Sneha", PatientAge = 31, ContactNo = 098765487, Address = "xyz street, abc colony", Email = "abc@123" },
                new PatientDataModel() { PatientId = "2", BedId = "42", PatientName = "Priya", PatientAge = 49, ContactNo = 098766475, Address = "xyz street, abc colony", Email = "rfd@654" },
                new PatientDataModel() { PatientId = "3", BedId = "90", PatientName = "Kaush", PatientAge = 56, ContactNo = 876345674, Address = "xyz street, abc colony", Email = "hgf@543" }
            };

         }
        public PatientDataModel NewPatientAdd(PatientDataModel patient)
        {
            patient.PatientId = _patientList.Max(e => e.PatientId + 1);
            _patientList.Add(patient);
            return patient;
            //throw new NotImplementedException();
        }

        public PatientDataModel DischargePatient(string _patientId)
        {
            PatientDataModel patient = _patientList.FirstOrDefault(e => string.Equals(e.PatientId, _patientId));
            if (patient != null)
            {
                _patientList.Remove(patient);
            }
            return patient;
            //throw new NotImplementedException();
        }

        
        public IEnumerable<PatientDataModel> GetAllPatients()
        {
            return _patientList;
        }
        public void AllotBedToPatient(PatientDataModel patient)
        {
            throw new NotImplementedException();
        }

        public BedDataModel BedInfoFromPatientId(string _patientId)
        { 

            throw new NotImplementedException();
        }

    }
}
