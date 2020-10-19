using Alert_To_Care.Models;
using Alert_To_Care.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Alert_To_Care.SQLRepository
{
    public class SQLVitalDataRepository:IVitalDataRepository
    {
        private readonly Database _context;

        public SQLVitalDataRepository(Database context)
        {
            _context = context;
        }

        public VitalsDataModel GetAllVital(string _patientId)
        {
            VitalsDataModel vital = _context.Vitals.Find(_patientId);
            if (vital != null)
            {
                return vital;
            }
            return null;
        }
        public string CheckVital(string _patientId)
        {
            VitalsDataModel vital = _context.Vitals.Find(_patientId);
            if (vital == null)
            {
                return null;
            }
            string email = "alertcasestudy@gmail.com";

            string spo2Result = CheckSpo2InRange(vital.Spo2);
            string bpmResult = CheckBpmInRange(vital.Bpm);
            string RespRateResult = CheckRespRateInRange(vital.RespRate);
            string alert = spo2Result + bpmResult + RespRateResult;
            if (alert.Length != 0)
            {
              
                alert = "PatientId:" + _patientId + " --> "+alert;
                SendAlert(email, alert);
            }

            return alert;

        }
        private string CheckSpo2InRange(float spo2)
        {
            string spoMsg = "";
            if (spo2 < 90.0)
            {
                spoMsg += " [ Spo2 is low ] ";
            }
            return spoMsg;
        }
        private string CheckBpmInRange(float bpm)
        {
            string bpmMsg = "";
            if (bpm < 70.0)
            {
                bpmMsg += " [ bpm is low ] ";
            }
            else if (bpm > 150.0)
            {
                bpmMsg += " [ bpm is high ] ";
            }
            return bpmMsg;
        }
        private string CheckRespRateInRange(float rr)
        {
            string RespRatemsg = "";
            if (rr < 30.0)
            {
                RespRatemsg += " [ RespRate is low ] ";
            }
            else if (rr > 95.0)
            {
                RespRatemsg += " [ RespRate is high ] ";
            }
            return RespRatemsg;
        }

        private void SendAlert(string email, string alertmsg)
        {
            MailMessage mailMessage = new MailMessage(email, email);
            mailMessage.Subject = "Alert";
            mailMessage.Body = alertmsg;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = email,
                Password = "#C@se2Study"
            };
            smtpClient.EnableSsl = true;
            smtpClient.Send(mailMessage);
        }

        public VitalsDataModel NewVitalAdd(VitalsDataModel vital)
        {

            PatientDataModel idInPatientTable = _context.Patients.Find(vital.PatientId);
            VitalsDataModel idInVitalTable = _context.Vitals.Find(vital.PatientId);
            if (idInPatientTable != null && idInVitalTable == null)
            {
                _context.Vitals.Add(vital);
                _context.SaveChanges();
                return vital;
            }
            return null;
        }

        public VitalsDataModel RemoveVital(string _patientId)
        {
            VitalsDataModel vital = _context.Vitals.Find(_patientId);
            if (vital != null)
            {
                _context.Vitals.Remove(vital);
                _context.SaveChanges();
                return vital;
            }
            return null;
        }

        public IEnumerable<VitalsDataModel> GetAll()
        {
            IEnumerable<VitalsDataModel> listOfVitals = _context.Vitals;
            if (listOfVitals != null)
            {
                return listOfVitals;
            }
            return null;
        }

        public VitalsDataModel UpdatePatientVitals(VitalsDataModel patientvital)
        {
            string _id = patientvital.PatientId;
            if (_context.Vitals.Find(_id) != null)
            {
                VitalsDataModel vital = _context.Vitals.Find(_id);
                if (vital != null)
                {
                    vital.PatientBedId = patientvital.PatientBedId;
                    vital.RespRate = patientvital.RespRate;
                    vital.Spo2 = patientvital.Spo2;
                    vital.Bpm = patientvital.Bpm;
                    _context.SaveChanges();
                    return vital;
                }
                return null;
            }
            return null;
        }
    }
}
