using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alert_To_Care.Models;
using Alert_To_Care.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alert_To_Care.SQLRepository
{
    public class SQLPatientDataRepository : IPatientDataRepository
    {
        private readonly Database _context;

        public SQLPatientDataRepository(Database context)
        {
            _context = context;
        }

        public void NewPatientAdd(PatientDataModel patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
           // return patient;
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

        public PatientDataModel PatientInfoFromPatientId(string _patientId)
        {
            var _patient = new PatientDataModel();
            foreach (PatientDataModel _patientTemp in _context.Patients)
            {
                if (string.Equals(_patientTemp.PatientId, _patientId))
                {
                    _patient = _patientTemp;

                }
            }
            return _patient;
            
        }

        public BedDataModel BedInfoFromPatientId(string patientId)
        {
            BedDataModel _bedInfo = _context.Beds.FirstOrDefault(m => String.Equals(m.PatientId,patientId));
            return _bedInfo;
           
        }
    }
}
