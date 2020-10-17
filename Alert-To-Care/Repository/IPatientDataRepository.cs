using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alert_To_Care.Models;

namespace Alert_To_Care.Repository
{
    public interface IPatientDataRepository
    {
        public PatientDataModel NewPatientAdd(PatientDataModel patient);
        public PatientDataModel DischargePatient(string patientId);
        public IEnumerable<PatientDataModel> GetAllPatients();
        public PatientDataModel UpdatePatient(PatientDataModel patient);
        public PatientDataModel GetPatientInfoFromId(string patientId);
        public BedDataModel BedInfoFromPatientId(string patientId);
    }
}
