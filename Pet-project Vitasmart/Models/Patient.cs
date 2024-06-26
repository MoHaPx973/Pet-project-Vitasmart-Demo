using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Pet_project_Vitasmart.Models
{
    public class Patient
    {
        public Patient() { }
        public Patient(string surname, string name, string patronymic, DateOnly birthdate, string phoneNumber)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Birthdate = birthdate;
            PhoneNumber = phoneNumber;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [NotNull]
        public string Surname
        {
            get => surname;
            set
            {
                if (!string.IsNullOrWhiteSpace(surname) && (string.IsNullOrEmpty(value)))
                {
                    return;
                }
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new NullReferenceException("Ошибка заполнения фамилии");
                }
                surname = value;
            }
        }
        [Required]
        [NotNull]
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
                    throw new NullReferenceException("Ошибка заполнения имени");
                }
                name = value;
            }
        }
        [Required]
        [NotNull]
        public string Patronymic
        {
            get => patronymic;
            set
            {
                if (!string.IsNullOrWhiteSpace(patronymic) && (string.IsNullOrEmpty(value)))
                {
                    return;
                }
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new NullReferenceException("Ошибка заполнения отчества");
                }
                patronymic = value;
            }
        }
        [Required]
        [NotNull]
        public DateOnly Birthdate { get; set; }
        [NotNull]
        [Required]
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                if (!string.IsNullOrWhiteSpace(phoneNumber) && (string.IsNullOrEmpty(value)))
                {
                    return;
                }
                if ((string.IsNullOrWhiteSpace(value))||(value.Length!=11))
                {
                    throw new NullReferenceException("Ошибка заполнения номера телефона");
                }
                phoneNumber = value;
            }
        }

        private string surname = string.Empty;
        private string name = string.Empty;
        private string patronymic = string.Empty;
        private string phoneNumber = string.Empty;


    }
}
