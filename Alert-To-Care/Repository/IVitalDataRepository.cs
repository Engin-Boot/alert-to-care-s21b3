using System.Collections.Generic;
using Alert_To_Care.Models;

namespace Alert_To_Care.Repository
{
    public interface IVitalDataRepository
    {
        public string CheckVital(string patientId);
        // public void SendAlert(string email, string alertmsg);
        public VitalsDataModel GetAllVital(string patientId);
        public VitalsDataModel NewVitalAdd(VitalsDataModel vital);
        public VitalsDataModel RemoveVital(string patientId);
        public IEnumerable<VitalsDataModel> GetAll();
        public VitalsDataModel UpdatePatientVitals(VitalsDataModel patientvital);

    }
}
