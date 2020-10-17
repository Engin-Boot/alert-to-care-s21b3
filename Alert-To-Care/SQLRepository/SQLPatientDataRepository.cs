using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alert_To_Care.Models;
using Alert_To_Care.Repository;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        public PatientDataModel GetPatientInfoFromId(string patientId)
        {
            PatientDataModel _details = _context.Patients.Find(patientId);
            return _details;
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

        public PatientDataModel UpdatePatient(PatientDataModel patientDetailChanges)
        {
            var _patient = _context.Patients.Attach(patientDetailChanges);
            _patient.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return patientDetailChanges;
        }

        
    }
}
