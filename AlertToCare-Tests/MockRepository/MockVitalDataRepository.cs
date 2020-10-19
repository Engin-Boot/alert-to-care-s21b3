using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alert_To_Care.Models;
using Alert_To_Care.Repository;
using System.Net.Mail;

namespace AlertToCare_Tests.MockRepository
{
    class MockVitalDataRepository:IVitalDataRepository
    {
        private List<VitalsDataModel> _VitalsList;
        private List<BedDataModel> _BedsList;


        public MockVitalDataRepository()
        {
            _VitalsList = new List<VitalsDataModel>()
            {
                new VitalsDataModel() { PatientId = "1",
                    PatientBedId = "40",
                    Bpm = 60f,
                    Spo2 = 55f,
                    RespRate = 70f},
                new VitalsDataModel() { PatientId = "2",
                    PatientBedId = "41",
                    Bpm = 60f,
                    Spo2 = 100f,
                    RespRate = 70f}
            };
            _BedsList = new List<BedDataModel>()
            {
                new BedDataModel() {
                    BedId = "40",
                    BedStatus = true,
                    PatientId = "1",
                    IcuId = "2"
                }
            };

        }
        private bool CheckValidity(VitalsDataModel vital)
        {
            if (vital.PatientId != null && vital.PatientBedId != null)
            {
                return true;
            }
            return false;
        }

        public string CheckVital(string _patientId)
        {
            VitalsDataModel vital = _VitalsList.FirstOrDefault(e => string.Equals(e.PatientId, _patientId));
            if (vital == null) { return null; }
            string email = "alertcasestudy@gmail.com";

            string spo2Result = CheckSpo2InRange(vital.Spo2);
            string bpmResult = CheckBpmInRange(vital.Bpm);
            string RespRateResult = CheckRespRateInRange(vital.RespRate);
            string alert = spo2Result + bpmResult + RespRateResult;
            if (alert.Length != 0)
            {
                alert = "PatientId:" + _patientId + " --> " + alert;
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

        public IEnumerable<VitalsDataModel> GetAll()
        {
            if (_VitalsList != null)
            {
                return _VitalsList;
            }
            return null;
        }

        public VitalsDataModel GetAllVital(string _patientId)
        {
            VitalsDataModel _vital = _VitalsList.FirstOrDefault(e => string.Equals(e.PatientId, _patientId));
            if (_vital != null)
            {
                return _vital;
            }
            return null;
        }

        public VitalsDataModel NewVitalAdd(VitalsDataModel vital)
        {
            if (vital != null && CheckValidity(vital))
            {
                _VitalsList.Add(vital);
                return vital;

            }
            return null;
        }

        public VitalsDataModel RemoveVital(string patientId)
        {
            VitalsDataModel _vital = _VitalsList.FirstOrDefault(e => string.Equals(e.PatientId, patientId));
            if (_vital != null)
            {
                _VitalsList.Remove(_vital);
                return _vital;
            }
            return null;
        }

        public VitalsDataModel UpdatePatientVitals(VitalsDataModel patientvital)
        {

            VitalsDataModel _vital = _VitalsList.FirstOrDefault(e => string.Equals(e.PatientId, patientvital.PatientId));
            if (_vital != null)
            {
                _vital.PatientBedId = patientvital.PatientBedId;
                _vital.Bpm = patientvital.Bpm;
                _vital.Spo2 = patientvital.Spo2;
                _vital.RespRate = patientvital.RespRate;
                return _vital;
            }
            return null;

        }
    }
}
