using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alert_To_Care.Models;

namespace Alert_To_Care.Repository
{
    public interface IPatientDataRepository
    {
        public void NewPatientAdd(PatientDataModel patient);
        public PatientDataModel DischargePatient(string patientId);
        public void AllotBedToPatient(PatientDataModel patient);
        public PatientDataModel PatientInfoFromPatientId(string patientId);
        public IEnumerable<PatientDataModel> GetAllPatients();
        public BedDataModel BedInfoFromPatientId(string patientId);
    }
}
