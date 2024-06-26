namespace Pet_project_Vitasmart.Models.InputModels
{
    public class VisitDataInput
    {
        public VisitDataInput() { }
        public VisitDataInput(DateOnly dateVisit, string iCDCode, int patientId)
        {
            DateVisit = dateVisit;
            ICDCode = iCDCode;
            PatientId = patientId;
        }
        public DateOnly DateVisit { get; set; } = new();
        public string ICDCode { get; set; } = string.Empty;
        public int PatientId { get; set; }
    }
}
