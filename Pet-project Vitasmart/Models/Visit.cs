using System.ComponentModel.DataAnnotations;

namespace Pet_project_Vitasmart.Models
{
    public class Visit
    {
        public Visit() { }
        public Visit(DateOnly dateVisit, string iCDCode, ICD diagnosis, int patientId, Patient patientVisit)
        {
            DateVisit = dateVisit;
            ICDCode = iCDCode;
            Diagnosis = diagnosis;
            PatientId = patientId;
            PatientVisit = patientVisit;
        }

        [Key]
        public int Id { get; set; }
        public DateOnly DateVisit { get; set; } = new();
        public string ICDCode { get; set; } = string.Empty;
        public ICD Diagnosis { get; set; } = new();
        public int PatientId { get; set; }
        public Patient PatientVisit { get; set; } = new();
    }
}
