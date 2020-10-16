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
        public PatientDataModel DischargePatient(int patientId);
        public void AllotBedToPatient(PatientDataModel patient);
        public PatientDataModel PatientInfoFromPatientId(int patientId);
        public IEnumerable<PatientDataModel> GetAllPatients();
        public BedDataModel BedInfoFromPatientId(int patientId);
    }
}
