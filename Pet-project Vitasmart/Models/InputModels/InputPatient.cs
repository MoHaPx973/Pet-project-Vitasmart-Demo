using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace Pet_project_Vitasmart.Models.InputModels
{
    public class InputPatient
    {
        public string Surname { get; set; }=string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Patronymic { get; set; } = string.Empty;
        public DateOnly Birthdate { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;

    }
}
