using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Pet_project_Vitasmart.Models
{
    public class ICD
    {
        public ICD() { }
        public ICD(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public ICD(string code, string name, string? description)
        {
            Code = code;
            Name = name;
            Description = description;
        }
        [Key]
        public string Code
        {
            get => code;
            set
            {
                if (!string.IsNullOrWhiteSpace(code) && (string.IsNullOrEmpty(value)))
                {
                    return;
                }
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new NullReferenceException("Ошибка заполнения кода");
                }
                code = value;
            }
        }
        public string Name
            {
            get => name;
            set
            {
                if (!string.IsNullOrWhiteSpace(name) && (string.IsNullOrEmpty(value)))
                {
                    return;
                }
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new NullReferenceException("Ошибка заполнения названия болезни");
                }
                name = value;
            }
        }
        public string? Description { get; set; }

        private string code = string.Empty;
        private string name = string.Empty;
    }
}
