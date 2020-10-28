using Alert_To_Care.Models;
using Alert_To_Care.Repository;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Mail;

namespace Alert_To_Care.SQLRepository
{
    [ExcludeFromCodeCoverage]
    public class SqlVitalDataRepository:IVitalDataRepository
    {
        private readonly Database _context;

        public SqlVitalDataRepository(Database context)
        {
            _context = context;
        }

        public VitalsDataModel GetAllVital(string patientId)
        {
            VitalsDataModel vital = _context.Vitals.Find(patientId);
            return vital;
        }
        public string CheckVital(string patientId)
        {
            VitalsDataModel vital = _context.Vitals.Find(patientId);
            if (vital == null)
            {
                return null;
            }
            string email = "alertcasestudy@gmail.com";

            string spo2Result = CheckSpo2InRange(vital.Spo2);
            string bpmResult = CheckBpmInRange(vital.Bpm);
            string respRateResult = CheckRespRateInRange(vital.RespRate);
            string alert = spo2Result + bpmResult + respRateResult;
            if (alert.Length != 0)
            {
              
                alert = "PatientId:" + patientId + " --> "+alert;
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
            string respRatemsg = "";
            if (rr < 30.0)
            {
                respRatemsg += " [ RespRate is low ] ";
            }
            else if (rr > 95.0)
            {
                respRatemsg += " [ RespRate is high ] ";
            }
            return respRatemsg;
        }

        private void SendAlert(string email, string alertmsg)
        {
            MailMessage mailMessage = new MailMessage(email, email)
            {
                Subject = "Alert",
                Body = alertmsg
            };

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new System.Net.NetworkCredential()
                {
                    UserName = email,
                    Password = "#C@se2Study"
                },
                EnableSsl = true
            };
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

        public VitalsDataModel RemoveVital(string patientId)
        {
            VitalsDataModel vital = _context.Vitals.Find(patientId);
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
            
            return listOfVitals;
        }

        public VitalsDataModel UpdatePatientVitals(VitalsDataModel patientvital)
        {
            string id = patientvital.PatientId;
            if (_context.Vitals.Find(id) == null)
            {
                return null;
            }
            VitalsDataModel vital = _context.Vitals.Find(id);
            
            vital.PatientBedId = patientvital.PatientBedId;
            vital.RespRate = patientvital.RespRate;
            vital.Spo2 = patientvital.Spo2;
            vital.Bpm = patientvital.Bpm;
            _context.SaveChanges();
            
            return vital;   
        }
    }
}
