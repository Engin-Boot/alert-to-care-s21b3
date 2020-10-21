using System.Collections.Generic;
using System.Linq;
using Alert_To_Care.Models;
using Alert_To_Care.Repository;
using System.Net.Mail;

namespace AlertToCare_Tests.MockRepository
{
    class MockVitalDataRepository:IVitalDataRepository
    {
        private readonly List<VitalsDataModel> _vitalsList;
        //private List<BedDataModel> _bedsList;


        public MockVitalDataRepository()
        {
            _vitalsList = new List<VitalsDataModel>()
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
            /*_bedsList = new List<BedDataModel>()
            {
                new BedDataModel() {
                    BedId = "40",
                    BedStatus = true,
                    PatientId = "1",
                    IcuId = "2"
                }
            };*/

        }
        private bool CheckValidity(VitalsDataModel vital)
        {
            if (vital.PatientId != null && vital.PatientBedId != null)
            {
                return true;
            }
            return false;
        }

        public string CheckVital(string patientId)
        {
            VitalsDataModel vital = _vitalsList.FirstOrDefault(e => string.Equals(e.PatientId, patientId));
            if (vital == null) { return null; }
            string email = "alertcasestudy@gmail.com";

            string spo2Result = CheckSpo2InRange(vital.Spo2);
            string bpmResult = CheckBpmInRange(vital.Bpm);
            string respRateResult = CheckRespRateInRange(vital.RespRate);
            string alert = spo2Result + bpmResult + respRateResult;
            if (alert.Length != 0)
            {
                alert = "PatientId:" + patientId + " --> " + alert;
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

        public IEnumerable<VitalsDataModel> GetAll()
        {
            return _vitalsList;
        }

        public VitalsDataModel GetAllVital(string patientId)
        {
            VitalsDataModel vital = _vitalsList.FirstOrDefault(e => string.Equals(e.PatientId, patientId));
            return vital;
        }

        public VitalsDataModel NewVitalAdd(VitalsDataModel vital)
        {
            if (vital != null && CheckValidity(vital))
            {
                _vitalsList.Add(vital);
                return vital;

            }
            return null;
        }

        public VitalsDataModel RemoveVital(string patientId)
        {
            VitalsDataModel vital = _vitalsList.FirstOrDefault(e => string.Equals(e.PatientId, patientId));
            if (vital != null)
            {
                _vitalsList.Remove(vital);
                return vital;
            }
            return null;
        }

        public VitalsDataModel UpdatePatientVitals(VitalsDataModel patientvital)
        {

            VitalsDataModel vital = _vitalsList.FirstOrDefault(e => string.Equals(e.PatientId, patientvital.PatientId));
            if (vital != null)
            {
                vital.PatientBedId = patientvital.PatientBedId;
                vital.Bpm = patientvital.Bpm;
                vital.Spo2 = patientvital.Spo2;
                vital.RespRate = patientvital.RespRate;
                return vital;
            }
            return null;

        }
    }
}
