using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alert_To_Care.Models;
using Alert_To_Care.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Alert_To_Care.SQLRepository
{
    public class SQLPatientDataRepository : IPatientDataRepository
    {
        private readonly Database _context;

        public SQLPatientDataRepository(Database context)
        {
            _context = context;
        }

        public PatientDataModel NewPatientAdd(PatientDataModel patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
            return patient;
        }

        public PatientDataModel DischargePatient(string _patientId)
        {
            PatientDataModel patient = _context.Patients.Find(_patientId);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                _context.SaveChanges();
            }
            return patient;
        }

        public void AllotBedToPatient(PatientDataModel patient)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PatientDataModel> GetAllPatients()
        {
            return _context.Patients;
        }


        public BedDataModel BedInfoFromPatientId(string _patientId)
        {
            BedDataModel bed = _context.Beds.Find(_patientId);
            return bed;
        }
    }
}
