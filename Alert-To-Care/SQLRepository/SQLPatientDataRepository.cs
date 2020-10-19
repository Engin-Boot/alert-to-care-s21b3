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
            PatientDataModel _details = _context.Patients.Find(_patientId);
            if (_details != null)
            {
                BedDataModel bed = _context.Beds.Find(_details.BedId);
                return bed;
            }
            return null;
        }

        public PatientDataModel UpdatePatient(PatientDataModel patientDetailChanges)
        {

            string _id = patientDetailChanges.PatientId;
            if (_context.Patients.Find(_id) != null)
            {
                PatientDataModel patient = _context.Patients.Find(_id);
                if (patient != null)
                {
                    patient.PatientName = patientDetailChanges.PatientName;
                    patient.PatientAge = patientDetailChanges.PatientAge;
                    patient.Email = patientDetailChanges.Email;
                    patient.BedId = patientDetailChanges.BedId;
                    patient.ContactNo = patientDetailChanges.ContactNo;
                    patient.Address = patientDetailChanges.Address;
                    _context.SaveChanges();
                    return patient;
                }
                return null;
            }
            return null;





            _context.Patients.Update(patientDetailChanges);
                _context.SaveChanges();
                return patientDetailChanges;
            
        }

        
    }
}
