﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alert_To_Care.Models;
using Alert_To_Care.Repository;

namespace Alert_To_Care.Repository
{
    public class PatientDataRepository:IPatientDataRepository
    {
        private readonly Database _context;

        public PatientDataRepository(Database context)
        {
            _context = context;
        }


        public void NewPatientAdd(PatientDataModel patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        public void DischargePatient(int patientId)
        {
            PatientDataModel patient = _context.Patients.Find(patientId);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                _context.SaveChanges();
            }
        }

        public void AllotBedToPatient(PatientDataModel patient)
        {
            throw new NotImplementedException();
        }

        public PatientDataModel PatientInfoFromPatientId(int patientId)
        {
            throw new NotImplementedException();
        }

        public BedDataModel BedInfoFromPatientId(int patientId)
        {
            throw new NotImplementedException();
        }
    }
}
